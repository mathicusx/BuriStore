namespace BuriStore.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using BuriStore.Data.Models;
    using BuriStore.Services.Mapping;

    public class ItemsInListViewModel : IMapFrom<Item>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Item, ItemsInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(i => i.Images
                .FirstOrDefault().RemoteImageUrl != null ?
                i.Images.FirstOrDefault().RemoteImageUrl : "/images/items/" + i.Images.FirstOrDefault().Id + "." + i.Images.FirstOrDefault().Extension));
        }
    }
}
