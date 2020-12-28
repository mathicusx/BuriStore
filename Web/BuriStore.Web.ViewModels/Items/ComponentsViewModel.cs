namespace BuriStore.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BuriStore.Data.Models;
    using BuriStore.Services.Mapping;

    public class ComponentsViewModel : IMapFrom<ItemComponent>
    {
        public string ComponentName { get; set; }

        public string Type { get; set; }
    }
}
