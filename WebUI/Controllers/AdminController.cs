using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;
using System;

namespace WowCarry.WebUI.Controllers
{
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
                case "ProductOption":
                    return View("List" + type, EntityRepository.ProductOptions);
                case "ProductGame":
                    return View("List" + type, EntityRepository.Games);
                case "HtmlBlocks":
                    return View("List" + type, EntityRepository.HtmlBlocks);
                case "SEO":
                    return View("List" + type, EntityRepository.SEOs);
                default: return View("Admin");
            }
        }
        public ViewResult Edit(Guid Id, string type, string game)
        {
            switch (type)
            {
                case "Product":
                    var prod = EntityRepository.Products.Where(p => p.ProductId == Id).FirstOrDefault();
                    return View("Save" + type, new ProductDetails
                    {
                        Product = prod,
                        ProductId = prod.ProductId,
                        GamesList = new SelectList(EntityRepository.Games.Select(g => g.GameName), prod?.ProductGame.GameName ?? "Select Game"),
                        CategoriesList = new SelectList(EntityRepository.Games.Where(g => game == null || g.GameName == game).SelectMany(g => g.ProductCategory).Select(p => p.ProductCategoryName), prod?.ProductCategory.ProductCategoryName ?? "Select Category"),
                        MetaTagTitleList = new SelectList(EntityRepository.SEOs.Select(s => s.MetaTagTitle), prod?.SEO.MetaTagTitle ?? "Select Meta tag title from List"),
                        ProductOptions = prod.ProductOptions,
                        TemplateOptionsList = new SelectList(EntityRepository.TemplateOptions.Select(o=>o.TempOptionName), "Select Option from templates"),
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
                case "ProductOption":
                    return View("Save" + type, EntityRepository.ProductOptions.Where(p => p.ProductOptionId == Id).FirstOrDefault());
                case "ProductGame":
                    return View("Save" + type, EntityRepository.Games.Where(p => p.ProductGameId == Id).FirstOrDefault());
                case "HtmlBlocks":
                    return View("Save" + type, EntityRepository.HtmlBlocks.Where(p => p.SiteBlockId == Id).FirstOrDefault());
                case "SEO":
                    return View("Save" + type, EntityRepository.SEOs.Where(p => p.SEOId == Id).FirstOrDefault());
                default: return View("Admin");
            }
        }
        public ViewResult Create(string type, string game)
        {
            switch (type)
            {
                case "Product":
                    return View("Create" + type, new ProductDetails
                    {
                        GamesList = new SelectList(EntityRepository.Games.Select(g => g.GameName), "Select Game"),
                        CategoriesList = new SelectList(EntityRepository.Games.Where(g => game == null || g.GameName == game).SelectMany(g => g.ProductCategory).Select(p => p.ProductCategoryName), "Select Category"),
                        MetaTagTitleList = new SelectList(EntityRepository.SEOs.Select(s => s.MetaTagTitle), "Select Meta tag title from List"),
                    });
                case "ProductOption":
                    return View("Save" + type, EntityRepository);
                case "ProductGame":
                    return View("Save" + type, EntityRepository);
                case "HtmlBlocks":
                    return View("Save" + type, EntityRepository);
                case "SEO":
                    return View("Save" + type, EntityRepository);
                default: return View("Admin");
            }
        }
        public PartialViewResult OptionsList(string optionName,Guid prodId)
        {
            var selectedProduct = EntityRepository.Products.Where(p => p.ProductId == prodId).FirstOrDefault();
            var selectedOption = selectedProduct.ProductOptions.Where(o=>o.OptionName == optionName).FirstOrDefault();
            var result = new ProductOptionDetails
            {
                OptionName = selectedOption.OptionName,
                OptionType = selectedOption.OptionType,
                ParamList = new SelectList(selectedProduct.ProductOptions.Where(o => o.ProductOptionId != selectedOption.ProductOptionId).SelectMany(p => p.ProductOptionParams).Select(pr => pr.ParamName), selectedOption.OptionParamsParentId != null ? selectedOption.ProductOptionParentParam.ParamName : "Empty"),
                ParamCollection = ProductOptionDetails.PopulateParamCollection(selectedOption)
            };

            return PartialView(result);
        }
        public PartialViewResult AddOption(string optionName, Guid prodId)
        {
            Product selectedProduct = EntityRepository.Products.Where(p => p.ProductId == prodId).FirstOrDefault();
            TemplateOptions selectedOption = EntityRepository.TemplateOptions.Where(t=>t.TempOptionName == optionName).FirstOrDefault();

            ProductOptions option = new ProductOptions
            {
                ProductOptionId = Guid.NewGuid(),
                OptionName = selectedOption.TempOptionName,
                OptionType = selectedOption.TempOptionType,
                OptionParamsParentId = selectedOption.TempOptionParamParentId

            };

            foreach(var param in selectedOption.TempOptionParams)
            {
                ProductOptionParams optionParams = new ProductOptionParams
                {
                    OptionParamsId = Guid.NewGuid(),
                    ParamName = param.ParamName,
                    ParamTooltip = param.ParamTooltip,
                    ParamPrice = param.ParamPrice,
                    ProductOptionId = option.ProductOptionId,
                    Sale = param.OptionSale,
                    ParamParentId = param.ParamParentId

                };
                option.ProductOptionParams.Add(optionParams);
            }

            selectedProduct.ProductOptions.Add(option);
            EntityRepository.SaveContext();

            return PartialView("OptionsList", new ProductOptionDetails 
            {
                OptionName = selectedOption.TempOptionName,
                OptionType = selectedOption.TempOptionType,
                ParamList = new SelectList(selectedProduct.ProductOptions.Where(o => o.ProductOptionId != selectedOption.TempOptionId).SelectMany(p => p.ProductOptionParams).Select(pr => pr.ParamName), "Empty"),
                ParamCollection = ProductOptionDetails.PopulateParamCollection(selectedOption, selectedProduct.ProductOptions.Where(o => o.ProductOptionId != selectedOption.TempOptionId).SelectMany(p => p.ProductOptionParams).Select(pr => pr.ParamName))
            });
        }
        [HttpPost]
        public void RemoveOption(string optionName, Guid prodId)
        {
            ProductOptions selectedOption = EntityRepository.ProductOptions.Where(po => po.OptionName == optionName && po.OptionProductId == prodId).FirstOrDefault();
            Product selectedProduct = EntityRepository.Products.Where(p => p.ProductId == prodId).FirstOrDefault();
            selectedProduct.ProductOptions.Remove(selectedOption);
            EntityRepository.SaveContext();
        }

        [HttpPost]
        public ActionResult Save(ProductDetails productDetails)
        {
            if (ModelState.IsValid)
            {
                EntityRepository.SaveProduct(productDetails);
                TempData["message"] = string.Format(productDetails.ProductName + " was saved");
                return RedirectToAction("List",new {type = "Product"});
            }
            else
            {
                return RedirectToAction("Admin");
            }
        }
    }
}