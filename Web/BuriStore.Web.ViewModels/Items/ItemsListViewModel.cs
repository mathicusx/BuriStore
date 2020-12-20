﻿namespace BuriStore.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ItemsListViewModel
    {
        public IEnumerable<ItemsInListViewModel> Items { get; set; }

        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.ItemsCount / this.ItemsPerPage);

        public int ItemsCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
