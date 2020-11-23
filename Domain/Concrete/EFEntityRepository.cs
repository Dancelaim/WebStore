using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WowCarry.Domain.Abstract;
using WowCarry.Domain.Entities;

namespace WowCarry.Domain.Concrete
{
    public class EFEntityRepository : IEntityRepository
    {
        WowCarryEntities context = new WowCarryEntities();
        public IEnumerable<ProductGame> Games => context.ProductGame;
        public IEnumerable<SEO> SEOs => context.SEO;
        public IEnumerable<Realms> Realms => context.Realms;
        public IEnumerable<Product> Products => context.Product;
        public IEnumerable<ProductOptions> ProductOptions => context.ProductOptions;
        public IEnumerable<HtmlBlocks> HtmlBlocks => context.HtmlBlocks;
        public IEnumerable<TemplateOptions> TemplateOptions => context.TemplateOptions;


        public void SaveGame(ProductGame game)
        {
            throw new NotImplementedException();
        }

        public void SaveHtmlBlock(HtmlBlocks htmlBlock)
        {
            throw new NotImplementedException();
        }

        public void SaveOption(ProductOptions productOptions)
        {
            throw new NotImplementedException();
        }

        public void SaveContext()
        {
            context.SaveChanges();
        }

        public void SaveProduct(ProductDetails productDetails)
        {
            if (productDetails.ProductId.Equals(Guid.Empty))
            {
                ProductDescription prodDescr = new ProductDescription
                {
                    ProductDescriptionId = Guid.NewGuid()
                    ,Description = productDetails.Description
                    ,SubDescription1 = productDetails.SubDescription1
                    ,SubDescription2 = productDetails.SubDescription2
                    ,SubDescription3 = productDetails.SubDescription3
                    ,SubDescription4 = productDetails.SubDescription4
                    ,SubDescription5 = productDetails.SubDescription5
                    ,SubDescriptionTitle1 = productDetails.SubDescriptionTitle1
                    ,SubDescriptionTitle2 = productDetails.SubDescriptionTitle2
                    ,SubDescriptionTitle3 = productDetails.SubDescriptionTitle3
                    ,SubDescriptionTitle4 = productDetails.SubDescriptionTitle4
                    ,SubDescriptionTitle5 = productDetails.SubDescriptionTitle5
                };
                context.ProductDescription.Add(prodDescr);

                Product prod = new Product
                {
                    ProductId = Guid.NewGuid()
                    , ProductName = productDetails.ProductName
                    , InStock = productDetails.InStock
                    , PreOrder = productDetails.PreOrder
                    , ProductQuantity = productDetails.ProductQuantity
                    , ProductImage = SaveImage()
                    , ProductDescriptionId = context.ProductDescription.Find(prodDescr.ProductDescriptionId).ProductDescriptionId
                    ,ProductCategoryId = context.ProductCategory.Where(c => c.ProductCategoryName == productDetails.SelectedCategory).Select(c => c.ProductCategoryId).FirstOrDefault()
                    ,ProductSEOId = context.SEO.Where(c => c.MetaTagTitle == productDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault()
                    , ProductGameId = context.ProductGame.Where(c => c.GameName == productDetails.SelectedGame).Select(c => c.ProductGameId).FirstOrDefault()
                    //, ProductSubCategoryId = context.ProductSubCategory.Where(c => c.ProductCategoryName == productDetails.ProductSubCategoryName).Select(c => c.ProductSubCategoryId).FirstOrDefault()
                    , ProductPriority = productDetails.ProductPriority
                    , ProductEnabled = productDetails.ProductEnabled
                    , ProductImageThumb = SaveImage()
                };
                context.Product.Add(prod);
            }
            else
            {
                Product dbProduct = context.Product.Find(productDetails.ProductId);
                ProductDescription dbDescr = dbProduct.ProductDescription;
                if(dbDescr != null)
                {
                    dbDescr.Description = productDetails.Description;
                    dbDescr.SubDescription1 = productDetails.SubDescription1;
                    dbDescr.SubDescription2 = productDetails.SubDescription2;
                    dbDescr.SubDescription3 = productDetails.SubDescription3;
                    dbDescr.SubDescription4 = productDetails.SubDescription4;
                    dbDescr.SubDescription5 = productDetails.SubDescription5;
                    dbDescr.SubDescriptionTitle1 = productDetails.SubDescriptionTitle1;
                    dbDescr.SubDescriptionTitle2 = productDetails.SubDescriptionTitle2;
                    dbDescr.SubDescriptionTitle3 = productDetails.SubDescriptionTitle3;
                    dbDescr.SubDescriptionTitle4 = productDetails.SubDescriptionTitle4;
                    dbDescr.SubDescriptionTitle5 = productDetails.SubDescriptionTitle5;
                }
                if (dbProduct != null)
                {
                    dbProduct.ProductName = productDetails.ProductName;
                    dbProduct.InStock = productDetails.InStock;
                    dbProduct.PreOrder = productDetails.PreOrder;
                    dbProduct.ProductQuantity = productDetails.ProductQuantity;
                    dbProduct.ProductImage = SaveImage();
                    dbProduct.ProductCategoryId = context.ProductCategory.Where(c => c.ProductCategoryName == productDetails.SelectedCategory).Select(c => c.ProductCategoryId).FirstOrDefault();
                    dbProduct.ProductSEOId = context.SEO.Where(c => c.MetaTagTitle == productDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault();
                    dbProduct.ProductGameId = context.ProductGame.Where(c => c.GameName == productDetails.SelectedGame).Select(c => c.ProductGameId).FirstOrDefault();
                    //dbProduct.ProductSubCategoryId = context.ProductSubCategory.Where(c => c.ProductCategoryName == productDetails.ProductSubCategoryName).Select(c => c.ProductSubCategoryId).FirstOrDefault()
                    dbProduct.ProductPriority = productDetails.ProductPriority;
                    dbProduct.ProductEnabled = productDetails.ProductEnabled;
                    dbProduct.ProductImageThumb = SaveImage();
                }
            }
            context.SaveChanges();
        }
        
        public void SaveSEO(SEO seo)
        {
            throw new NotImplementedException();
        }
        public string SaveImage()
        {
            string result = "";
            return result;
        }

        public void SaveTemplateOption(TemplateOptions tempOptions)
        {
            throw new NotImplementedException();
        }
    }
}
