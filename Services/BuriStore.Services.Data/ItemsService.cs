namespace BuriStore.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BuriStore.Data.Common.Repositories;
    using BuriStore.Data.Models;
    using BuriStore.Services.Mapping;
    using BuriStore.Web.ViewModels.Items;

    public class ItemsService : IItemsService
    {
        private readonly string[] AllowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Item> itemsRepository;
        private readonly IDeletableEntityRepository<Component> componentsRepository;

        public ItemsService(
            IDeletableEntityRepository<Item> itemsRepository,
            IDeletableEntityRepository<Component> componentsRepository)
        {
            this.itemsRepository = itemsRepository;
            this.componentsRepository = componentsRepository;
        }

        public async Task CreateAsync(CreateItemInputModel input, string imagePath)
        {
            var item = new Item()
            {
                CategoryId = input.CategoryId,
                Name = input.Name,
                Price = input.Price,
                Description = input.Description,
            };

            foreach (var inputComponent in input.Components)
            {
                var component = this.componentsRepository.All().FirstOrDefault(x => x.Name == inputComponent.ComponentName);
                if (component == null)
                {
                    component = new Component { Name = inputComponent.ComponentName };
                }

                item.Components.Add(new ItemComponent
                {
                    Component = component,
                    Type = inputComponent.ComponentType,
                });
            }

            Directory.CreateDirectory($"{imagePath}/items/");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName);
                if (!this.AllowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    Extension = extension,
                };

                item.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/items/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(fileStream);

                await this.itemsRepository.AddAsync(item);
                await this.itemsRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
        {
            var items = this.itemsRepository.AllAsNoTracking()
                .OrderByDescending(i => i.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<T>()
                .ToList();
            return items;
        }

        public int GetCount()
        {
            return this.itemsRepository.All().Count();
        }
    }
}
