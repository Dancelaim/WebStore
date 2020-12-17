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
        public List<ProductOptionDetails> ProductOptions { get; set; }
        public SelectList TemplateOptionList { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}