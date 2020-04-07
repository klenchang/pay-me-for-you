using System.ComponentModel.DataAnnotations;

namespace PayMeForYou.Entity.Views.Role
{
    public class CreateRoleView
    {
        [Required]
        [StringLength(30)]
        public string RoleName { get; set; }
        [StringLength(30)]
        public string Description { get; set; }
        public string Permissions { get; set; }
        [Required]
        [StringLength(30)]
        public string CreatedBy { get; set; }
    }
}
