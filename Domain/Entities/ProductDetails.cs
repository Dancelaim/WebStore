﻿using System;
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
        public SelectList productGames { get { return new SelectList(productGameNames, product.ProductGame.GameName);} }
        IEnumerable<string> productCategoryNames { get; set; }
        public SelectList productCategories { get { return new SelectList(productCategoryNames, product.ProductCategory.ProductCategoryName); } }

        public Guid ProductId { get {return product.ProductId;}}
        public string ProductName { get {return product.ProductName;}}
        public bool InStock { get { return product.InStock; } }
        public bool PreOrder { get { return product.PreOrder; } }
        public int ProductQuantity { get { return (int)product.ProductQuantity; } }
        public string ProductImageThumb { get { return product.ProductImageThumb; } }
        public string ProductImage { get { return product.ProductImage; } }
        public bool ProductEnabled { get { return product.ProductEnabled; } }
        public int? ProductPriority { get { return product.ProductPriority; } }
        public string ProductCategoryName { get { return product.ProductCategory.ProductCategoryName; } }
        public string ProductSubCategoryName { get; set; }
        public string ProductGameName { get { return product.ProductGame.GameName; } }
        public decimal? ProductPriceEU { get { return product.ProductPrice.Where(p=>p.Region=="EU").Select(p=>p.Price).FirstOrDefault(); } }
        public decimal? ProductPriceUS { get { return product.ProductPrice.Where(p => p.Region == "US").Select(p => p.Price).FirstOrDefault(); } }
        public decimal? ProductSaleEU { get { return product.ProductPrice.Where(p => p.Region == "EU").Select(p => p.ProductSale).FirstOrDefault();} }
        public decimal? ProductSaleUS { get { return product.ProductPrice.Where(p => p.Region == "US").Select(p => p.ProductSale).FirstOrDefault(); } }

        public string Description { get { return product.ProductDescription.Description; } }
        public string SubDescriptionTitle1 { get { return product.ProductDescription.SubDescriptionTitle1; } }
        public string SubDescription1 { get { return product.ProductDescription.SubDescription1; } }
        public string SubDescriptionTitle2 { get { return product.ProductDescription.SubDescriptionTitle2; } }
        public string SubDescription2 { get { return product.ProductDescription.SubDescription1; } }
        public string SubDescriptionTitle3 { get { return product.ProductDescription.SubDescriptionTitle3; } }
        public string SubDescription3 { get { return product.ProductDescription.SubDescription1; } }
        public string SubDescriptionTitle4 { get { return product.ProductDescription.SubDescriptionTitle4; } }
        public string SubDescription4 { get { return product.ProductDescription.SubDescription1; } }
        public string SubDescriptionTitle5 { get { return product.ProductDescription.SubDescriptionTitle5; } }
        public string SubDescription5 { get { return product.ProductDescription.SubDescription1; } }

        public IEnumerable<ProductOption> ProductOption { get { return product.ProductToOption.Where(p=>p.ProductId == product.ProductId).Select(o=>o.ProductOption); } }

        public ProductDetails (Product prod, IEnumerable<ProductGame> games, IEnumerable<ProductCategory> categories)
        {
            product = prod;
            productGameNames = games.Select(g=>g.GameName);
            productCategoryNames = categories.Select(p=>p.ProductCategoryName);
        }

    }
}
