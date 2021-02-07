using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WowCarry.Domain.Entities;

namespace WebUI.Models
{
    public class TagSearchViewModel
    {
        public IEnumerable<Article> articles { get; set; }
        public IEnumerable<string> tags { get; set; }

    }
}