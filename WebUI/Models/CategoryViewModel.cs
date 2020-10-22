using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WowCarry.Domain.Entities;

namespace WebUI.Models
{
    public class CategoryViewModel
    {
        public IEnumerable<string> categories { get; set; }
        public string currentGame { get; set; }
       
    }
}