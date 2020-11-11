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
        public IEnumerable<ProductOptions> Options => context.ProductOptions;
        public IEnumerable<HtmlBlocks> HtmlBlocks => context.HtmlBlocks;

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

        public void SaveOptions(ProductOptionDetails productOptionDetails)
        {
            if (String.IsNullOrEmpty(productOptionDetails.OptionParent))
            {
                ProductOptions prodOpt = new ProductOptions
                {
                    ProductOptionId = Guid.NewGuid(),
                    OptionName = productOptionDetails.OptionName,
                    OptionType = productOptionDetails.OptionType
                };
                context.ProductOptions.Add(prodOpt);

                foreach (var item in productOptionDetails.ParamCollection)
                {
                    ProductOptionParams prodOptParams = new ProductOptionParams
                    {
                        OptionParamsId = Guid.NewGuid(),
                        ParamName = item.Paramname,
                        ParamTooltip = item.ParamTooltip,
                        ParamPrice = item.ParamPrice,
                        ProductOptionId = prodOpt.ProductOptionId,
                        Sale = item.Sale
                    };
                    context.ProductOptionParams.Add(prodOptParams);
                }
            }
            else
            {
                ProductOptions prodOpt = new ProductOptions
                {
                    ProductOptionId = Guid.NewGuid(),
                    OptionName = productOptionDetails.OptionName,
                    OptionType = productOptionDetails.OptionType
                    //OptionParentid  = productOptionDetails.ParentId
                };
                context.ProductOptions.Add(prodOpt);

                foreach (var item in productOptionDetails.ParamCollection)
                {
                    ProductOptionParams prodOptParams = new ProductOptionParams
                    {
                        OptionParamsId = Guid.NewGuid(),
                        ParamName = item.Paramname,
                        ParamTooltip = item.ParamTooltip,
                        ParamPrice = item.ParamPrice,
                        ProductOptionId = prodOpt.ProductOptionId,
                        Sale = item.Sale
                    };
                    context.ProductOptionParams.Add(prodOptParams);
                }
            }
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
                    , ProductCategoryId = context.ProductCategory.Where(c => c.ProductCategoryName == productDetails.ProductCategoryName).Select(c => c.ProductCategoryId).FirstOrDefault()
                    , InStock = productDetails.InStock
                    , PreOrder = productDetails.PreOrder
                    , ProductQuantity = productDetails.ProductQuantity
                    , ProductImage = SaveImage()
                    , ProductDescriptionId = context.ProductDescription.Find(prodDescr.ProductDescriptionId).ProductDescriptionId
                    , ProductSEOId = context.SEO.Where(c => c.MetaTagTitle == productDetails.MetaTagTitle).Select(c => c.SEOId).FirstOrDefault()
                    , ProductGameId = context.ProductGame.Where(c => c.GameName == productDetails.ProductGameName).Select(c => c.ProductGameId).FirstOrDefault()
                    , ProductSubCategoryId = context.ProductSubCategory.Where(c => c.ProductCategoryName == productDetails.ProductSubCategoryName).Select(c => c.ProductSubCategoryId).FirstOrDefault()
                    , ProductPriority = productDetails.ProductPriority
                    , ProductEnabled = productDetails.ProductEnabled
                    , ProductImageThumb = SaveImage()
                };
                context.Product.Add(prod);
            }
            else
            {
                Product dbEntry = context.Product.Find(productDetails.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.ProductName = productDetails.ProductName;
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
    }
}
