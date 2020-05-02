using System.ComponentModel.DataAnnotations;

namespace PayMeForYou.Entity.RequestModules.Role
{
    public class UpdateRoleRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string RoleName { get; set; }
        [StringLength(30)]
        public string Description { get; set; }
        public string Permissions { get; set; }
        [Required]
        [StringLength(30)]
        public string UpdatedBy { get; set; }
    }
}
