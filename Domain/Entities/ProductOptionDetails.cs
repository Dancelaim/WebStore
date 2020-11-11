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
        public ProductOptionDetails(ProductOptions option)
        {
            ProdOpt = option;
        }
        ProductOptions ProdOpt { get; set; }
        public string OptionName { get => ProdOpt.OptionName; }
        public string OptionType { get => ProdOpt.OptionType; }
        public string OptionParent { get; set; }

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
        }
    }
}
