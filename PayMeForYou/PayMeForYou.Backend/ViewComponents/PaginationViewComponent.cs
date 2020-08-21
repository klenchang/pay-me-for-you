using Microsoft.AspNetCore.Mvc;
using PayMeForYou.Backend.Models;
using System.Threading.Tasks;

namespace PayMeForYou.Backend.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await Task.Run(() => new PaginationViewModel { TotalRecords = 100, PageSize = 10, PageIndex = 1 });

            return View(model);
        }
    }
}
