namespace PayMeForYou.Entity.Views.Role
{
    public class UpdateRoleView
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string Permissions { get; set; }
        public string UpdatedBy { get; set; }
    }
}
