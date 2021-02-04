using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

namespace WowCarry.WebUI.Controllers
{
    [Authorize(Roles = "Root Admin,Agent,Admin,Price Admin")]
    public class AdminController : Controller
    {
        IEntityRepository EntityRepository;
        public AdminController(IEntityRepository entityRepo)
        {
            EntityRepository = entityRepo;
        }
        public ViewResult Admin()
        {
            return View();
        }
        public ViewResult List(string type)
        {
            switch (type)
            {
                case "Product":
                    return View("List" + type, EntityRepository.Products);
                case "TemplateOption":
                    return View("List" + type, EntityRepository.TemplateOptions);
                case "ProductGame":
                    return View("List" + type, EntityRepository.Games);
                case "HtmlBlocks":
                    return View("List" + type, EntityRepository.HtmlBlocks);
                case "SEO":
                    return View("List" + type, EntityRepository.SEOs);
                case "Users":
                    return View("List" + type, EntityRepository.Users);
                case "Ranks":
                    return View("List" + type, EntityRepository.Ranks);
                case "Customers":
                    return View("List" + type, EntityRepository.Customers);
                case "Roles":
                    return View("List" + type, EntityRepository.Roles);
                case "Orders":
                    return View("List" + type, EntityRepository.Orders);
                default: return View("Admin");
            }
        }

