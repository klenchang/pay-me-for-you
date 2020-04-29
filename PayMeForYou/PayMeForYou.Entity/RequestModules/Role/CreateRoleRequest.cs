using System.ComponentModel.DataAnnotations;

namespace PayMeForYou.Entity.RequestModules.Role
{
    public class CreateRoleRequest
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        [StringLength(30)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public string Permissions { get; set; }
        [Required]
        [StringLength(30)]
        public string CreatedBy { get; set; }
    }
}
