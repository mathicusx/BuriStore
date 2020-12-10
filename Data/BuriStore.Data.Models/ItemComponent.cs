namespace BuriStore.Data.Models
{
    public class ItemComponent
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

        public int ComponentId { get; set; }

        public virtual Component Component { get; set; }

        public string Type { get; set; }
    }
}
