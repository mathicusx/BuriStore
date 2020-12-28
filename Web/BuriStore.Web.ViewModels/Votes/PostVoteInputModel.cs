namespace BuriStore.Web.ViewModels.Reviews
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class PostVoteInputModel
    {
        public int ItemId { get; set; }

        [Range(1, 5)]
        public double Value { get; set; }
    }
}
