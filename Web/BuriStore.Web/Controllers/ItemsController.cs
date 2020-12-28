namespace BuriStore.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BuriStore.Common;
    using BuriStore.Data;
    using BuriStore.Data.Common.Repositories;
    using BuriStore.Data.Models;
    using BuriStore.Services.Data;
    using BuriStore.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class ItemsController : Controller
    {
        private readonly IItemsService itemsService;
        private readonly ICategoriesService categoriesService;
        private readonly IWebHostEnvironment environment;

        public ItemsController(
            IItemsService itemsService,
            ICategoriesService categoriesService,
            IWebHostEnvironment environment)
        {
            this.itemsService = itemsService;
            this.categoriesService = categoriesService;
            this.environment = environment;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var viewModel = new CreateItemInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel input, string imagePath)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            try
            {
                await this.itemsService.CreateAsync(input, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception exception)
            {
                this.ModelState.AddModelError(string.Empty, exception.Message);
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int itemsPerPage = 12;
            var viewModel = new ItemsListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                ItemsCount = this.itemsService.GetCount(),
                Items = this.itemsService.GetAll<ItemsInListViewModel>(id, itemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult ItemById(int id)
        {
            var item = this.itemsService.GetById<SingleItemViewModel>(id);
            return this.View(item);
        }
    }
}
