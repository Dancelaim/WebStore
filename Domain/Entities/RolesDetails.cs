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
    public class RolesDetails
    {
        [HiddenInput]
        public System.Guid RoleId { get; set; }

        [Display(Name = "RoleName")]
        public string RoleName { get; set; }


    }

}
