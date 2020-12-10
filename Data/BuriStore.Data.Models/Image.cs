namespace BuriStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BuriStore.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int ItemId { get; set; }

        public virtual Item Items { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }
    }
}
