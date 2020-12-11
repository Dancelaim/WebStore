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
    public class SeoDetails
    {
        [HiddenInput]
        public Guid SEOId { get; set; }

        [Display(Name = "MetaTagTitle")]
        public string MetaTagTitle { get; set; }

        [Display(Name = "MetaTagDescription")]
        public string MetaTagDescription { get; set; }

        [Display(Name = "MetaTagKeyWords")]
        public string MetaTagKeyWords { get; set; }

        [Display(Name = "SEOTags")]
        public string SEOTags { get; set; }

        [Display(Name = "CustomTitle1")]
        public string CustomTitle1 { get; set; }

        [Display(Name = "CustomTitle2")]
        public string CustomTitle2 { get; set; }

        [Display(Name = "CustomImageTitle")]
        public string CustomImageTitle { get; set; }

        [Display(Name = "CustomImageAlt")]
        public string CustomImageAlt { get; set; }

        [Display(Name = "MetaRobots")]
        public string MetaRobots { get; set; }

        [Display(Name = "UrlKeyWord")]    
        public string UrlKeyWord { get; set; }

        [Display(Name = "SEOImage")]
        public string SEOImage { get; set; }
    }
}