        [Authorize(Roles = "Root Admin,Admin,Price Admin")]
        public ViewResult CreateEdit(Guid? Id, string type, string game = null)
        {
            switch (type)
            {
                case "Product":
                    Product prod = EntityRepository.Products.Where(p => p.ProductId == Id).FirstOrDefault();
                    if (prod != null)
                    {
                        return View("Save" + type, new ProductDetails
                        {
                            Product = prod,
                            ProductId = prod.ProductId,
                            GamesList = new SelectList(EntityRepository.Games.Select(g => g.GameName), prod?.ProductGame.GameName ?? "Select Game"),
                            SelectedGame = prod?.ProductGame.GameName,
                            CategoriesList = new SelectList(EntityRepository.Games.Where(g => game == null || g.GameName == game).SelectMany(g => g.ProductCategory).Select(p => p.ProductCategoryName), prod?.ProductCategory.ProductCategoryName ?? "Select Category"),
                            SelectedCategory = prod?.ProductCategory.ProductCategoryName,
                            MetaTagTitleList = new SelectList(EntityRepository.SEOs.Select(s => s.MetaTagTitle), prod?.SEO.MetaTagTitle ?? "Select Meta tag title from List"),
                            SelectedMetaTagTitle = prod?.SEO.MetaTagTitle,
                            ProductOptions = prod.ProductOptions,
                            ProductName = prod.ProductName,
                            InStock = prod.InStock,
                            PreOrder = prod.PreOrder,
                            ProductEnabled = prod.ProductEnabled,
                            ProductQuantity = prod.ProductQuantity,
                            ProductImageThumb = prod.ProductImageThumb,
                            ProductImage = prod.ProductImage,
                            ProductPriority = prod.ProductPriority,
                            ProductPriceEU = prod.ProductPrice.Where(p => p.Region == "EU").Select(p => p.Price).FirstOrDefault(),
                            ProductPriceUS = prod.ProductPrice.Where(p => p.Region == "US").Select(p => p.Price).FirstOrDefault(),
                            ProductSaleEU = prod.ProductPrice.Where(p => p.Region == "EU").Select(p => p.ProductSale).FirstOrDefault(),
                            ProductSaleUS = prod.ProductPrice.Where(p => p.Region == "US").Select(p => p.ProductSale).FirstOrDefault(),
                            Description = prod.ProductDescription.Description,
                            SubDescriptionTitle1 = prod.ProductDescription.SubDescriptionTitle1,
                            SubDescription1 = prod.ProductDescription.SubDescription1,
                            SubDescriptionTitle2 = prod.ProductDescription.SubDescriptionTitle2,
                            SubDescription2 = prod.ProductDescription.SubDescription2,
                            SubDescriptionTitle3 = prod.ProductDescription.SubDescriptionTitle3,
                            SubDescription3 = prod.ProductDescription.SubDescription3,
                            SubDescriptionTitle4 = prod.ProductDescription.SubDescriptionTitle4,
                            SubDescription4 = prod.ProductDescription.SubDescription4,
                            SubDescriptionTitle5 = prod.ProductDescription.SubDescriptionTitle5,
                            SubDescription5 = prod.ProductDescription.SubDescription5,
                        });
                    }
                    else
                    {
                        return View("Save" + type, new ProductDetails
                        {
                            GamesList = new SelectList(EntityRepository.Games.Select(g => g.GameName), "Select Game"),
                            CategoriesList = new SelectList(EntityRepository.Games.Where(g => game == null || g.GameName == game).SelectMany(g => g.ProductCategory).Select(p => p.ProductCategoryName), "Select Category"),
                            MetaTagTitleList = new SelectList(EntityRepository.SEOs.Select(s => s.MetaTagTitle), "Select Meta tag title from List"),
                        });
                    }
                case "TemplateOptions":
                    TemplateOptions templateOptions = EntityRepository.TemplateOptions.Where(p => p.OptionId == Id).FirstOrDefault();
                    if (templateOptions != null)
                    {
                        return View("Save" + type, new TemplateOptionDetails
                        {
                            TempOptionId = templateOptions.OptionId,
                            TempOptionName = templateOptions.OptionName,
                            TempOptionType = templateOptions.OptionType,
                            TempOptionParamsDetailsCollection = TemplateOptionDetails.PopulateTempOptionParamsDetailsCollection(templateOptions)
                        });
                    }
                    else
                    {
                        return View("Save" + type, new TemplateOptionDetails { });

                    }
                case "ProductGame":
                    ProductGame productGame = EntityRepository.Games.Where(p => p.ProductGameId == Id).FirstOrDefault();
                    if (productGame != null)
                    {
                        return View("Save" + type, new ProductGameDetails
                        {
                            ProductGameId = productGame.ProductGameId,
                            GameName = productGame.GameName,
                            GameDescription = productGame.GameDescription,
                            GameShortUrl = productGame.GameShortUrl,
                            GameSeoId = productGame.GameSeoId,
                            ProductCategoryDetailsCollection = ProductGameDetails.PopulateProductGameDetails(productGame)

                        });
                    }
                    else
                    {
                        return View("Save" + type, new ProductGameDetails { });

                    }
                case "HtmlBlocks":
                    HtmlBlocks siteBlock = EntityRepository.HtmlBlocks.Where(p => p.SiteBlockId == Id).FirstOrDefault();
                    if (siteBlock != null)
                    {
                        return View("Save" + type, new HtmlBlockDetails
                        {
                            SiteBlockId = siteBlock.SiteBlockId,
                            ParentTitle = siteBlock.ParentTitle,
                            ParentCSSClass = siteBlock.ParentCSSClass,
                            ChildCSSClass = siteBlock.ChildCSSClass,
                            SitePage = siteBlock.SitePage,
                            Order = siteBlock.Order,
                            HtmlBlockChildDetailsCollection = HtmlBlockDetails.PopulateHtmlBlockCollection(siteBlock)

                        });
                    }
                    else
                    {
                        return View("Save" + type, new HtmlBlockDetails { });

                    }
                case "SEO":
                    SEO seo = EntityRepository.SEOs.Where(p => p.SEOId == Id).FirstOrDefault();
                    if (seo != null)
                    {
                        return View("Save" + type, new SeoDetails
                        {
                            SEOId = seo.SEOId,
                            MetaTagTitle = seo.MetaTagTitle,
                            MetaTagDescription = seo.MetaTagDescription,
                            MetaTagKeyWords = seo.MetaTagKeyWords,
                            SEOTags = seo.SEOTags,
                            CustomTitle1 = seo.CustomTitle1,
                            CustomTitle2 = seo.CustomTitle2,
                            CustomImageTitle = seo.CustomImageTitle,
                            CustomImageAlt = seo.CustomImageAlt,
                            MetaRobots = seo.MetaRobots,
                            UrlKeyWord = seo.UrlKeyWord,
                            SEOImage = seo.SEOImage
                        });
                    }
                    else
                    {
                        return View("Save" + type, new SeoDetails { });

                    }
                case "Users":
                    Users user = EntityRepository.Users.Where(p => p.UserId == Id).FirstOrDefault();
                    if (user != null)
                    {
                        return View("Save" + type, new UsersDetails
                        {
                            UserId = user.UserId,
                            UserName = user.UserName,
                            UserPassword = user.UserPassword,
                            Email = user.Email,
                            RoleId = user.RoleId
                        });
                    }
                    else
                    {
                        return View("Save" + type, new UsersDetails { });

                    }
                case "Ranks":
                    Ranks ranks = EntityRepository.Ranks.Where(p => p.RankId == Id).FirstOrDefault();
                    if (ranks != null)
                    {
                        return View("Save" + type, new RankDetails
                        {
                            Name = ranks.Name,
                            Sale = ranks.Sale
                        });
                    }
                    else
                    {
                        return View("Save" + type, new RankDetails { });

                    }
                case "Customers":
                    Customers customers = EntityRepository.Customers.Where(p => p.CustomerId == Id).FirstOrDefault();
                    if (customers != null)
                    {
                        return View("Save" + type, new CustomersDetails
                        {
                            Name = customers.Name,
                            Password = customers.Password,
                            Email = customers.Email,
                            CarryCoinsValue = customers.CarryCoinsValue

                        });
                    }
                    else
                    {
                        return View("Save" + type, new CustomersDetails { });

                    }
                case "Roles":
                    Roles roles = EntityRepository.Roles.Where(p => p.RoleId == Id).FirstOrDefault();
                    if (roles != null)
                    {
                        return View("Save" + type, new RolesDetails
                        {
                            RoleName = roles.RoleName
                        });
                    }
                    else
                    {
                        return View("Save" + type, new RolesDetails { });

                    }
                case "Orders":
                    Orders orders = EntityRepository.Orders.Where(p => p.OrderId == Id).FirstOrDefault();
                    if (orders != null)
                    {
                        return View("Save" + type, new OrderDetails
                        {
                            Discord = orders.Discord,
                            Comments = orders.Comment,
                            Email = orders.Email,
                            PaymentMethod = orders.PaymentMethod,
                            PaymentCode = orders.PaymentCode,
                            Total = orders.Total,
                            OrderStatus = orders.OrderStatus,
                            Currency = orders.Currency,
                            CustomerIP = orders.CustomerIP,
                            UserAgent = orders.UserAgent,
                            OrderCreateTime = orders.OrderCreateTime,
                            OrderUpdateTime = orders.OrderUpdateTime,
                            EmailSended = orders.EmailSended,
                            EmailSendTime = orders.EmailSendTime,
                            CarryCoinsSpent = orders.CarryCoinsSpent,
                            CarryCoinsCollected = orders.CarryCoinsCollected,
                            ShlCharacterName = orders.OrderCustomFields.ShlCharacterName,
                            ShlRealmName = orders.OrderCustomFields.ShlRealmName,
                            ShlFaction = orders.OrderCustomFields.ShlFaction,
                            ShlRegion = orders.OrderCustomFields.ShlRegion,
                            ShlBattleTag = orders.OrderCustomFields.ShlBattleTag,
                            Poe_CharacterName = orders.OrderCustomFields.PoeCharacterName,
                            Poe_AccountName = orders.OrderCustomFields.PoeAccountName,
                            Classic_CharacterName = orders.OrderCustomFields.ClassicCharacterName,
                            Classic_RealmName = orders.OrderCustomFields.ClassicRealmName,
                            Classic_Faction = orders.OrderCustomFields.ClassicFaction,
                            Classic_Region = orders.OrderCustomFields.ClassicRegion,
                            Classic_BattleTag = orders.OrderCustomFields.ClassicBattleTag
                        });
                    }
                    else
                    {
                        return View("Save" + type, new OrderDetails { });
                    }
                default: return View("Admin");
            }
        }

