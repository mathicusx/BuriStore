namespace BuriStore.Data.Models
{
    using BuriStore.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Image
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public virtual Item Items { get; set; }

        public string Extension { get; set; }
    }
}
