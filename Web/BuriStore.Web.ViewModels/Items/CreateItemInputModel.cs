namespace BuriStore.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BuriStore.Data.Models;
    using Microsoft.AspNetCore.Http;

    public class CreateItemInputModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [Range(1, 99999)]
        public double Price { get; set; }

        [Required]
        [MinLength(50)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<ItemComponentInputModel> Components { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
