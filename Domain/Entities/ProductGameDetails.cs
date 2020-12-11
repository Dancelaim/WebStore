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
    public class ProductGameDetails
    {
        [HiddenInput]

        public System.Guid ProductGameId { get; set; }

        [Display(Name = "GameName")]
        public string GameName { get; set; }

        [Display(Name = "GameDescription")]
        public string GameDescription { get; set; }

        [Display(Name = "GameShortUrl")]
        public string GameShortUrl { get; set; }

        [HiddenInput]

        public Nullable<System.Guid> GameSeoId { get; set; }
    
        
    }
}
