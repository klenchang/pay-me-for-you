using System;

namespace PayMeForYou.Entity.RepositoryModules
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int MerchantId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int RoleId { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string LastLoginFrom { get; set; }
        public bool Status { get; set; }
        public string Password { get; set; }
        public string IPWhiteList { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
