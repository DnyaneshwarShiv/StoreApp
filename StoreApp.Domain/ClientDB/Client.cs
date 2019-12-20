using System;
using System.Collections.Generic;

namespace StoreApp.Domain.ClientDB
{
    public partial class Client
    {
        public long Id { get; set; }
        public string StoreDbname { get; set; }
        public string StoreConnectionString { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
