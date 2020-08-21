using PayMeForYou.Entity.Entities;

namespace PayMeForYou.Backend.Models
{
    public class PaginationViewModel : PagenationSetting
    {
        public int TotalRecords { get; set; }
    }
}
