using StoreApp.Domain.ClientDB;
using StoreApp.Domain.ExtraEdgeStoreDB;

namespace StoreApp.Repository.CustomEntities
{
   public class CustomEntity
    {
        public UserOrder UserOrder { get; set; }
        public UserMobileOrder UserMobileOrder { get; set; }
        public Mobile Mobile { get; set; }
        public Users Users { get; set; }
        public PaymentModeMaster PaymentModeMaster { get; set; }
    }
}
