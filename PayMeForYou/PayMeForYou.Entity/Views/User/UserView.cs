using System;

namespace PayMeForYou.Entity.Views.User
{
    public class UserView
    {
        public int RowNo { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string MerchantName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string RoleName { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string LastLoginFrom { get; set; }
        public bool Status { get; set; }
    }
}
