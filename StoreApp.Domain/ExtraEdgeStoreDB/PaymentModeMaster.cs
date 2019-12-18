using System;
using System.Collections.Generic;

namespace StoreApp.Domain.ExtraEdgeStoreDB
{
    public partial class PaymentModeMaster
    {
        public long Id { get; set; }
        public string PaymentType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
