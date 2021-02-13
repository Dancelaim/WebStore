using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WowCarry.Domain.Entities
{
    public class ProductCategoryDetails
    {
        [HiddenInput]
        public System.Guid ProductCategoryId { get; set; }

        [Display(Name = "ProductCategoryName")]
        public string ProductCategoryName { get; set; }

        [HiddenInput]
        public Nullable<System.Guid> ProductGameId { get; set; }

        [Display(Name = "CategoryDescription")]
        public string CategoryDescription { get; set; }

        [HiddenInput]
        public Nullable<System.Guid> ProductSubCategoryId { get; set; }

        [HiddenInput]
        public Nullable<System.Guid> CategorySeoId { get; set; }


        /// <summary>
        /// List for Game
        /// </summary>
        [Display(Name = "Game name")]
        public SelectList GamesList { get; set; }

        [Required(ErrorMessage = "Product Game is required")]
        public string SelectedGame { get; set; }

        /// <summary>
        /// List for SEO
        /// </summary>
        [Display(Name = "Meta tag title")]
        public SelectList MetaTagTitleList { get; set; }
        public string SelectedMetaTagTitle { get; set; }

    }

}
