using System;
using System.Collections.Generic;

namespace StoreApp.Domain.ExtraEdgeStoreDB
{
    public partial class Mobile
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal? Price { get; set; }
        public long? Year { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
