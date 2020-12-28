namespace BuriStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BuriStore.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public double Value { get; set; }
    }
}
