using System;
using System.Collections.Generic;

namespace StoreApp.Domain.ExtraEdgeStoreDB
{
    public partial class UserOrder
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string OrderName { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
