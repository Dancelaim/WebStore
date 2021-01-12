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
    public class RankDetails
    {
        [HiddenInput]
        public System.Guid RankId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Sale")]
        public string Sale { get; set; }
    }

}
