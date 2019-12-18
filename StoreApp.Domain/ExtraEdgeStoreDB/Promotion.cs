using System;
using System.Collections.Generic;

namespace StoreApp.Domain.ExtraEdgeStoreDB
{
    public partial class Promotion
    {
        public long Id { get; set; }
        public string PromoCodeName { get; set; }
        public string PromoCodeType { get; set; }
        public int? DiscountPercentage { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
