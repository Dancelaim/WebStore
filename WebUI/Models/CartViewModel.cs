using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WowCarry.Domain.Entities;

namespace WebUI.Models
{
    public class AccountViewModel
    {
        public Customers Customer { get; set; }
        public IEnumerable<Orders> Orders { get; set; }

    }
}