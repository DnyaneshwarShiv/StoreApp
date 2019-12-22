using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace StoreApp.Repository.CustomEntities
{
    public static class FilterExtension
    {
        public static Expression<Func<TEntity, bool>>  BuildPredicate<TEntity,TEntity1>(TEntity1 obj) where TEntity : class
        {
            var props = typeof(TEntity1).GetRuntimeProperties().ToArray();
            props = props.Where(c => !string.IsNullOrWhiteSpace(c.Name)).Select(prop => prop).ToArray();
            var predicate = PredicateBuilder.True<TEntity>();
            for (int i = 0; i < props.Length; i++)
            {
               
                    //var nestedProperties = obj.GetType().GetProperty(props[i].Name).GetType().GetRuntimeProperties().ToArray();
                //if (props[i].Name == typeof(TEntity1).Name)
                //{
                    //for (int j = 0; j < nestedProperties.Length; j++)
                    //{

                        var value = (props[i]).GetValue(obj, null);
                        var entityParameter = Expression.Parameter(typeof(TEntity1), typeof(TEntity1).Name);
                        if (value != null)
                        {

                            predicate = predicate.And(k => props[i].Name.ToLower().Equals(value));
                        }
                    //}
               // }
            }
            return predicate;
        }
        public static IQueryable BuildPredicateForStore<TEntity, TEntity2>(  IQueryable<TEntity> ob, TEntity2 obj) where TEntity2:class where TEntity : class
        {
            var props = ob.FirstOrDefault().GetType().GetProperties();
            var predicate = PredicateBuilder.True<TEntity2>();
            IQueryable query;
            for (int i=0;i<props.Length;i++)
            {
                var nestedPropertyType = props[i];
                if (nestedPropertyType.Name == typeof(TEntity2).Name)
                {
                    var nestedproperties = ob.FirstOrDefault().GetType().GetRuntimeProperty(obj.GetType().Name).PropertyType.GetProperties();
                    for (int j = 0; j < nestedproperties.Length; j++)
                    {
                        var propertyInfo = typeof(TEntity2).GetProperty(nestedproperties[j].Name);
                        ParameterExpression p = Expression.Parameter(typeof(TEntity2), nestedproperties[j].Name);

                        // Construct the nested properties
                        // string[] nestedProps = prop.Split('.');
                        Expression mbr = p;
                            mbr = Expression.PropertyOrField(mbr, nestedproperties[j].Name);

                        var value = propertyInfo.GetValue(obj, null);
                        query = addPropertyMatch<TEntity>(ob,mbr, value,p);
                    }
                    //for (int j = 0; j < nestedproperties.Length; j++)
                    //{
                    //    var propertyInfo = obj.GetType().GetProperty(nestedproperties[j].Name);

                    //    var value = propertyInfo.GetValue(obj, null);


                    //    var entityParameter = Expression.Parameter(typeof(TEntity2), typeof(TEntity2).Name);
                    //    if (value != null)
                    //    {
                    //       //ob= ContainsInAnyString(ob, propertyInfo.Name,propertyInfo,value, obj);
                    //        //if(propertyInfo.PropertyType.FullName.ToLower().Contains("string"))
                    //        //{
                    //        //}
                    //        //else if (propertyInfo.PropertyType.FullName.ToLower().Contains("decimal")&&(decimal)value>0)
                    //        //{
                    //        //    predicate = predicate.And(t => nestedproperties[j].Name == value);
                    //        //}
                    //        //else if (propertyInfo.PropertyType.FullName.ToLower().Contains("long")&& (long)value > 0)
                    //        //{
                    //        //    predicate = predicate.And(t => nestedproperties[j].Name == value );
                    //        //}


                    //    }


                    //}
                }
            }
            return ob;
        }

        //public static Expression<Func<TDestination,bool>> FilterData<TDestination,T>(T entity,string name,object value)
        //{
        //    //var param = Expression.Parameter(typeof(TDestination).GetRuntimeProperty(entity.GetType().Name).GetType(), name);
        //    //var exp = Expression.Lambda<Func<T, bool>>(
        //    //    Expression.Equal(
        //    //        Expression.Property(param, "Name"),
        //    //        Expression.Constant("Bob")
        //    //    ),
        //    //    param
        //    //);
        //    //return exp;
        //}
        private static IQueryable addPropertyMatch<TEntity>(IQueryable query,
                                    Expression mbr,
                                    object value, ParameterExpression p
    )
        {
           
            LambdaExpression pred = Expression.Lambda(
                Expression.Equal(
                    mbr,
                    Expression.Constant(value)
                    ),
                    p
            );
            var where = new Func<IQueryable<int>, Expression<Func<int, bool>>, IQueryable<int>>(Queryable.Where).Method;

            var whereForMyType = where.GetGenericMethodDefinition().MakeGenericMethod(typeof(TEntity));

            return query.Provider.CreateQuery(
                       // Expression.Call(typeof(Queryable), whereForMyType, new Type[] { query.ElementType }, query.Expression, pred)
                        Expression.Call(mbr, whereForMyType, p)
                        );
        }
        //public static IQueryable<T> ContainsInAnyString<T,T1>(IQueryable<T> collection, string query,PropertyInfo type,object value,T1 t1)
        //{

        //     string stringPropertyNames = typeof(T).GetRuntimeProperty(t1.GetType().Name).PropertyType.GetProperties().Where(pi => pi.PropertyType == type.PropertyType && pi.GetGetMethod() != null)
        //        .Select(pi => pi.Name).FirstOrDefault() ;

        //    var item = Expression.Parameter(typeof(T).GetRuntimeProperty(t1.GetType().Name).PropertyType, "item");
        //    var propertyExp = Expression.Property(item, type.Name);
        //    //var item = type.Name;
        //    var searchArgument = Expression.Constant(query);
        //    MethodInfo method=null;
        //    bool isNumeric = false;
        //    Expression<Func<T, bool>> lambda;
        //    var currentProp = Expression.Property(item, stringPropertyNames);
        //    if (type.PropertyType.Name.ToLower().Contains("string"))
        //    {
        //        method = typeof(string).GetMethod("Equals", new[] { typeof(string) });

        //        //else if(type.PropertyType.Name.ToLower().Contains("decimal"))
        //        //{
        //        //    method = typeof(object).GetMethod("ToString");
        //        //    isNumeric = true;
        //        //}
        //        //else if (type.PropertyType.Name.ToLower().Contains("float"))
        //        //{
        //        //    method = typeof(object).GetMethod("ToString");
        //        //    isNumeric = true;
        //        //}
        //        //else if (type.PropertyType.Name.ToLower().Contains("long") || type.PropertyType.Name.ToLower().Contains("int"))
        //        //{
        //        //    method = typeof(object).GetMethod("ToString");
        //        //    isNumeric = true;
        //        //}
        //        //foreach (var name in stringPropertyNames)
        //        //{

        //            var startsWithDishExpr = Expression.Call(currentProp, method, searchArgument);

        //                lambda = Expression.Lambda<Func<T, bool>>(startsWithDishExpr, item);
        //                collection = collection.Where(lambda);
        //        //}
        //    }
        //    else
        //    {
        //        //method = typeof(decimal).GetMethod("contains", new[] { currentProp.Type});
        //        //Expression callExpr = Expression.Call(currentProp, method, searchArgument);
        //        //var converter = TypeDescriptor.GetConverter(stringPropertyNames);
        //        //var startsWithDishExpr = Expression.Call(currentProp, method, searchArgument);

        //        //lambda = Expression.Lambda<Func<T, bool>>(startsWithDishExpr, item);
        //        ////collection = collection.Where(lambda);
        //        //if ((decimal)value != 0)
        //        //{
        //        //    collection = collection.Where(lambda);
        //        //}
        //    }
        //    return collection;
        //}
        public static bool Contains(this decimal obj, string value)
        {
            String _this = obj.ToString();
            return _this.Contains(value);
        }
    }

    public static class PredicateBuilder
    {
        /// <summary>    
        /// Creates a predicate that evaluates to true.    
        /// </summary>    
        public static Expression<Func<T, bool>> True<T>() { return param => true; }

        /// <summary>    
        /// Creates a predicate that evaluates to false.    
        /// </summary>    
        public static Expression<Func<T, bool>> False<T>() { return param => false; }

        /// <summary>    
        /// Creates a predicate expression from the specified lambda expression.    
        /// </summary>    
        public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> predicate) { return predicate; }

        /// <summary>    
        /// Combines the first predicate with the second using the logical "and".    
        /// </summary>    
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        /// <summary>    
        /// Combines the first predicate with the second using the logical "or".    
        /// </summary>    
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.OrElse);
        }

        /// <summary>    
        /// Negates the predicate.    
        /// </summary>    
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var negated = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
        }

        /// <summary>    
        /// Combines the first expression with the second using the specified merge function.    
        /// </summary>    
        static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // zip parameters (map from parameters of second to parameters of first)    
            var map = first.Parameters
                .Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with the parameters in the first    
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // create a merged lambda expression with parameters from the first expression    
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        class ParameterRebinder : ExpressionVisitor
        {
            readonly Dictionary<ParameterExpression, ParameterExpression> map;

            ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                ParameterExpression replacement;

                if (map.TryGetValue(p, out replacement))
                {
                    p = replacement;
                }

                return base.VisitParameter(p);
            }
        }
    }
}