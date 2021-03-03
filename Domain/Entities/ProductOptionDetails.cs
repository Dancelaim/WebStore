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
        [HiddenInput]
        public Guid OptionProductId { get; set; }
        [Display(Name = "Parent")]
        public string OptionParent { get; set; }
        public SelectList ParentOptionList { get; set; }
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
            public decimal ParamPrice { get; set; }

            [Display(Name = "Parameter Sale")]
            public string Sale { get; set; }

            [Display(Name = "Parameter Parent")]
            public string ParentParam { get; set; }
            public SelectList ParamParentList { get; set; }
        }
        public static List<ProductOptionParamsDetails> PopulateParamCollection(ProductOptions ProdOpt,IEnumerable<string> paramCollection,ProductOptions ParentOption)
        {
            List<ProductOptionParamsDetails> result = new List<ProductOptionParamsDetails>();
            foreach (var item in ProdOpt.ProductOptionParams)
            {
                result.Add(new ProductOptionParamsDetails
                {
                    ParameterId = item.ParameterId,
                    Paramname = item.ParameterName,
                    ParamTooltip = item.ParameterTooltip,
                    ParamPrice = item.ParameterPrice,
                    Sale = item.ParameterSale,
                    ParentParam = ParentOption?.ProductOptionParams?.Where(p => p.ParameterId == item.ParameterParentId).FirstOrDefault().ParameterName,
                    ParamParentList = new SelectList(paramCollection, item.ParameterParentId !=null ? ParentOption?.ProductOptionParams.Where(p=>p.ParameterId == item.ParameterParentId).FirstOrDefault().ParameterName : "Empty")
                });
            }
            return result;
        }
        public static List<ProductOptionParamsDetails> PopulateParamCollection(TemplateOptions TempOpt)
        {
            List<ProductOptionParamsDetails> result = new List<ProductOptionParamsDetails>();
            foreach (var item in TempOpt.TempOptionParams)
            {
                result.Add(new ProductOptionParamsDetails
                {
                    ParameterId = Guid.NewGuid(),
                    Paramname = item.ParameterName,
                    ParamTooltip = item.ParameterTooltip,
                    ParamPrice = item.ParameterPrice,
                    Sale = item.ParameterSale,
                    ParentParam = item.TemplateOptions?.OptionName,
                    ParamParentList = new SelectList(Enumerable.Empty<string>(), "Empty")
                });
            }
            return result;
        }
    }
}
