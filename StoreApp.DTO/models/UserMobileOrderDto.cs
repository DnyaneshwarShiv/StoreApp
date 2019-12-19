using System;

namespace StoreApp.DTO.models
{
    public class UserMobileOrderDto
    {
        public long Id { get; set; }
        public long? UserOrderId { get; set; }
        public string MobileId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public long PaymentId { get; set; }
    }
}
