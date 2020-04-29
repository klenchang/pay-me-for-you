using PayMeForYou.Entity.Entities;
using System.Collections.Generic;

namespace PayMeForYou.Entity.Views.Role
{
    public class PermissionSection
    {
        public string SectionName { get; set; }
        public List<CustomCheckBoxItem> Permissions { get; set; } 
    }
}
