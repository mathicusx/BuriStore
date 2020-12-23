namespace BuriStore.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using BuriStore.Web.ViewModels.Items;

    public interface IItemsService
    {
        Task CreateAsync(CreateItemInputModel input, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage);

        public int GetCount();
    }
}
