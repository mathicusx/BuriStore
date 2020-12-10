namespace BuriStore.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ItemComponentInputModel
    {
        [Required]
        [MinLength(3)]
        public string ComponentName { get; set; }

        [Required]
        [MinLength(3)]
        public string ComponentType { get; set; }
    }
}
