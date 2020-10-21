using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WowCarry.Domain.Entities;

namespace WebUI.Models
{
    public class CartViewModel
    {
        public Cart cart { get; set; }
        public List<Guid> productsId { get; set; }
    }
}