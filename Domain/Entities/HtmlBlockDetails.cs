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
    public class HtmlBlockDetails
    {
        [HiddenInput]
        public Guid SiteBlockId { get; set; }

        [Required(ErrorMessage = "Wrong CSS Class")]
        [Display(Name = "CSS")]
        public string ParentCSSClass { get; set; }

        [Display(Name = "Parent Title")]
        public string ParentTitle { get; set; }

        [Display(Name = "Child CSS Class")]
        public string ChildCSSClass { get; set; }

        [Display(Name = "Site Page")]
        public string SitePage { get; set; }

        [Display(Name ="Order")]
        public Nullable<decimal> Order { get; set; }

        public List<HtmlBlockChildrenDetails> HtmlBlockChildDetailsCollection { get; set; }
        public class HtmlBlockChildrenDetails
        {
            [HiddenInput]
            public Guid SiteBlockChildsId { get; set; }

            [Display(Name = "Text")]
            public string Text { get; set; }

            [Display(Name = "Title")]
            public string Title { get; set; }

            [Display(Name = "Image")]
            public string Image { get; set; }

            [Display(Name = "CSSClass")]
            public string CSSClass { get; set; }

            [Display(Name = "ChildOrder")]
            public Nullable<decimal> ChildOrder { get; set; }
        }
        public static List<HtmlBlockChildrenDetails> PopulateHtmlBlockCollection(HtmlBlocks htmlblocks)
        {
            List<HtmlBlockChildrenDetails> result = new List<HtmlBlockChildrenDetails>();
            foreach (var item in htmlblocks.HtmlBlocksChildren)
            {
                result.Add(new HtmlBlockChildrenDetails
                {
                    SiteBlockChildsId = item.SiteBlockChildsId,
                    Text = item.Text,
                    Title = item.Title,
                    Image = item.Image,
                    CSSClass = item.CSSClass,
                    ChildOrder = item.ChildOrder
                });
            }
            return result;
        }

    }
}
