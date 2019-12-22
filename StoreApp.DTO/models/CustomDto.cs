using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.DTO.models
{
    public class CustomDto
    {
        public UserOrdersDto UserOrder { get; set; }
        public UserMobileOrderDto UserMobileOrder { get; set; }
        public MobileDto Mobile { get; set; }
        public UsersDto Users { get; set; }
        public PaymentModeMasterDto PaymentModeMaster { get; set; }
    }
}
