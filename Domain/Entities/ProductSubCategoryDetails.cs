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
    public class ProductSubCategoryDetails
    {
        public System.Guid ProductSubCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryId { get; set; }
        public string CategoryDescription { get; set; }
        public Nullable<System.Guid> SubCategorySeoId { get; set; }
        
        /// <summary>
        /// List for SEO
        /// </summary>
        [Display(Name = "Meta tag title")]
        public SelectList MetaTagTitleList { get; set; }
        public string SelectedMetaTagTitle { get; set; }

        /// <summary>
        /// List for Category
        /// </summary>
        [Display(Name = "Meta tag title")]
        public SelectList CategoryList { get; set; }
        public string SelectedCategoryName { get; set; }

    }

}
