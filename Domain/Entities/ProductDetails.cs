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
    public class ProductDetails
    {
        Product product { get; set; }
        IEnumerable<string> productGameNames { get; set; }
        public SelectList GamesList { get { return new SelectList(productGameNames, product.ProductGame.GameName);} }

        IEnumerable<string> productCategoryNames { get; set; }
        public SelectList CategoriesList { get { return new SelectList(productCategoryNames, product.ProductCategory.ProductCategoryName); } }

        IEnumerable<string> ProductOptionNames { get { return product.ProductOptions.Select(o=>o.OptionName); } }
        public SelectList OptionsList { get { return new SelectList(ProductOptionNames, "Select Option"); } }

        IEnumerable<string> MetaTagTitleNames { get; set; }
        public SelectList MetaTagTitleList { get { return new SelectList(MetaTagTitleNames, product.SEO.MetaTagTitle ?? "Select Meta tag title from List"); } }

        public Guid ProductId { get {return product.ProductId;}}

        [Required(ErrorMessage = "Product Name is required")]
        [Display(Name = "Product Name")]
        public string ProductName { get {return product.ProductName;}}

        [Display(Name = "In Stock")]
        public bool InStock { get { return product.InStock; } }

        public bool PreOrder { get { return product.PreOrder; } }

        [Display(Name = "Status")]
        public bool ProductEnabled { get { return product.ProductEnabled; } }

        [Display(Name = "Product Quantity")]
        public int ProductQuantity { get { return (int)product.ProductQuantity; } }

        [Display(Name = "Image")]
        public string ProductImageThumb { get { return product.ProductImageThumb; } }

        [Display(Name = "Large Image")]
        public string ProductImage { get { return product.ProductImage; } }

        [Display(Name = "Sort Order")]
        public int? ProductPriority { get { return product.ProductPriority; } }

        [Required(ErrorMessage = "Game name is required")]
        [Display(Name = "Game name")]
        public string ProductGameName { get { return product.ProductGame.GameName; } }

        [Display(Name = "Category name")]
        public string ProductCategoryName { get { return product.ProductCategory.ProductCategoryName; } }

        [Display(Name = "SubCategory name")]
        public string ProductSubCategoryName { get; set; }

        [Display(Name = "Meta tag title")]
        public string MetaTagTitle { get { return product.SEO.MetaTagTitle; } }

        [Display(Name = "Price EU")]
        public decimal? ProductPriceEU { get { return product.ProductPrice.Where(p=>p.Region=="EU").Select(p=>p.Price).FirstOrDefault(); } }

        [Display(Name = "Price US")]
        public decimal? ProductPriceUS { get { return product.ProductPrice.Where(p => p.Region == "US").Select(p => p.Price).FirstOrDefault(); } }

        [Display(Name = "Sale EU")]
        public decimal? ProductSaleEU { get { return product.ProductPrice.Where(p => p.Region == "EU").Select(p => p.ProductSale).FirstOrDefault();} }

        [Display(Name = "Sale US")]
        public decimal? ProductSaleUS { get { return product.ProductPrice.Where(p => p.Region == "US").Select(p => p.ProductSale).FirstOrDefault(); } }

        [Display(Name = "Product Description")]
        public string Description { get { return product.ProductDescription.Description; } }

        [Display(Name = "Product SubDescription Title 1")]
        public string SubDescriptionTitle1 { get { return product.ProductDescription.SubDescriptionTitle1; } }

        [Display(Name = "Product SubDescription 1")]
        public string SubDescription1 { get { return product.ProductDescription.SubDescription1; } }

        [Display(Name = "Product SubDescription Title 2")]
        public string SubDescriptionTitle2 { get { return product.ProductDescription.SubDescriptionTitle2; } }

        [Display(Name = "Product SubDescription 2")]
        public string SubDescription2 { get { return product.ProductDescription.SubDescription2; } }

        [Display(Name = "Product SubDescription Title 3")]
        public string SubDescriptionTitle3 { get { return product.ProductDescription.SubDescriptionTitle3; } }

        [Display(Name = "Product SubDescription 3")]
        public string SubDescription3 { get { return product.ProductDescription.SubDescription3; } }

        [Display(Name = "Product SubDescription Title 4")]
        public string SubDescriptionTitle4 { get { return product.ProductDescription.SubDescriptionTitle4; } }

        [Display(Name = "Product SubDescription 4")]
        public string SubDescription4 { get { return product.ProductDescription.SubDescription4; } }

        [Display(Name = "Product SubDescription Title 5")]
        public string SubDescriptionTitle5 { get { return product.ProductDescription.SubDescriptionTitle5; } }

        [Display(Name = "Product SubDescription 5")]
        public string SubDescription5 { get { return product.ProductDescription.SubDescription5; } }

        public ProductDetails (Product prod, IEnumerable<ProductGame> games, IEnumerable<ProductCategory> categories, IEnumerable<SEO> seos)
        {
            product = prod;
            productGameNames = games.Select(g=>g.GameName);
            productCategoryNames = categories.Select(p=>p.ProductCategoryName);
            MetaTagTitleNames = seos.Select(s => s.MetaTagTitle);
        }

    }
}
