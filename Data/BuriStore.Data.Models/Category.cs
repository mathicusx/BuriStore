namespace BuriStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BuriStore.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Items = new HashSet<Item>();
        }

        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
