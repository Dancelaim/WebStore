//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WowCarry.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SEO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEO()
        {
            this.ProductCategory = new HashSet<ProductCategory>();
            this.ProductGame = new HashSet<ProductGame>();
            this.ProductSubCategory = new HashSet<ProductSubCategory>();
            this.Product = new HashSet<Product>();
        }
    
        public System.Guid SEOId { get; set; }
        public string MetaTagTitle { get; set; }
        public string MetaTagDescription { get; set; }
        public string MetaTagKeyWords { get; set; }
        public string SEOTags { get; set; }
        public string CustomTitle1 { get; set; }
        public string CustomTitle2 { get; set; }
        public string CustomImageTitle { get; set; }
        public string CustomImageAlt { get; set; }
        public string MetaRobots { get; set; }
        public string UrlKeyWord { get; set; }
        public string SEOImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductGame> ProductGame { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductSubCategory> ProductSubCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
