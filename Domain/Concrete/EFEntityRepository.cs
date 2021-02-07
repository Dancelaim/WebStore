using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        public IEnumerable<Users> Users => context.Users;
        public IEnumerable<Ranks> Ranks => context.Ranks;
        public IEnumerable<Customers> Customers => context.Customers;
        public IEnumerable<Orders> Orders => context.Orders;
        public IEnumerable<Roles> Roles => context.Roles;
        public IEnumerable<Article> Articles => context.Article;




        public void SaveGame(ProductGameDetails productGameDetails)
        {
            ProductGame dbproductGame = context.ProductGame.Find(productGameDetails.ProductGameId);
            if (dbproductGame != null)
            {
                dbproductGame.GameName = productGameDetails.GameName;
                dbproductGame.GameDescription = productGameDetails.GameDescription;
                dbproductGame.GameShortUrl = productGameDetails.GameShortUrl;
            }
            foreach (ProductGameDetails.ProductCategoryDetails item in productGameDetails.ProductCategoryDetailsCollection)
            {
                ProductCategory dbProductCategory = context.ProductGame.Find(productGameDetails.ProductGameId).ProductCategory.Where(p => p.ProductCategoryId == item.ProductCategoryId).FirstOrDefault();
                if (dbProductCategory != null)
                {
                    dbProductCategory.ProductCategoryName = item.ProductCategoryName;
                    dbProductCategory.ProductGameId = item.ProductGameId;
                    dbProductCategory.CategoryDescription = item.CategoryDescription;
                    dbProductCategory.ProductSubCategoryId = item.ProductSubCategoryId;
                    dbProductCategory.CategorySeoId = item.CategorySeoId;
                }
            }
            context.SaveChanges();
        }
        public void SaveHtmlBlock(HtmlBlockDetails htmlBlockDetails)
        {
            HtmlBlocks dbhtmlBlocks = context.HtmlBlocks.Find(htmlBlockDetails.SiteBlockId);
            if (dbhtmlBlocks != null)
            {
                dbhtmlBlocks.ParentCSSClass = htmlBlockDetails.ParentCSSClass;
                dbhtmlBlocks.ParentTitle = htmlBlockDetails.ParentTitle;
                dbhtmlBlocks.ChildCSSClass = htmlBlockDetails.ChildCSSClass;
                dbhtmlBlocks.SitePage = htmlBlockDetails.SitePage;
                dbhtmlBlocks.Order = htmlBlockDetails.Order;

                foreach (HtmlBlockDetails.HtmlBlockChildrenDetails item in htmlBlockDetails.HtmlBlockChildDetailsCollection)
                {
                    HtmlBlocksChildren dbhtmlBlocksChildren = context.HtmlBlocks.Find(htmlBlockDetails.SiteBlockId).HtmlBlocksChildren.Where(p => p.SiteBlockChildsId == item.SiteBlockChildsId).FirstOrDefault();
                    if (dbhtmlBlocksChildren != null)
                    {
                        dbhtmlBlocksChildren.Text = item.Text;
                        dbhtmlBlocksChildren.Title = item.Title;
                        dbhtmlBlocksChildren.Image = item.Image;
                        dbhtmlBlocksChildren.CSSClass = item.CSSClass;
                        dbhtmlBlocksChildren.ChildOrder = item.ChildOrder;
                    }
                }
            }
            else
            {
                dbhtmlBlocks = new HtmlBlocks();
                dbhtmlBlocks.SiteBlockId = htmlBlockDetails.SiteBlockId;
                dbhtmlBlocks.ParentCSSClass = htmlBlockDetails.ParentCSSClass;
                dbhtmlBlocks.ParentTitle = htmlBlockDetails.ParentTitle;
                dbhtmlBlocks.ChildCSSClass = htmlBlockDetails.ChildCSSClass;
                dbhtmlBlocks.SitePage = htmlBlockDetails.SitePage;
                dbhtmlBlocks.Order = htmlBlockDetails.Order;

                foreach (HtmlBlockDetails.HtmlBlockChildrenDetails item in htmlBlockDetails.HtmlBlockChildDetailsCollection)
                {
                    HtmlBlocksChildren dbhtmlBlocksChildren = new HtmlBlocksChildren { };
                    dbhtmlBlocksChildren.SiteBlockChildsId = item.SiteBlockChildsId;
                    dbhtmlBlocksChildren.SiteBlockId = dbhtmlBlocks.SiteBlockId;
                    dbhtmlBlocksChildren.Text = item.Text;
                    dbhtmlBlocksChildren.Title = item.Title;
                    dbhtmlBlocksChildren.Image = item.Image;
                    dbhtmlBlocksChildren.CSSClass = item.CSSClass;
                    dbhtmlBlocksChildren.ChildOrder = item.ChildOrder;

                    context.HtmlBlocksChildren.Add(dbhtmlBlocksChildren);

                }
                context.HtmlBlocks.Add(dbhtmlBlocks);
            }
            context.SaveChanges();
        }

        public void SaveRanks(RankDetails rankDetails)
        {
            Ranks dbRanks = context.Ranks.Find(rankDetails.RankId);
            if (dbRanks != null)
            {
                dbRanks.RankId = rankDetails.RankId;
                dbRanks.Name = rankDetails.Name;
                dbRanks.Sale = rankDetails.Sale;


                context.SaveChanges();
            }
        }
        public void SaveProductOption(ProductOptionDetails productOptionDetails)
        {
            ProductOptions dbProductOption = context.ProductOptions.Find(productOptionDetails.OptionId);
            if (dbProductOption != null)
            {
                dbProductOption.OptionName = productOptionDetails.OptionName;
                dbProductOption.OptionType = productOptionDetails.OptionType;
                dbProductOption.OptionProductId = productOptionDetails.OptionProductId;
                //dbProductOption.OptionParentId = productOptionDetails.OptionParent != null ? ProductOptions.Where(po => po.OptionName == productOptionDetails.OptionParent).FirstOrDefault().OptionProductId : Guid.Empty;
            }
            foreach (ProductOptionDetails.ProductOptionParamsDetails item in productOptionDetails.ParamCollection)
            {
                Guid? parentId = Guid.Empty;
                if (dbProductOption.OptionParentId != null)
                {
                    parentId = context.ProductOptions.Find(dbProductOption.OptionParentId).ProductOptionParams.Where(p => p.ParameterName == item.ParentParam).Select(p => p.ParameterId).FirstOrDefault();
                }
                ProductOptionParams dbParam = context.ProductOptions.Find(productOptionDetails.OptionId).ProductOptionParams.Where(p => p.ParameterId == item.ParameterId).FirstOrDefault();
                if (dbParam != null)
                {
                    dbParam.ParameterName = item.Paramname;
                    dbParam.ParameterPrice = item.ParamPrice;
                    dbParam.ParameterTooltip = item.ParamTooltip;
                    dbParam.ParameterSale = item.Sale;
                    dbParam.ParameterParentId = parentId.Equals(Guid.Empty) ? null : parentId;
                }
            }
            context.SaveChanges();
        }
        public void SaveProduct(ProductDetails productDetails)
        {

            if (productDetails.ProductId.Equals(Guid.Empty))
            {
                ProductDescription prodDescr = new ProductDescription
                {
                    ProductDescriptionId = Guid.NewGuid()
                    ,
                    Description = productDetails.Description
                    ,
                    SubDescription1 = productDetails.SubDescription1
                    ,
                    SubDescription2 = productDetails.SubDescription2
                    ,
                    SubDescription3 = productDetails.SubDescription3
                    ,
                    SubDescription4 = productDetails.SubDescription4
                    ,
                    SubDescription5 = productDetails.SubDescription5
                    ,
                    SubDescriptionTitle1 = productDetails.SubDescriptionTitle1
                    ,
                    SubDescriptionTitle2 = productDetails.SubDescriptionTitle2
                    ,
                    SubDescriptionTitle3 = productDetails.SubDescriptionTitle3
                    ,
                    SubDescriptionTitle4 = productDetails.SubDescriptionTitle4
                    ,
                    SubDescriptionTitle5 = productDetails.SubDescriptionTitle5
                };
                context.ProductDescription.Add(prodDescr);

                Product prod = new Product
                {
                    ProductId = Guid.NewGuid()
                    ,
                    ProductName = productDetails.ProductName
                    ,
                    InStock = productDetails.InStock
                    ,
                    PreOrder = productDetails.PreOrder
                    ,
                    ProductQuantity = productDetails.ProductQuantity
                    ,
                    ProductImage = productDetails.ProductImage
                    ,
                    ProductDescriptionId = context.ProductDescription.Find(prodDescr.ProductDescriptionId).ProductDescriptionId
                    ,
                    ProductCategoryId = context.ProductCategory.Where(c => c.ProductCategoryName == productDetails.SelectedCategory).Select(c => c.ProductCategoryId).FirstOrDefault()
                    ,
                    ProductSEOId = context.SEO.Where(c => c.MetaTagTitle == productDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault()
                    ,
                    ProductGameId = context.ProductGame.Where(c => c.GameName == productDetails.SelectedGame).Select(c => c.ProductGameId).FirstOrDefault()
                    //, ProductSubCategoryId = context.ProductSubCategory.Where(c => c.ProductCategoryName == productDetails.ProductSubCategoryName).Select(c => c.ProductSubCategoryId).FirstOrDefault()
                    ,
                    ProductPriority = productDetails.ProductPriority
                    ,
                    ProductEnabled = productDetails.ProductEnabled
                    ,
                    ProductImageThumb = productDetails.ProductImageThumb
                };
                context.Product.Add(prod);

                if (productDetails.ProductPriceEU != null)
                {
                    ProductPrice prodPrice = new ProductPrice
                    {
                        ProductPriceId = Guid.NewGuid(),
                        Region = "Europe",
                        Price = productDetails.ProductPriceEU ?? 0,
                        ProductId = prod.ProductId,
                        ProductSale = productDetails.ProductSaleEU
                    };
                    context.ProductPrice.Add(prodPrice);
                }
                else if (productDetails.ProductPriceUS != null)
                {
                    ProductPrice prodPrice = new ProductPrice
                    {
                        ProductPriceId = Guid.NewGuid(),
                        Region = "US&Oceania",
                        Price = productDetails.ProductPriceUS ?? 0,
                        ProductId = prod.ProductId,
                        ProductSale = productDetails.ProductSaleUS
                    };
                    context.ProductPrice.Add(prodPrice);
                }
            }
            else
            {
                Product dbProduct = context.Product.Find(productDetails.ProductId);
                ProductDescription dbDescr = dbProduct.ProductDescription;
                if (dbDescr != null)
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
                    dbProduct.ProductImage = productDetails.ProductImage;
                    dbProduct.ProductCategoryId = context.ProductCategory.Where(c => c.ProductCategoryName == productDetails.SelectedCategory).Select(c => c.ProductCategoryId).FirstOrDefault();
                    dbProduct.ProductSEOId = context.SEO.Where(c => c.MetaTagTitle == productDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault();
                    dbProduct.ProductGameId = context.ProductGame.Where(c => c.GameName == productDetails.SelectedGame).Select(c => c.ProductGameId).FirstOrDefault();
                    //dbProduct.ProductSubCategoryId = context.ProductSubCategory.Where(c => c.ProductCategoryName == productDetails.ProductSubCategoryName).Select(c => c.ProductSubCategoryId).FirstOrDefault()
                    dbProduct.ProductPriority = productDetails.ProductPriority;
                    dbProduct.ProductEnabled = productDetails.ProductEnabled;
                    dbProduct.ProductImageThumb = productDetails.ProductImageThumb;
                }
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        public void SaveOrders(OrderDetails orderDetails)
        {
            if (orderDetails.OrderId.Equals(Guid.Empty))
            {
                OrderCustomFields orderCustomFields = new OrderCustomFields
                {
                    ShlCharacterName = orderDetails.ShlCharacterName,
                    ShlRealmName = orderDetails.ShlRealmName,
                    ShlFaction = orderDetails.ShlFaction,
                    ShlRegion = orderDetails.ShlRegion,
                    ShlBattleTag = orderDetails.ShlBattleTag,
                    PoeCharacterName = orderDetails.Poe_CharacterName,
                    PoeAccountName = orderDetails.Poe_AccountName,
                    ClassicCharacterName = orderDetails.Classic_CharacterName,
                    ClassicRealmName = orderDetails.Classic_RealmName,
                    ClassicFaction = orderDetails.Classic_Faction,
                    ClassicRegion = orderDetails.Classic_Region,
                    ClassicBattleTag = orderDetails.Classic_BattleTag
                };
                context.OrderCustomFields.Add(orderCustomFields);
                Orders orders = new Orders
                {
                    Discord = orderDetails.Discord,
                    Comment = orderDetails.Comments,
                    Email = orderDetails.Email,
                    PaymentMethod = orderDetails.PaymentMethod,
                    PaymentCode = orderDetails.PaymentCode,
                    Total = orderDetails.Total,
                    OrderStatus = orderDetails.OrderStatus,
                    Currency = orderDetails.Currency,
                    CustomerIP = orderDetails.CustomerIP,
                    UserAgent = orderDetails.UserAgent,
                    OrderCreateTime = orderDetails.OrderCreateTime,
                    OrderUpdateTime = orderDetails.OrderUpdateTime,
                    EmailSended = orderDetails.EmailSended,
                    EmailSendTime = orderDetails.EmailSendTime,
                    CarryCoinsSpent = orderDetails.CarryCoinsSpent,
                    CarryCoinsCollected = orderDetails.CarryCoinsCollected
                };
                context.Orders.Add(orders);
            }
            context.SaveChanges();
        }
        public void SaveSEO(SeoDetails seoDetails)
        {
            SEO dbSeo = context.SEO.Find(seoDetails.SEOId);
            if (dbSeo != null)
            {
                dbSeo.MetaTagTitle = seoDetails.MetaTagTitle;
                dbSeo.MetaTagDescription = seoDetails.MetaTagDescription;
                dbSeo.MetaTagKeyWords = seoDetails.MetaTagKeyWords;
                dbSeo.SEOTags = seoDetails.SEOTags;
                dbSeo.CustomTitle1 = seoDetails.CustomTitle1;
                dbSeo.CustomTitle2 = seoDetails.CustomTitle2;
                dbSeo.CustomImageTitle = seoDetails.CustomImageTitle;
                dbSeo.CustomImageAlt = seoDetails.CustomImageAlt;
                dbSeo.MetaRobots = seoDetails.MetaRobots;
                dbSeo.UrlKeyWord = seoDetails.UrlKeyWord;
                dbSeo.SEOImage = seoDetails.SEOImage;

                context.SaveChanges();
            }
        }
        public void SaveUsers(UsersDetails userDetails)
        {
            Users dbUsers = context.Users.Find(userDetails.UserId);
            if (dbUsers != null)
            {
                dbUsers.UserId = userDetails.UserId;
                dbUsers.UserName = userDetails.UserName;
                dbUsers.UserPassword = userDetails.UserPassword;
                dbUsers.Email = userDetails.Email;
                dbUsers.RoleId = userDetails.RoleId;

                context.SaveChanges();
            }
        }
        public void SaveTemplateOption(TemplateOptionDetails tempOptionsDetails)
        {
            TemplateOptions dbtemplateOptions = context.TemplateOptions.Find(tempOptionsDetails.TempOptionId);
            if (dbtemplateOptions != null)
            {
                dbtemplateOptions.OptionName = tempOptionsDetails.TempOptionName;
                dbtemplateOptions.OptionType = tempOptionsDetails.TempOptionType;

                foreach (TemplateOptionDetails.TempOptionParamsDetails item in tempOptionsDetails.TempOptionParamsDetailsCollection)
                {
                    TempOptionParams dbParam = context.TemplateOptions.Find(tempOptionsDetails.TempOptionId).TempOptionParams.Where(p => p.ParameterId == item.ParameterId).FirstOrDefault();
                    if (dbParam != null)
                    {
                        dbParam.ParameterName = item.ParameterName;
                        dbParam.ParameterPrice = item.ParameterPrice;
                        dbParam.ParameterTooltip = item.ParameterTooltip;
                        dbParam.ParameterSale = item.ParameterSale;
                    }
                }
                context.SaveChanges();
            }
        }
        public void SaveCustomers(CustomersDetails customersDetails)
        {
            Customers dbcustomers = context.Customers.Find(customersDetails.CustomerId);
            if (dbcustomers != null)
            {
                dbcustomers.Name = customersDetails.Name;
                dbcustomers.Password = customersDetails.Password;
                dbcustomers.RankId = customersDetails.RankId;
                dbcustomers.Email = customersDetails.Email;
                dbcustomers.CarryCoinsValue = customersDetails.CarryCoinsValue;

                context.SaveChanges();
            }
        }
        public void SaveRoles(RolesDetails rolesDetails)
        {
            Roles dbroles = context.Roles.Find(rolesDetails.RoleId);
            if (dbroles != null)
            {
                dbroles.RoleName = rolesDetails.RoleName;
            }
        }
        public void SaveContext()
        {
            context.SaveChanges();
        }
        public void RemoveHtmlBlock(Guid htmlBlockId)
        {
            var htmblockchildren = context.HtmlBlocksChildren.Where(c => c.SiteBlockId == htmlBlockId);
            context.HtmlBlocksChildren.RemoveRange(htmblockchildren);
            context.HtmlBlocks.Remove(context.HtmlBlocks.Find(htmlBlockId));
            context.SaveChanges();
        }
    }
}
