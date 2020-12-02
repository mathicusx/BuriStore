namespace BuriStore.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using BuriStore.Data;
    using BuriStore.Web.ViewModels;
    using BuriStore.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                CategoriesCount = this.db.Categories.Count(),
                ImagesCount = this.db.Images.Count(),
                ItemsCount = this.db.Items.Count(),
                ComponentsCount = this.db.Components.Count(),
            };
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
