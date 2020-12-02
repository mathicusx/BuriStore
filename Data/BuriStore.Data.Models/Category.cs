namespace BuriStore.Data.Models
{
    using BuriStore.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Category
    {
        public Category()
        {
            this.Items = new HashSet<Item>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
