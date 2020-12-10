namespace BuriStore.Data.Models
{
    using System.Collections.Generic;

    using BuriStore.Data.Common.Models;

    public class Component : BaseDeletableModel<int>
    {
        public Component()
        {
            this.Items = new HashSet<ItemComponent>();
        }

        public string Name { get; set; }

        public virtual ICollection<ItemComponent> Items { get; set; }
    }
}