        [Authorize(Roles = "Root Admin,Admin,Price Admin")]
        public ViewResult ProductOptionsEdit(Guid productId)
        {
            var selectedProduct = EntityRepository.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            var ProductOptions = EntityRepository.ProductOptions.Where(o => o.OptionProductId == productId);
            List<ProductOptionDetails> Options = new List<ProductOptionDetails>();

            if (ProductOptions.Any())
            {
                foreach (var opt in ProductOptions)
                {
                    var templateOption = EntityRepository.TemplateOptions.Where(t => t.OptionName == opt.OptionName).FirstOrDefault();
                    var paramParent = selectedProduct.ProductOptions.Where(o => o.OptionId == opt.OptionParentId).FirstOrDefault();

                    Options.Add(new ProductOptionDetails
                    {
                        OptionId = opt.OptionId,
                        OptionName = opt.OptionName,
                        OptionType = opt.OptionType,
                        ParentOptionList = new SelectList(selectedProduct.ProductOptions.Where(o => o.OptionId != opt.OptionId).Select(o => o.OptionName), opt.OptionParentId.HasValue ? opt.ProductOptionsParent.OptionName : "Empty"),
                        ParamList = new SelectList(templateOption.TempOptionParams.Select(p => p.ParameterName), "Empty"),
                        ParamCollection = ProductOptionDetails.PopulateParamCollection(opt, selectedProduct.ProductOptions.Where(o => o.OptionId == opt.OptionParentId).SelectMany(p => p.ProductOptionParams).Select(pr => pr.ParameterName), paramParent)
                    });
                }
            }

            ProductOptionsViewModel result = new ProductOptionsViewModel
            {
                ProductOptions = Options,
                TemplateOptionList = new SelectList(EntityRepository.TemplateOptions.Select(o => o.OptionName), "Select Option from templates"),
                ProductId = productId,
                ProductName = EntityRepository.Products.Where(p => p.ProductId == productId).FirstOrDefault().ProductName
            };
            return View(result);
        }
        #region POST
        [HttpPost]
        public void PopulateSelectLists(Guid optionId, Guid prodId, string parentName)
        {
            Product selectedProduct = EntityRepository.Products.Where(p => p.ProductId == prodId).FirstOrDefault();
            ProductOptions parent = selectedProduct.ProductOptions.Where(o => o.OptionName == parentName).FirstOrDefault();
            ProductOptions option = EntityRepository.ProductOptions.Where(o => o.OptionId == optionId).FirstOrDefault();
            if (parent != null)
            {
                option.OptionParentId = parent.OptionId;
                EntityRepository.SaveContext();
            }
            else
            {
                option.OptionParentId = null;
                EntityRepository.SaveContext();
            }
        }
        [HttpPost]
        public void AddOption(string optionName, Guid prodId)
        {
            Product selectedProduct = EntityRepository.Products.Where(p => p.ProductId == prodId).FirstOrDefault();
            TemplateOptions selectedOption = EntityRepository.TemplateOptions.Where(t => t.OptionName == optionName).FirstOrDefault();

            ProductOptions option = new ProductOptions
            {
                OptionId = Guid.NewGuid(),
                OptionName = selectedOption.OptionName,
                OptionType = selectedOption.OptionType

            };

            foreach (var param in selectedOption.TempOptionParams)
            {
                ProductOptionParams optionParams = new ProductOptionParams
                {
                    ParameterId = Guid.NewGuid(),
                    ParameterName = param.ParameterName,
                    ParameterTooltip = param.ParameterTooltip,
                    ParameterPrice = param.ParameterPrice,
                    ParentOptionId = option.OptionId,
                    ParameterSale = param.ParameterSale

                };
                option.ProductOptionParams.Add(optionParams);
            }

            selectedProduct.ProductOptions.Add(option);
            EntityRepository.SaveContext();
        }
        [HttpPost]
        public string AddSiteBlock(Guid siteblockId)
        {
            var siteblock = EntityRepository.HtmlBlocks.Where(b => b.SiteBlockId == siteblockId).FirstOrDefault();
            if (siteblock != null)
            {
                var siteblockchild = new HtmlBlocksChildren();
                siteblockchild.SiteBlockChildsId = Guid.NewGuid();
                siteblockchild.SiteBlockId = siteblockId;
                siteblock.HtmlBlocksChildren.Add(siteblockchild);
                EntityRepository.SaveContext();
                return siteblockchild.SiteBlockChildsId.ToString();
            }
            else
            {
                var newSiteBlock = new HtmlBlockDetails { };
                newSiteBlock.SiteBlockId = Guid.NewGuid();

                var newSiteBlockChild = new HtmlBlockDetails.HtmlBlockChildrenDetails { };
                newSiteBlockChild.SiteBlockChildsId = Guid.NewGuid();

                newSiteBlock.HtmlBlockChildDetailsCollection = new List<HtmlBlockDetails.HtmlBlockChildrenDetails>();
                newSiteBlock.HtmlBlockChildDetailsCollection.Add(newSiteBlockChild);

                EntityRepository.SaveHtmlBlock(newSiteBlock);
                return newSiteBlock.SiteBlockId.ToString();
            }
        }
        [HttpPost]
        public void RemoveOption(Guid optionId, Guid prodId)
        {
            ProductOptions selectedOption = EntityRepository.ProductOptions.Where(po => po.OptionId == optionId).FirstOrDefault();
            Product selectedProduct = EntityRepository.Products.Where(p => p.ProductId == prodId).FirstOrDefault();
            selectedProduct.ProductOptions.Remove(selectedOption);
            EntityRepository.SaveContext();
        }
        [HttpPost]
        public void RemoveParam(Guid optionId, Guid paramId)
        {
            ProductOptions selectedOption = EntityRepository.ProductOptions.Where(po => po.OptionId == optionId).FirstOrDefault();
            ProductOptionParams prodParam = selectedOption.ProductOptionParams.Where(p => p.ParameterId == paramId).FirstOrDefault();
            selectedOption.ProductOptionParams.Remove(prodParam);
            EntityRepository.SaveContext();
        }
        [HttpPost]
        public void AddParam(string optionName, string paramName, Guid OptId)
        {
            TempOptionParams TempOptionParams = EntityRepository.TemplateOptions.Where(po => po.OptionName == optionName).FirstOrDefault().TempOptionParams.Where(p => p.ParameterName == paramName).FirstOrDefault();
            ProductOptions selectedOption = EntityRepository.ProductOptions.Where(o => o.OptionId == OptId).FirstOrDefault();

            ProductOptionParams parameter = new ProductOptionParams
            {
                ParameterId = Guid.NewGuid(),
                ParameterName = TempOptionParams.ParameterName,
                ParameterTooltip = TempOptionParams.ParameterTooltip,
                ParameterPrice = TempOptionParams.ParameterPrice,
                ParameterSale = TempOptionParams.ParameterSale
            };
            selectedOption.ProductOptionParams.Add(parameter);
            EntityRepository.SaveContext();
        }
        [HttpPost]
        public ActionResult SaveProduct(ProductDetails productDetails, bool navigateToProdOpt = false)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveProduct(productDetails);
                TempData["message"] = string.Format(productDetails.ProductName + " was saved");
                if (navigateToProdOpt)
                {
                    return RedirectToAction("ProductOptionsEdit", new { productId = productDetails.ProductId });
                }
                else
                {
                    return RedirectToAction("List", new { type = "Product" });
                }
            }
            else
            {
                return View("SaveProduct", new ProductDetails
                {
                    Product = productDetails.Product,
                    ProductId = productDetails.ProductId,
                    GamesList = new SelectList(EntityRepository.Games.Select(g => g.GameName), productDetails.SelectedGame ?? "Select Game"),
                    CategoriesList = new SelectList(EntityRepository.Games.Where(g => productDetails.SelectedGame == null || g.GameName == productDetails.SelectedGame).SelectMany(g => g.ProductCategory).Select(p => p.ProductCategoryName), productDetails.SelectedCategory ?? "Select Category"),
                    MetaTagTitleList = new SelectList(EntityRepository.SEOs.Select(s => s.MetaTagTitle), productDetails.SelectedMetaTagTitle ?? "Select Meta tag title from List"),
                    ProductOptions = productDetails.ProductOptions,
                    ProductName = productDetails.ProductName,
                    InStock = productDetails.InStock,
                    PreOrder = productDetails.PreOrder,
                    ProductEnabled = productDetails.ProductEnabled,
                    ProductQuantity = productDetails.ProductQuantity,
                    ProductImageThumb = productDetails.ProductImageThumb,
                    ProductImage = productDetails.ProductImage,
                    ProductPriority = productDetails.ProductPriority,
                    ProductPriceEU = productDetails.ProductPriceEU,
                    ProductPriceUS = productDetails.ProductPriceUS,
                    ProductSaleEU = productDetails.ProductSaleEU,
                    ProductSaleUS = productDetails.ProductSaleUS,
                    Description = productDetails.Description,
                    SubDescriptionTitle1 = productDetails.SubDescriptionTitle1,
                    SubDescription1 = productDetails.SubDescription1,
                    SubDescriptionTitle2 = productDetails.SubDescriptionTitle2,
                    SubDescription2 = productDetails.SubDescription2,
                    SubDescriptionTitle3 = productDetails.SubDescriptionTitle3,
                    SubDescription3 = productDetails.SubDescription3,
                    SubDescriptionTitle4 = productDetails.SubDescriptionTitle4,
                    SubDescription4 = productDetails.SubDescription4,
                    SubDescriptionTitle5 = productDetails.SubDescriptionTitle5,
                    SubDescription5 = productDetails.SubDescription5,
                });
            }
        }
        [HttpPost]
        public ActionResult SaveProductOption(ProductOptionsViewModel productOptionViewModel)
        {
            if (ModelState.IsValid)
            {
                foreach (var productOptionDetails in productOptionViewModel.ProductOptions)
                {
                    productOptionDetails.OptionProductId = productOptionViewModel.ProductId;
                    EntityRepository.SaveProductOption(productOptionDetails);
                }
                TempData["message"] = string.Format("Options has been saved");
                return RedirectToAction("List", new { type = "Product" });
            }
            else
            {
                return RedirectToAction("List", new { type = "Product" });
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveHtmlBlock(HtmlBlockDetails htmlBlockDetails)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveHtmlBlock(htmlBlockDetails);
                TempData["message"] = string.Format("HTML BLock has been saved");
                return RedirectToAction("List", new { type = "HtmlBlock" });
            }
            else
            {
                return View("SaveHtmlBlocks", new HtmlBlockDetails
                {
                    SiteBlockId = htmlBlockDetails.SiteBlockId,
                    ParentTitle = htmlBlockDetails.ParentTitle,
                    ParentCSSClass = htmlBlockDetails.ParentCSSClass,
                    ChildCSSClass = htmlBlockDetails.ChildCSSClass,
                    SitePage = htmlBlockDetails.SitePage,
                    Order = htmlBlockDetails.Order,
                    HtmlBlockChildDetailsCollection = HtmlBlockDetails.PopulateHtmlBlockCollection(null, htmlBlockDetails)

                });
            }
        }
        [HttpPost]
        public ActionResult SaveTemplateOption(TemplateOptionDetails templateOptionDetails)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveTemplateOption(templateOptionDetails);
                TempData["message"] = string.Format("Template Option has been saved");
                return RedirectToAction("List", new { type = "Template Option" });
            }
            else
            {
                return RedirectToAction("List", new { type = "Template Option" });
            }
        }
        [HttpPost]
        public ActionResult SaveSEO(SeoDetails seoDetails)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveSEO(seoDetails);
                TempData["message"] = string.Format("Seo has been saved");
                return RedirectToAction("List", new { type = "SEO" });
            }
            else
            {
                return RedirectToAction("List", new { type = "SEO" });
            }
        }
        [HttpPost]
        public ActionResult SaveGame(ProductGameDetails productGameDetails)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveGame(productGameDetails);
                TempData["message"] = string.Format("Product Game Details has been saved");
                return RedirectToAction("List", new { type = "ProductGame" });
            }
            else
            {
                return RedirectToAction("List", new { type = "ProductGame" });
            }
        }
        [HttpPost]
        public ActionResult SaveUsers(UsersDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveUsers(userDetails);
                TempData["message"] = string.Format("User has been saved");
                return RedirectToAction("List", new { type = "Users" });
            }
            else
            {
                return RedirectToAction("List", new { type = "Users" });
            }
        }
        [HttpPost]
        public ActionResult SaveRanks(RankDetails rankDetails)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveRanks(rankDetails);
                TempData["message"] = string.Format("Ranks has been saved");
                return RedirectToAction("List", new { type = "Ranks" });
            }
            else
            {
                return RedirectToAction("List", new { type = "Ranks" });
            }
        }
        [HttpPost]
        public ActionResult SaveCustomers(CustomersDetails customers)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveCustomers(customers);
                TempData["message"] = string.Format("Customers has been saved");
                return RedirectToAction("List", new { type = "Customers" });
            }
            else
            {
                return RedirectToAction("List", new { type = "Customers" });
            }
        }
        [HttpPost]
        public ActionResult SaveRoles(RolesDetails rolesDetails)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveRoles(rolesDetails);
                TempData["message"] = string.Format("Roles has been saved");
                return RedirectToAction("List", new { type = "Roles" });
            }
            else
            {
                return RedirectToAction("List", new { type = "Roles" });
            }
        }
        public ActionResult SaveOrders(OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveOrders(orderDetails);
                TempData["message"] = string.Format("Orders has been saved");
                return RedirectToAction("List", new { type = "Orders" });
            }
            else
            {
                return RedirectToAction("List", new { type = "Orders" });
            }
        }
        [HttpPost]
        public void Remove(Guid Id, string type)
        {
            switch (type)
            {
                case "Product":
                case "TemplateOptions":
                case "ProductGame":
                case "HtmlBlocks":
                    EntityRepository.RemoveHtmlBlock(Id);
                    break;
                case "SEO":
                case "Users":
                case "Ranks":
                case "Customers":
                case "Roles":
                case "Orders":
                    break;
            }
        }
        [HttpPost]
        public string Upload()
        {
            var file = Request.Files[0];
            var path = Request.Form[0];
            var requiredFileName = Request.Form[1];
            string extension = Path.GetExtension(file.FileName);

            string endPath = Server.MapPath(path);

            if (!Directory.Exists(endPath))
                Directory.CreateDirectory(endPath);

            if (System.IO.File.Exists(endPath + requiredFileName + extension))
                System.IO.File.Delete(endPath + requiredFileName + extension);

            file.SaveAs(endPath + @"\" + requiredFileName + extension);
            
            return endPath + @"\" + requiredFileName + extension;
        }
        #endregion

        private static string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(name, invalidRegStr, "_");
        }
    }
}