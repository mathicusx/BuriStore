namespace BuriStore.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using BuriStore.Data.Models;
    using BuriStore.Services.Mapping;

    public class SingleItemViewModel : IMapFrom<Item>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double AverageVote { get; set; }

        public IEnumerable<ComponentsViewModel> Components { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Item, SingleItemViewModel>()
                .ForMember(x => x.AverageVote, opt =>
                opt.MapFrom(x => x.Votes.Count() == 0 ? 0 : x.Votes.Average(v => v.Value)))
                .ForMember(i => i.ImageUrl, opt =>
                opt.MapFrom(i =>
                i.Images.FirstOrDefault().RemoteImageUrl != null ?
                i.Images.FirstOrDefault().RemoteImageUrl :
                "/images/items/" + i.Images.FirstOrDefault().Id + "." + i.Images.FirstOrDefault().Extension));
        }
    }
}
