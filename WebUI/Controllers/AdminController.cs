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
                    return View("Save" + type, new ProductDetails
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
                OptionId = selectedOption.ProductOptionId,
                OptionName = selectedOption.OptionName,
                OptionType = selectedOption.OptionType,
                ParentParamList = new SelectList(selectedProduct.ProductOptions.Where(o => o.ProductOptionId != selectedOption.ProductOptionId).SelectMany(p => p.ProductOptionParams).Select(pr => pr.ParamName), selectedOption.OptionParamsParentId != null ? selectedOption.ProductOptionParentParam.ParamName : "Empty"),
                ParamList = new SelectList(selectedOption.ProductOptionParams.Select(p => p.ParamName) , "Empty"),
                ParamCollection = ProductOptionDetails.PopulateParamCollection(selectedOption, selectedProduct.ProductOptions.Where(o => o.ProductOptionId != selectedOption.ProductOptionId).SelectMany(p => p.ProductOptionParams).Select(pr => pr.ParamName))
            };
            return PartialView(result);
        }
        public PartialViewResult ProductOptionsEdit(Guid productId)
        {
            var result = EntityRepository.ProductOptions.Where(o => o.OptionProductId == productId);
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
                OptionType = selectedOption.TempOptionType

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
                    Sale = param.OptionSale

                };
                option.ProductOptionParams.Add(optionParams);
            }

            selectedProduct.ProductOptions.Add(option);
            EntityRepository.SaveContext();

            return PartialView("OptionsList", new ProductOptionDetails 
            {
                OptionId = option.ProductOptionId,
                OptionName = selectedOption.TempOptionName,
                OptionType = selectedOption.TempOptionType,
                ParamList = new SelectList(option.ProductOptionParams.Select(p => p.ParamName), "Empty"),

                //Options parent selector
                ParentParamList = new SelectList(selectedProduct.ProductOptions.Where(o => o.ProductOptionId != option.ProductOptionId).SelectMany(p => p.ProductOptionParams).Select(pr => pr.ParamName), "Empty"),
                //Parameters parent selector
                ParamCollection = ProductOptionDetails.PopulateParamCollection(selectedOption, selectedProduct.ProductOptions.Where(o => o.ProductOptionId != option.ProductOptionId).SelectMany(p => p.ProductOptionParams).Select(pr => pr.ParamName))
            });
        }
        [HttpPost]
        public void RemoveOption(Guid optionId, Guid prodId)
        {
            ProductOptions selectedOption = EntityRepository.ProductOptions.Where(po => po.ProductOptionId == optionId).FirstOrDefault();
            Product selectedProduct = EntityRepository.Products.Where(p => p.ProductId == prodId).FirstOrDefault();
            selectedProduct.ProductOptions.Remove(selectedOption);
            EntityRepository.SaveContext();
        }
        [HttpPost]
        public void RemoveParam(Guid optionId, Guid paramId)
        {
            ProductOptions selectedOption = EntityRepository.ProductOptions.Where(po => po.ProductOptionId == optionId).FirstOrDefault();
            ProductOptionParams prodParam = selectedOption.ProductOptionParams.Where(p => p.OptionParamsId == paramId).FirstOrDefault();
            selectedOption.ProductOptionParams.Remove(prodParam);
            EntityRepository.SaveContext();
        }
        [HttpPost]
        public PartialViewResult AddParam(string optionName, string paramName,Guid ProdOptId)
        {
            TempOptionParams TempOptionParams = EntityRepository.TemplateOptions.Where(po => po.TempOptionName == optionName).FirstOrDefault().TempOptionParams.Where(p => p.ParamName == paramName).FirstOrDefault();
            ProductOptions selectedOption = EntityRepository.ProductOptions.Where(o => o.ProductOptionId == ProdOptId).FirstOrDefault();

            ProductOptionParams parameter = new ProductOptionParams
            {
                OptionParamsId = Guid.NewGuid(),
                ParamName = TempOptionParams.ParamName,
                ParamTooltip = TempOptionParams.ParamTooltip,
                ParamPrice = TempOptionParams.ParamPrice,
                Sale = TempOptionParams.OptionSale
            };
            selectedOption.ProductOptionParams.Add(parameter);
            EntityRepository.SaveContext();
            return PartialView("Param", new ProductOptionDetails.ProductOptionParamsDetails 
            {
                ParameterId = parameter.OptionParamsId,
                Paramname = parameter.ParamName,
                ParamTooltip = parameter.ParamTooltip,
                ParamPrice = parameter.ParamPrice,
                Sale = parameter.Sale,
                ParamParentList = new SelectList(selectedOption.ProductOptionParams.Where(o => o.ProductOptionId != parameter.ProductOptionId).Select(pr => pr.ParamName),"Empty")

            });
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
                    TemplateOptionsList = new SelectList(EntityRepository.TemplateOptions.Select(o => o.TempOptionName), "Select Option from templates"),
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
        public ActionResult SaveProductOption(ProductOptionDetails productOptionDetails)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("List", new { type = "Product" });
            }
            else
            {
                return RedirectToAction("List", new { type = "Product" });
            }
        }
    }
}