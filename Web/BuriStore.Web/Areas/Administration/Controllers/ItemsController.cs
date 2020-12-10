namespace BuriStore.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuriStore.Data;
    using BuriStore.Data.Common.Repositories;
    using BuriStore.Data.Models;
    using BuriStore.Services.Data;
    using BuriStore.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class ItemsController : Controller
    {
        private readonly IItemsService itemsService;
        private readonly ICategoriesService categoriesService;

        public ItemsController(
            IItemsService itemsService,
            ICategoriesService categoriesService)
        {
            this.itemsService = itemsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateItemInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.itemsService.CreateAsync(input);
            return this.Redirect("/");
        }
    }
}
