using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;
using System;
using System.Collections.Generic;

namespace WowCarry.WebUI.Controllers
{
    [Authorize(Roles = "Root Admin")]
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
                default: return View("Admin");
            }
        }

        public ViewResult Edit(Guid Id, string type, string game)
        {
            switch (type)
            {
                case "Product":
                    Product prod = EntityRepository.Products.Where(p => p.ProductId == Id).FirstOrDefault();
                    return View("Save" + type, new ProductDetails
                    {
                        Product = prod,
                        ProductId = prod.ProductId,
                        GamesList = new SelectList(EntityRepository.Games.Select(g => g.GameName), prod?.ProductGame.GameName ?? "Select Game"),
                        CategoriesList = new SelectList(EntityRepository.Games.Where(g => game == null || g.GameName == game).SelectMany(g => g.ProductCategory).Select(p => p.ProductCategoryName), prod?.ProductCategory.ProductCategoryName ?? "Select Category"),
                        MetaTagTitleList = new SelectList(EntityRepository.SEOs.Select(s => s.MetaTagTitle), prod?.SEO.MetaTagTitle ?? "Select Meta tag title from List"),
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
                case "TemplateOptions":
                    TemplateOptions templateOptions = EntityRepository.TemplateOptions.Where(p => p.OptionId == Id).FirstOrDefault();
                    return View("Save" + type, new TemplateOptionDetails
                    {
                        TempOptionId = templateOptions.OptionId,
                        TempOptionName = templateOptions.OptionName,
                        TempOptionType = templateOptions.OptionType,
                        TempOptionParamsDetailsCollection = TemplateOptionDetails.PopulateTempOptionParamsDetailsCollection(templateOptions)
                    });
                case "ProductGame":
                    ProductGame productGame = EntityRepository.Games.Where(p => p.ProductGameId == Id).FirstOrDefault();
                    return View("Save" + type, new ProductGameDetails
                    {
                        ProductGameId  = productGame.ProductGameId,
                        GameName = productGame.GameName,
                        GameDescription = productGame.GameDescription,
                        GameShortUrl = productGame.GameShortUrl,
                        GameSeoId = productGame.GameSeoId,
                        ProductCategoryDetailsCollection  = ProductGameDetails.PopulateProductGameDetails(productGame)

                    });
                case "HtmlBlocks":
                    HtmlBlocks siteBlock = EntityRepository.HtmlBlocks.Where(p => p.SiteBlockId == Id).FirstOrDefault();
                    return View("Save" + type , new HtmlBlockDetails 
                    {   
                        SiteBlockId = siteBlock.SiteBlockId, 
                        ParentTitle = siteBlock.ParentTitle,
                        ParentCSSClass = siteBlock.ParentCSSClass,
                        ChildCSSClass = siteBlock.ChildCSSClass,
                        SitePage = siteBlock.SitePage,
                        Order = siteBlock.Order,
                        HtmlBlockChildDetailsCollection = HtmlBlockDetails.PopulateHtmlBlockCollection(siteBlock)

                    });
                case "SEO":
                    SEO seo = EntityRepository.SEOs.Where(p => p.SEOId == Id).FirstOrDefault();
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
                default: return View("Admin");
            }
        }

        public ViewResult Create(string type, string game)
        {
            switch (type)
            {
                case "Product":
                    return View("Save" + type, new ProductDetails
                    {
                        GamesList = new SelectList(EntityRepository.Games.Select(g => g.GameName), "Select Game"),
                        CategoriesList = new SelectList(EntityRepository.Games.Where(g => game == null || g.GameName == game).SelectMany(g => g.ProductCategory).Select(p => p.ProductCategoryName), "Select Category"),
                        MetaTagTitleList = new SelectList(EntityRepository.SEOs.Select(s => s.MetaTagTitle), "Select Meta tag title from List"),
                    });
                case "TemplateOptions":
                    return View("Save" + type, new TemplateOptionDetails{});
                case "ProductGame":
                    return View("Save" + type, new ProductGameDetails{});
                case "HtmlBlocks":
                    return View("Save" + type, new HtmlBlockDetails { });
                case "SEO":
                    return View("Save" + type, new SeoDetails { });
                default: return View("Admin");
            }
        }
        //public PartialViewResult OptionsList(string optionName,Guid prodId)
        //{
        //    var selectedProduct = EntityRepository.Products.Where(p => p.ProductId == prodId).FirstOrDefault();
        //    var selectedOption = selectedProduct.ProductOptions.Where(o=>o.OptionName == optionName).FirstOrDefault();

        //    var templateOption = EntityRepository.TemplateOptions.Where(t => t.OptionName == optionName).FirstOrDefault();
        //    var result = new ProductOptionDetails
        //    {
        //        OptionId = selectedOption.OptionId,
        //        OptionName = selectedOption.OptionName,
        //        OptionType = selectedOption.OptionType,
        //        ParentOptionList = new SelectList(selectedProduct.ProductOptions.Where(o => o.OptionId != selectedOption.OptionId).Select(o=>o.OptionName), selectedOption.OptionParentId.HasValue ? selectedOption.ProductOptionsParent.Select(p=>p.OptionName).FirstOrDefault() : "Empty"),
        //        ParamList = new SelectList(templateOption.TempOptionParams.Select(p => p.ParameterName) , "Empty"),
        //        ParamCollection = ProductOptionDetails.PopulateParamCollection(selectedOption, selectedProduct.ProductOptions.Where(o => o.OptionId == selectedOption.OptionParentId).SelectMany(p => p.ProductOptionParams).Select(pr => pr.ParameterName))
        //    };
        //    return PartialView(result);
        //}
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
                    Options.Add(new ProductOptionDetails
                    {
                        OptionId = opt.OptionId,
                        OptionName = opt.OptionName,
                        OptionType = opt.OptionType,
                        ParentOptionList = new SelectList(selectedProduct.ProductOptions.Where(o => o.OptionId != opt.OptionId).Select(o => o.OptionName), opt.OptionParentId.HasValue ? opt.ProductOptionsParent.OptionName : "Empty"),
                        ParamList = new SelectList(templateOption.TempOptionParams.Select(p => p.ParameterName), "Empty"),
                        ParamCollection = ProductOptionDetails.PopulateParamCollection(opt, selectedProduct.ProductOptions.Where(o => o.OptionId == opt.OptionParentId).SelectMany(p => p.ProductOptionParams).Select(pr => pr.ParameterName))
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
        public ViewResult HtmlBlockEdit(Guid SiteBlockId)
        {
            var selectedProduct = EntityRepository.HtmlBlocks.Where(h => h.SiteBlockId == SiteBlockId).FirstOrDefault();
            List<HtmlBlockDetails> htmlBlockChildrens = new List<HtmlBlockDetails>();
            //if ()
            //{

            //}

            return View(SiteBlockId);
        }
        [HttpPost]
        public void PopulateSelectLists(Guid optionId,Guid prodId,string parentName)
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
            TemplateOptions selectedOption = EntityRepository.TemplateOptions.Where(t=>t.OptionName == optionName).FirstOrDefault();

            ProductOptions option = new ProductOptions
            {
                OptionId = Guid.NewGuid(),
                OptionName = selectedOption.OptionName,
                OptionType = selectedOption.OptionType

            };

            foreach(var param in selectedOption.TempOptionParams)
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
        public void AddParam(string optionName, string paramName,Guid OptId)
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
        public ActionResult SaveProduct(ProductDetails productDetails,bool  navigateToProdOpt = false)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveProduct(productDetails);
                TempData["message"] = string.Format(productDetails.ProductName + " was saved");
                if (navigateToProdOpt)
                {
                    return RedirectToAction("ProductOptionsEdit", new { productId = productDetails.ProductId});
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
                foreach(var productOptionDetails in productOptionViewModel.ProductOptions)
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
                return RedirectToAction("List", new { type = "HtmlBlock" });
            }
        }
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
    }
}