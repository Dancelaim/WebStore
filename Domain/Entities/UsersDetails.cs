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
    public class UsersDetails
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "User Password")]
        public string UserPassword { get; set; }

        [HiddenInput]
        public Nullable<System.Guid> RoleId { get; set; }

        [HiddenInput]
        public System.Guid UserId { get; set; }

        [HiddenInput]
        public Nullable<System.Guid> RankId { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }

}
