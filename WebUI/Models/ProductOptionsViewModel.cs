using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WowCarry.Domain.Entities;

namespace WebUI.Models
{
    public class ProductOptionsViewModel
    {
        public IEnumerable<ProductOptions> ProductOptions { get; set; }
        public SelectList TemplateOptionList { get; set; }
        public Guid ProductId { get; set; }
    }
}