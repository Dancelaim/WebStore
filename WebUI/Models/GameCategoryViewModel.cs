﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WowCarry.Domain.Entities;

namespace WebUI.Models
{
    public class GameCategoryViewModel
    {
        public IEnumerable<string> Games { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }

    }
}