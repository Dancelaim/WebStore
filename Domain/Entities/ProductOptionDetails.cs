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
        [HiddenInput]
        public Guid OptionId { get; set; }

        [Display(Name = "Name")]
        public string OptionName { get; set; }

        [Display(Name = "Type")]
        public string OptionType { get; set; }

        [Display(Name = "Parent")]
        public string OptionParent { get; set; }
        public SelectList ParentParamList { get; set; }
        public SelectList ParamList { get; set; }
        public List<ProductOptionParamsDetails> ParamCollection { get; set; }

        public class ProductOptionParamsDetails
        {
            [HiddenInput]
            public Guid ParameterId { get; set; }
            [Display(Name = "Parameter name")]
            public string Paramname { get; set; }

            [Display(Name = "Parameter Tooltip")]
            public String ParamTooltip { get; set; }

            [Display(Name = "Parameter Price")]
            public Double? ParamPrice { get; set; }

            [Display(Name = "Parameter Sale")]
            public string Sale { get; set; }

            [Display(Name = "Parameter Parent")]
            public string ParentParam { get; set; }
            public SelectList ParamParentList { get; set; }
        }
        public static List<ProductOptionParamsDetails> PopulateParamCollection(ProductOptions ProdOpt,IEnumerable<string> paramCollection)
        {
            List<ProductOptionParamsDetails> result = new List<ProductOptionParamsDetails>();
            foreach (var item in ProdOpt.ProductOptionParams)
            {
                result.Add(new ProductOptionParamsDetails
                {
                    ParameterId = item.OptionParamsId,
                    Paramname = item.ParamName,
                    ParamTooltip = item.ParamTooltip,
                    ParamPrice = item.ParamPrice,
                    Sale = item.Sale,
                    ParentParam = item.ProductOptionParams2?.ParamName,
                    ParamParentList = new SelectList(paramCollection, "Empty")
                        

                });
            }
            return result;
        }
        public static List<ProductOptionParamsDetails> PopulateParamCollection(TemplateOptions TempOpt,IEnumerable<string> paramCollection)
        {
            List<ProductOptionParamsDetails> result = new List<ProductOptionParamsDetails>();
            foreach (var item in TempOpt.TempOptionParams)
            {
                result.Add(new ProductOptionParamsDetails
                {
                    ParameterId = Guid.NewGuid(),
                    Paramname = item.ParamName,
                    ParamTooltip = item.ParamTooltip,
                    ParamPrice = item.ParamPrice,
                    Sale = item.OptionSale,
                    ParentParam = item.TempOptionParams2?.ParamName,
                    ParamParentList = new SelectList(paramCollection, "Empty")
                });
            }
            return result;
        }
    }
}
