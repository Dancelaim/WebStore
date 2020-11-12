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
    public class ProductOptionDetails
    {
        public ProductOptionDetails(ProductOptions option,Product product)
        {
            ProdOpt = option;
            Product = product;
        }
        ProductOptions ProdOpt { get; set; }
        Product Product { get; set; }


        [Display(Name = "Name")]
        public string OptionName { get => ProdOpt.OptionName; }

        [Display(Name = "Type")]
        public string OptionType { get => ProdOpt.OptionType; }

        [Display(Name = "Parent")]
        public string OptionParent { get; set; }
        IEnumerable<string> OptionParamNames { get { return Product.ProductOptions.Where(o=>o.ProductOptionId!= ProdOpt.ProductOptionId).SelectMany(p=>p.ProductOptionParams).Select(pr=>pr.ParamName); } }
        public SelectList ParamList { get { return new SelectList(OptionParamNames, ProdOpt.OptionParamsParentId != null ? ProdOpt.ProductOptionParentParam.ParamName : "Empty");} } 

        public List<ProductOptionParamsDetails> ParamCollection
        {
            get
            {
                List<ProductOptionParamsDetails> result = new List<ProductOptionParamsDetails>();
                foreach (var item in ProdOpt.ProductOptionParams)
                {
                    result.Add(new ProductOptionParamsDetails(item));
                }
                return result;
            }
        }
        public class ProductOptionParamsDetails
        {
            public ProductOptionParamsDetails(ProductOptionParams optParams)
            {
                OptionParams = optParams;
            }
            ProductOptionParams OptionParams { get; set; }
            public string Paramname { get => OptionParams.ParamName; }
            public string ParamTooltip { get => OptionParams.ParamTooltip; }
            public Double? ParamPrice { get => OptionParams.ParamPrice; }
            public string Sale { get => OptionParams.Sale; }
            public string ParentParam => OptionParams.ProductOptionParams2?.ParamName;
            IEnumerable<string> ParentParamNames => (IEnumerable<string>)OptionParams.ProductOptions.ProductOptionParentParam.ProductOptions.ProductOptionParams.Select(p => p.ParamName);
            public SelectList ParamList => new SelectList(ParentParamNames, OptionParams.ParamParentId != null ? OptionParams.ProductOptionParams2.ParamName : "Empty");
        }
    }
}
