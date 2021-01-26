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
    public class CustomersDetails
    {
        [HiddenInput]
        public System.Guid CustomerId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [HiddenInput]
        public Nullable<System.Guid> RankId { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "CarryCoinsValue")]
        public Nullable<decimal> CarryCoinsValue { get; set; }
    }

}
