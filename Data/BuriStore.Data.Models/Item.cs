namespace BuriStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BuriStore.Data.Common.Models;

    public class Item : BaseDeletableModel<int>
    {
        public Item()
        {
            this.Components = new HashSet<ItemComponent>();
            this.Images = new HashSet<Image>();
            this.Votes = new HashSet<Vote>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<ItemComponent> Components { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
