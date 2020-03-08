namespace PayMeForYou.Entity.Views.User
{
    public class UpdateUserView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string MerchantName { get; set; }
        public string RoleName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string IPWhiteList { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public string UpdatedBy { get; set; }
    }
}
