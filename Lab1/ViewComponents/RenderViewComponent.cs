using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private List<MenuItem> menuItems = new List<MenuItem>();

        public RenderViewComponent()
        {
            menuItems = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Branches", Url = "Branches/List" },
                new MenuItem { Id = 2, Name = "Students", Url = "Students/List" },
                new MenuItem { Id = 3, Name = "Subjects", Url = "Subjects/List" },
                new MenuItem { Id = 4, Name = "Cources", Url = "Cources/List" }
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderLeftMenu", menuItems);
        }



    }
}
