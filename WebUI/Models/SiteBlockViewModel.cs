using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WowCarry.Domain.Entities;

namespace WebUI.Models
{
    public class SiteBlockViewModel
    {
        public IEnumerable<HtmlBlocks> HtmlBlocks { get; set; }
        public IEnumerable<HtmlBlocksChildren> HtmlBlocksChildren { get; set; }
    }
}