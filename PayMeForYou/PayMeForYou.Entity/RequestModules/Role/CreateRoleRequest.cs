using System.ComponentModel.DataAnnotations;

namespace PayMeForYou.Entity.RequestModules.Role
{
    public class CreateRoleRequest
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
