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
    public class ProductGameDetails
    {
        [HiddenInput]

        public System.Guid ProductGameId { get; set; }

        [Display(Name = "GameName")]
        public string GameName { get; set; }

        [Display(Name = "GameDescription")]
        public string GameDescription { get; set; }

        [Display(Name = "GameShortUrl")]
        public string GameShortUrl { get; set; }

        [HiddenInput]

        public Nullable<System.Guid> GameSeoId { get; set; }

        public List<ProductCategoryDetails> ProductCategoryDetailsCollection { get; set; }

        public class ProductCategoryDetails
        {
            [HiddenInput]
            public System.Guid ProductCategoryId { get; set; }

            [Display(Name = "Product Category Name")]
            public string ProductCategoryName { get; set; }

            [HiddenInput]
            public Nullable<System.Guid> ProductGameId { get; set; }

            [Display(Name = "Category Description")]
            public string CategoryDescription { get; set; }

            [HiddenInput]
            public Nullable<System.Guid> ProductSubCategoryId { get; set; }

            [Display(Name = "Category SeoId")]
            public Nullable<System.Guid> CategorySeoId { get; set; }
        }
        public static List<ProductCategoryDetails> PopulateProductGameDetails(ProductGame productGame)
        {
            List<ProductCategoryDetails> result = new List<ProductCategoryDetails>();
            foreach (var item  in productGame.ProductCategory)
            {
                result.Add(new ProductCategoryDetails
                {
                    ProductCategoryId = item.ProductCategoryId,
                    ProductCategoryName = item.ProductCategoryName,
                    ProductGameId = item.ProductGameId,
                    CategoryDescription = item.CategoryDescription,
                    ProductSubCategoryId = item.ProductSubCategoryId,
                    CategorySeoId = item.CategorySeoId
                });
            }
            return result;
        }
    }
}
