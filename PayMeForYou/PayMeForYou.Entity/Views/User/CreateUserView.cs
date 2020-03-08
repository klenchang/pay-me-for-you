namespace PayMeForYou.Entity.Views.User
{
    public class CreateUserView
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string IPWhiteList { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
    }
}
