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
    public class TemplateOptionDetails
    {
        [HiddenInput]
        public System.Guid TempOptionId { get; set; }

        [Display(Name = "TempOptionName")]
        public string TempOptionName { get; set; }

        [Display(Name = "TempOptionType")]
        public string TempOptionType { get; set; }

        [Display(Name = "TempOptionParamParentId")]
        public Nullable<System.Guid> TempOptionParamParentId { get; set; }
    }
}
