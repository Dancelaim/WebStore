//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WowCarry.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        public System.Guid ArticleId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ReadTime { get; set; }
        public string Tags { get; set; }
        public Nullable<System.Guid> ProductGameId { get; set; }
        public Nullable<System.Guid> SEOId { get; set; }
        public string ImagePath { get; set; }
        public Nullable<bool> Enabled { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<System.DateTime> ArticleCreateTime { get; set; }
        public Nullable<System.DateTime> ArticleUpdateTime { get; set; }
        public System.DateTime ArticlePostTime { get; set; }
    
        public virtual ProductGame ProductGame { get; set; }
        public virtual SEO SEO { get; set; }
    }
}
