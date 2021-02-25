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
        public IEnumerable<ProductCategory> ProductCategory => context.ProductCategory;
        public IEnumerable<ProductSubCategory> ProductSubCategories => context.ProductSubCategory;

        #region SAVE
        public void SaveProductSubCategory(ProductSubCategoryDetails productSubCategoryDetails)
        {
            ProductSubCategory dbproductSubCategory = context.ProductSubCategory.Find(productSubCategoryDetails.ProductSubCategoryId);
            if (dbproductSubCategory != null)
            {
                dbproductSubCategory.ProductSubCategoryId = productSubCategoryDetails.ProductSubCategoryId;
                dbproductSubCategory.ProductCategoryName = productSubCategoryDetails.ProductCategoryName;
                dbproductSubCategory.CategoryDescription = productSubCategoryDetails.CategoryDescription;
                dbproductSubCategory.SubCategorySeoId = context.SEO.Where(c => c.MetaTagTitle == productSubCategoryDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault();
                dbproductSubCategory.ProductCategoryId = context.ProductCategory.Where(c => c.ProductCategoryName == productSubCategoryDetails.SelectedCategoryName).Select(c => c.ProductCategoryId).FirstOrDefault();
            }
            else
            {
                ProductSubCategory productSubCategorie = new ProductSubCategory
                {
                    ProductSubCategoryId = Guid.NewGuid(),
                    ProductCategoryName = productSubCategoryDetails.ProductCategoryName,
                    CategoryDescription = productSubCategoryDetails.CategoryDescription,
                    SubCategorySeoId = context.SEO.Where(c => c.MetaTagTitle == productSubCategoryDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault(),
                    ProductCategoryId = context.ProductCategory.Where(c => c.ProductCategoryName == productSubCategoryDetails.SelectedCategoryName).Select(c => c.ProductCategoryId).FirstOrDefault()
                };
                context.ProductSubCategory.Add(productSubCategorie);
            }
            context.SaveChanges();
        }
        public void SaveProductCategory(ProductCategoryDetails productCategoryDetails)
        {
            ProductCategory dbproductCategories = context.ProductCategory.Find(productCategoryDetails.ProductCategoryId);
            if (dbproductCategories != null)
            {
                dbproductCategories.ProductCategoryId = productCategoryDetails.ProductCategoryId;
                dbproductCategories.ProductCategoryName = productCategoryDetails.ProductCategoryName;
                dbproductCategories.CategoryDescription = productCategoryDetails.CategoryDescription;
                dbproductCategories.CategorySeoId = context.SEO.Where(c => c.MetaTagTitle == productCategoryDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault();
                dbproductCategories.ProductGameId = context.ProductGame.Where(c => c.GameName == productCategoryDetails.SelectedGame).Select(c => c.ProductGameId).FirstOrDefault();

            }
            else
            {
                ProductCategory productCategories = new ProductCategory()
                {
                    ProductCategoryId = Guid.NewGuid(),
                    ProductCategoryName = productCategoryDetails.ProductCategoryName,
                    CategoryDescription = productCategoryDetails.CategoryDescription,
                    CategorySeoId = context.SEO.Where(c => c.MetaTagTitle == productCategoryDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault(),
                    ProductGameId = context.ProductGame.Where(c => c.GameName == productCategoryDetails.SelectedGame).Select(c => c.ProductGameId).FirstOrDefault()
                };
                context.ProductCategory.Add(productCategories);
            }
            context.SaveChanges();
        }
        public void SaveGame(ProductGameDetails productGameDetails)
        {
            ProductGame dbproductGame = context.ProductGame.Find(productGameDetails.ProductGameId);
            if (dbproductGame != null)
            {
                dbproductGame.GameName = productGameDetails.GameName;
                dbproductGame.GameDescription = productGameDetails.GameDescription;
                dbproductGame.GameShortUrl = productGameDetails.GameShortUrl;
                dbproductGame.GameSeoId = context.SEO.Where(c => c.MetaTagTitle == productGameDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault();
            }
            else
            {
                ProductGame productGame = new ProductGame()
                {
                    ProductGameId = Guid.NewGuid(),
                    GameName = productGameDetails.GameName,
                    GameDescription = productGameDetails.GameDescription,
                    GameShortUrl = productGameDetails.GameShortUrl,
                    GameSeoId = context.SEO.Where(c => c.MetaTagTitle == productGameDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault()
                };
                context.ProductGame.Add(productGame);
            }

            context.SaveChanges();
        }

        //foreach (ProductGameDetails.ProductCategoryDetails item in productGameDetails.ProductCategoryDetailsCollection)
        //{
        //    ProductCategory dbProductCategory = context.ProductGame.Find(productGameDetails.ProductGameId).ProductCategory.Where(p => p.ProductCategoryId == item.ProductCategoryId).FirstOrDefault();
        //    if (dbProductCategory != null)
        //    {
        //        dbProductCategory.ProductCategoryName = item.ProductCategoryName;
        //        dbProductCategory.ProductGameId = item.ProductGameId;
        //        dbProductCategory.CategoryDescription = item.CategoryDescription;
        //        dbProductCategory.ProductSubCategoryId = item.ProductSubCategoryId;
        //        dbProductCategory.CategorySeoId = item.CategorySeoId;
        //    }
        //}

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
                    else
                    {
                        dbhtmlBlocksChildren = new HtmlBlocksChildren { };
                        dbhtmlBlocksChildren.SiteBlockChildsId = item.SiteBlockChildsId;
                        dbhtmlBlocksChildren.SiteBlockId = dbhtmlBlocks.SiteBlockId;
                        dbhtmlBlocksChildren.Text = item.Text;
                        dbhtmlBlocksChildren.Title = item.Title;
                        dbhtmlBlocksChildren.Image = item.Image;
                        dbhtmlBlocksChildren.CSSClass = item.CSSClass;
                        dbhtmlBlocksChildren.ChildOrder = item.ChildOrder;

                        context.HtmlBlocksChildren.Add(dbhtmlBlocksChildren);
                    }

                }
            }
            else
            {
                dbhtmlBlocks = new HtmlBlocks();
                dbhtmlBlocks.SiteBlockId = Guid.NewGuid();
                dbhtmlBlocks.ParentCSSClass = htmlBlockDetails.ParentCSSClass;
                dbhtmlBlocks.ParentTitle = htmlBlockDetails.ParentTitle;
                dbhtmlBlocks.ChildCSSClass = htmlBlockDetails.ChildCSSClass;
                dbhtmlBlocks.SitePage = htmlBlockDetails.SitePage;
                dbhtmlBlocks.Order = htmlBlockDetails.Order;

                if (htmlBlockDetails.HtmlBlockChildDetailsCollection != null)
                {
                    foreach (HtmlBlockDetails.HtmlBlockChildrenDetails item in htmlBlockDetails.HtmlBlockChildDetailsCollection)
                    {
                        HtmlBlocksChildren dbhtmlBlocksChildren = new HtmlBlocksChildren { };
                        dbhtmlBlocksChildren.SiteBlockChildsId = Guid.NewGuid();
                        dbhtmlBlocksChildren.SiteBlockId = dbhtmlBlocks.SiteBlockId;
                        dbhtmlBlocksChildren.Text = item.Text;
                        dbhtmlBlocksChildren.Title = item.Title;
                        dbhtmlBlocksChildren.Image = item.Image;
                        dbhtmlBlocksChildren.CSSClass = item.CSSClass;
                        dbhtmlBlocksChildren.ChildOrder = item.ChildOrder;

                        context.HtmlBlocksChildren.Add(dbhtmlBlocksChildren);

                    }
                }
                context.HtmlBlocks.Add(dbhtmlBlocks);

            }
            context.SaveChanges();
        }
        public void SaveArticle(ArticleDetails articlesDetails)
        {
            Article dbArticle = context.Article.Find(articlesDetails.ArticleId);
            if (dbArticle != null)
            {
                dbArticle.Title = articlesDetails.Title;
                dbArticle.ShortDescription = articlesDetails.ShortDescription;
                dbArticle.Description = articlesDetails.Description;
                dbArticle.ReadTime = articlesDetails.ReadTime;
                dbArticle.Tags = articlesDetails.Tags;
                dbArticle.ImagePath = articlesDetails.ImagePath;
                dbArticle.Enabled = articlesDetails.Enabled;
                dbArticle.Rating = articlesDetails.Rating;
                dbArticle.SEOId = context.SEO.Where(c => c.MetaTagTitle == articlesDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault();
                dbArticle.ProductGameId = context.ProductGame.Where(c => c.GameName == articlesDetails.SelectedGame).Select(c => c.ProductGameId).FirstOrDefault();
            }
            else
            {
                Article article = new Article
                {
                    ArticleId = Guid.NewGuid(),
                    Title = articlesDetails.Title,
                    ShortDescription = articlesDetails.ShortDescription,
                    Description = articlesDetails.Description,
                    ReadTime = articlesDetails.ReadTime,
                    Tags = articlesDetails.Tags,
                    ImagePath = articlesDetails.ImagePath,
                    Enabled = articlesDetails.Enabled,
                    Rating = articlesDetails.Rating,
                    ArticlePostTime = DateTime.Now,
                    SEOId = context.SEO.Where(c => c.MetaTagTitle == articlesDetails.SelectedMetaTagTitle).Select(c => c.SEOId).FirstOrDefault(),
                    ProductGameId = context.ProductGame.Where(c => c.GameName == articlesDetails.SelectedGame).Select(c => c.ProductGameId).FirstOrDefault()

                };

                context.Article.Add(article);
            }

            context.SaveChanges();
        }
        public void SaveRanks(RankDetails rankDetails)
        {
            Ranks dbRanks = context.Ranks.Find(rankDetails.RankId);
            if (dbRanks != null)
            {
                dbRanks.Name = rankDetails.Name;
                dbRanks.Sale = rankDetails.Sale;
            }
            else
            {
                Ranks ranks = new Ranks()
                {
                    RankId = Guid.NewGuid(),
                    Name = rankDetails.Name,
                    Sale = rankDetails.Sale
                };
                context.Ranks.Add(ranks);
            }
            context.SaveChanges();
        }
        public void SaveProductOption(ProductOptionDetails productOptionDetails)
        {
            ProductOptions dbProductOption = context.ProductOptions.Find(productOptionDetails.OptionId);
            if (dbProductOption != null)
            {
                dbProductOption.OptionName = productOptionDetails.OptionName;
                dbProductOption.OptionType = productOptionDetails.OptionType;
                dbProductOption.OptionProductId = productOptionDetails.OptionProductId;
                if (productOptionDetails.OptionParent is null)
                {
                    dbProductOption.OptionParentId = null;
                }
                else
                {
                    dbProductOption.OptionParentId = ProductOptions.Where(po => po.OptionName == productOptionDetails.OptionParent).Select(po=>po.OptionId).FirstOrDefault();
                }
            }
            foreach (ProductOptionDetails.ProductOptionParamsDetails item in productOptionDetails.ParamCollection)
            {
                var parentOption = context.ProductOptions.Find(dbProductOption.OptionParentId);

                ProductOptionParams dbParam = context.ProductOptions.Find(productOptionDetails.OptionId).ProductOptionParams.Where(p => p.ParameterId == item.ParameterId).FirstOrDefault();
                if (dbParam != null)
                {
                    dbParam.ParameterName = item.Paramname;
                    dbParam.ParameterPrice = item.ParamPrice;
                    dbParam.ParameterTooltip = item.ParamTooltip;
                    dbParam.ParameterSale = item.Sale;
                    if (dbProductOption.OptionParentId is null)
                    {
                        dbParam.ParameterParentId =  null;
                    }
                    else
                    {
                        dbParam.ParameterParentId = parentOption.ProductOptionParams.Where(p => p.ParameterName == item.ParentParam).Select(p => p.ParameterId).FirstOrDefault();
                    }
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
                ProductPrice dbPricesEU = context.ProductPrice.Where(p => p.ProductId == productDetails.ProductId && p.Region == "Europe").FirstOrDefault();

                ProductPrice dbPricesUS = context.ProductPrice.Where(p => p.ProductId == productDetails.ProductId && p.Region == "US&Oceania").FirstOrDefault();

                if (productDetails.ProductPriceEU != null && dbPricesEU != null)
                {
                    dbPricesEU.Price = productDetails.ProductPriceEU ?? 0;
                    dbPricesEU.ProductSale = productDetails.ProductSaleEU;
                }
                else if (productDetails.ProductPriceEU != null && dbPricesEU == null)
                {
                    ProductPrice prodPrice = new ProductPrice
                    {
                        ProductPriceId = Guid.NewGuid(),
                        Region = "Europe",
                        Price = productDetails.ProductPriceEU ?? 0,
                        ProductId = productDetails.ProductId,
                        ProductSale = productDetails.ProductSaleEU
                    };
                    context.ProductPrice.Add(prodPrice);
                }

                if (productDetails.ProductPriceUS != null && dbPricesUS != null)
                {
                    dbPricesUS.Price = productDetails.ProductPriceUS ?? 0;
                    dbPricesUS.ProductSale = productDetails.ProductPriceUS;
                }
                else if (productDetails.ProductPriceUS != null && dbPricesUS == null)
                {
                    ProductPrice prodPrice = new ProductPrice
                    {
                        ProductPriceId = Guid.NewGuid(),
                        Region = "US&Oceania",
                        Price = productDetails.ProductPriceUS ?? 0,
                        ProductId = productDetails.ProductId,
                        ProductSale = productDetails.ProductPriceUS
                    };
                    context.ProductPrice.Add(prodPrice);
                }

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
            context.SaveChanges();
        }
        public void SaveOrders(OrderDetails orderDetails)
        {
            if (orderDetails.OrderId.Equals(Guid.Empty))
            {
                OrderCustomFields orderCustomFields = new OrderCustomFields
                {
                    OrderCustomFieldsId = Guid.NewGuid(),
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
                    OrderId = Guid.NewGuid(),
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
                    EmailSended = orderDetails.EmailSended,
                    EmailSendTime = orderDetails.EmailSendTime,
                    CarryCoinsSpent = orderDetails.CarryCoinsSpent,
                    CarryCoinsCollected = orderDetails.CarryCoinsCollected
                };
                context.Orders.Add(orders);
            }
            else
            {
                Orders dbOrder = context.Orders.Find(orderDetails.OrderId);
                OrderCustomFields dbOrderCustomFields = dbOrder.OrderCustomFields;
                if (dbOrderCustomFields != null)
                {
                    dbOrderCustomFields.ShlCharacterName = orderDetails.ShlCharacterName;
                    dbOrderCustomFields.ShlRealmName = orderDetails.ShlRealmName;
                    dbOrderCustomFields.ShlFaction = orderDetails.ShlFaction;
                    dbOrderCustomFields.ShlRegion = orderDetails.ShlRegion;
                    dbOrderCustomFields.ShlBattleTag = orderDetails.ShlBattleTag;
                    dbOrderCustomFields.PoeCharacterName = orderDetails.Poe_CharacterName;
                    dbOrderCustomFields.PoeAccountName = orderDetails.Poe_AccountName;
                    dbOrderCustomFields.ClassicCharacterName = orderDetails.Classic_CharacterName;
                    dbOrderCustomFields.ClassicRealmName = orderDetails.Classic_RealmName;
                    dbOrderCustomFields.ClassicFaction = orderDetails.Classic_Faction;
                    dbOrderCustomFields.ClassicRegion = orderDetails.Classic_Region;
                    dbOrderCustomFields.ClassicBattleTag = orderDetails.Classic_BattleTag;
                }
                if (dbOrder != null)
                {
                    dbOrder.Discord = orderDetails.Discord;
                    dbOrder.Comment = orderDetails.Comments;
                    dbOrder.Email = orderDetails.Email;
                    dbOrder.PaymentMethod = orderDetails.PaymentMethod;
                    dbOrder.PaymentCode = orderDetails.PaymentCode;
                    dbOrder.Total = orderDetails.Total;
                    dbOrder.OrderStatus = orderDetails.OrderStatus;
                    dbOrder.Currency = orderDetails.Currency;
                    dbOrder.CustomerIP = orderDetails.CustomerIP;
                    dbOrder.UserAgent = orderDetails.UserAgent;
                    dbOrder.EmailSended = orderDetails.EmailSended;
                    dbOrder.EmailSendTime = orderDetails.EmailSendTime;
                    dbOrder.CarryCoinsSpent = orderDetails.CarryCoinsSpent;
                    dbOrder.CarryCoinsCollected = orderDetails.CarryCoinsCollected;
                }
            }
            context.SaveChanges();
        }
        public void SaveSEO(SeoDetails seoDetails)
        {
            if (seoDetails.SEOId.Equals(Guid.Empty))
            {
                SEO dbSeo = new SEO
                {
                    SEOId = Guid.NewGuid(),
                    MetaTagTitle = seoDetails.MetaTagTitle,
                    MetaTagDescription = seoDetails.MetaTagDescription,
                    MetaTagKeyWords = seoDetails.MetaTagKeyWords,
                    SEOTags = seoDetails.SEOTags,
                    CustomTitle1 = seoDetails.CustomTitle1,
                    CustomTitle2 = seoDetails.CustomTitle2,
                    CustomImageTitle = seoDetails.CustomImageTitle,
                    CustomImageAlt = seoDetails.CustomImageAlt,
                    MetaRobots = seoDetails.MetaRobots,
                    UrlKeyWord = seoDetails.UrlKeyWord,
                    SEOImage = seoDetails.SEOImage
                };
                context.SEO.Add(dbSeo);
            }
            else
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
                }
            }

            context.SaveChanges();
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


            }
            else
            {
                Users user = new Users
                {
                    UserId = Guid.NewGuid(),
                    UserName = userDetails.UserName,
                    UserPassword = userDetails.UserPassword,
                    Email = userDetails.Email,
                    RoleId = userDetails.RoleId,
                };
                context.Users.Add(user);
            }
            context.SaveChanges();
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

            }
            else
            {
                dbtemplateOptions = new TemplateOptions();
                dbtemplateOptions.OptionId = Guid.NewGuid();
                dbtemplateOptions.OptionName = tempOptionsDetails.TempOptionName;
                dbtemplateOptions.OptionType = tempOptionsDetails.TempOptionType;

                if (tempOptionsDetails.TempOptionParamsDetailsCollection != null)
                {
                    foreach (TemplateOptionDetails.TempOptionParamsDetails item in tempOptionsDetails.TempOptionParamsDetailsCollection)
                    {
                        TempOptionParams dbParam = new TempOptionParams { };
                        dbParam.ParameterId = Guid.NewGuid();
                        dbParam.ParentOptionId = dbtemplateOptions.OptionId;
                        dbParam.ParameterName = item.ParameterName;
                        dbParam.ParameterPrice = item.ParameterPrice;
                        dbParam.ParameterTooltip = item.ParameterTooltip;
                        dbParam.ParameterSale = item.ParameterSale;
                    }
                }
                context.TemplateOptions.Add(dbtemplateOptions);

            }
            context.SaveChanges();
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
            }
            else
            {
                Customers customers = new Customers
                {
                    CustomerId = Guid.NewGuid(),
                    Name = customersDetails.Name,
                    Password = customersDetails.Password,
                    RankId = customersDetails.RankId,
                    Email = customersDetails.Email,
                    CarryCoinsValue = customersDetails.CarryCoinsValue,
                };
                context.Customers.Add(customers);

            }
            context.SaveChanges();
        }
        public void SaveRoles(RolesDetails rolesDetails)
        {
            Roles dbroles = context.Roles.Find(rolesDetails.RoleId);
            if (dbroles != null)
            {
                dbroles.RoleName = rolesDetails.RoleName;
            }
            else
            {
                Roles roles = new Roles
                {
                    RoleName = rolesDetails.RoleName
                };
                context.Roles.Add(roles);
            }
            context.SaveChanges();
        }
        public void SaveContext()
        {
            context.SaveChanges();
        }

        #endregion
        public void RemoveHtmlBlock(Guid htmlBlockId)
        {
            var htmblockchildren = context.HtmlBlocksChildren.Where(c => c.SiteBlockId == htmlBlockId);
            context.HtmlBlocksChildren.RemoveRange(htmblockchildren);
            context.HtmlBlocks.Remove(context.HtmlBlocks.Find(htmlBlockId));
            context.SaveChanges();
        }
        public void RemoveRanks(Guid RankId)
        {
            context.Ranks.Remove(context.Ranks.Find(RankId));
            context.SaveChanges();
        }
        public void RemoveProductSubCategory(Guid ProductSubCategoryId)
        {
            context.ProductSubCategory.Remove(context.ProductSubCategory.Find(ProductSubCategoryId));
            context.SaveChanges();
        }
        public void RemoveProductCategory(Guid ProductCategoryId)
        {
            context.ProductCategory.Remove(context.ProductCategory.Find(ProductCategoryId));
            context.SaveChanges();
        }
        public void RemoveArticle(Guid ArticleId)
        {
            context.Article.Remove(context.Article.Find(ArticleId));
            context.SaveChanges();
        }
        public void RemoveGame(Guid ProductGameId)
        {
            context.ProductGame.Remove(context.ProductGame.Find(ProductGameId));
            context.SaveChanges();
        }
        public void RemoveUsers(Guid UserId)
        {
            context.Users.Remove(context.Users.Find(UserId));
            context.SaveChanges();
        }
        public void RemoveRoles(Guid RoleId)
        {
            context.Roles.Remove(context.Roles.Find(RoleId));
            context.SaveChanges();
        }
        public void RemoveCustomers(Guid CustomerId)
        {
            context.Customers.Remove(context.Customers.Find(CustomerId));
            context.SaveChanges();
        }

        //TODO: ORDERS
        //public void RemoveOrders(Guid OrderId)
        //{
        //    var orderCustomFields = context.OrderCustomFields.Where(c => c.OrderId == OrderId);
        //    context.OrderCustomFields.RemoveRange(orderCustomFields);
        //    context.Orders.Remove(context.Orders.Find(OrderId));
        //    context.SaveChanges();
        //}
        public void RemoveSEO(Guid SEOId)
        {
            context.SEO.Remove(context.SEO.Find(SEOId));
            context.SaveChanges();
        }
        public void RemoveTemplateOption(Guid OptionId)
        {
            var templateOprionParam = context.TempOptionParams.Where(c => c.ParentOptionId == OptionId);
            context.TempOptionParams.RemoveRange(templateOprionParam);
            context.TemplateOptions.Remove(context.TemplateOptions.Find(OptionId));
            context.SaveChanges();
        }
        public void RemoveProduct(Guid ProductId)
        {
            //Description
            var product = context.Product.Where(c => c.ProductId == ProductId).FirstOrDefault();
            var description = context.ProductDescription.Where(c => c.ProductDescriptionId == product.ProductDescriptionId).FirstOrDefault();
            context.ProductDescription.Remove(description);
            //Option  +  //ParamOption
            var selectedOptions = context.ProductOptions.Where(c => c.OptionProductId == ProductId);

            //var SelectparamOption = context.ProductOptionParams.Where(c => c.ParentOptionId == SelectOption.OptionId).FirstOrDefault();
            //var Params = context.ProductOptionParams.Where(c => c.ParameterParentId == SelectparamOption.ParameterId);
            foreach(var opt in selectedOptions)
            {
                var options = context.ProductOptions.Where(c => c.OptionParentId == opt.OptionId);
                if (options != null)
                {
                    foreach (var childOpt in options)
                    {
                        childOpt.OptionParentId = null;
                        var childOptionParam = context.ProductOptionParams.Where(c => c.ParentOptionId == childOpt.OptionId);
                        foreach (var param in childOptionParam)
                        {
                            param.ParameterParentId = null;
                        }
                    }
                }
                var OptionParams = context.ProductOptionParams.Where(c => c.ParentOptionId == opt.OptionId);
                foreach (var param in OptionParams)
                {
                    context.ProductOptionParams.Remove(param);
                }
                context.ProductOptions.Remove(opt);
            }

            //Price
            var price = context.ProductPrice.Where(c => c.ProductId == ProductId);
            context.ProductPrice.RemoveRange(price);
            //Product
            context.Product.Remove(product);


            //var paramOption = context.ProductOptionParams.Where(c => c.ParentOptionId == Option.OptionId);
            //context.ProductOptionParams.RemoveRange(paramOption);
            //context.ProductOptions.Remove(Option);
        }
    }
}
