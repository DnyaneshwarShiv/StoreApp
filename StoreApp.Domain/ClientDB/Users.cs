using System;

namespace StoreApp.Domain.ClientDB
{
    public partial class Users
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
    }
}
