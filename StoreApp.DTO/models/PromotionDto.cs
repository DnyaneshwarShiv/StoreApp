using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DTO.models
{
    public class PromotionDto
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
