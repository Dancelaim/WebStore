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
    public class ArticleDetails
    {
        [HiddenInput]
        public System.Guid ArticleId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "ShortDescription")]
        public string ShortDescription { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "ReadTime")]
        public string ReadTime { get; set; }

        [Display(Name = "Tags")]
        public string Tags { get; set; }

        [HiddenInput]
        public Nullable<System.Guid> ProductGameId { get; set; }

        [HiddenInput]
        public Nullable<System.Guid> SEOId { get; set; }

        [Display(Name = "ImagePath")]
        public string ImagePath { get; set; }

        [Display(Name = "Enabled")]
        public Nullable<bool> Enabled { get; set; }

        [Display(Name = "Rating")]
        public Nullable<int> Rating { get; set; }

        [Display(Name = "ArticleCreateTime")]
        public DateTime? ArticleCreateTime { get; set; }

        [Display(Name = "ArticleUpdateTime")]
        public DateTime? ArticleUpdateTime { get; set; }

        [Display(Name = "ArticlePostTime")]
        public DateTime? ArticlePostTime { get; set; }



        /// <summary>
        /// List for Game
        /// </summary>
        [Display(Name = "Game name")]
        public SelectList GamesList { get; set; }

        [Required(ErrorMessage = "Product Game is required")]
        public string SelectedGame { get; set; }

        /// <summary>
        /// List for SEO
        /// </summary>
        [Display(Name = "Meta tag title")]
        public SelectList MetaTagTitleList { get; set; }
        public string SelectedMetaTagTitle { get; set; }
    }

}
