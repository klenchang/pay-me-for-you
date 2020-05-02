using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PayMeForYou.Entity.Views.Role
{
    public class UpdateRoleView
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        [StringLength(30)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public List<PermissionSection> PermissionSections { get; set; }
        [Required]
        [StringLength(30)]
        public string UpdatedBy { get; set; }
    }
}
