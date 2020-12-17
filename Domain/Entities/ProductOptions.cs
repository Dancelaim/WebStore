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
    
    public partial class ProductOptions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductOptions()
        {
            this.ProductOptionParams = new HashSet<ProductOptionParams>();
            this.ProductOptionsChild = new HashSet<ProductOptions>();
        }
    
        public System.Guid OptionId { get; set; }
        public string OptionName { get; set; }
        public string OptionType { get; set; }
        public Nullable<System.Guid> OptionParentId { get; set; }
        public Nullable<System.Guid> OptionProductId { get; set; }
    
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOptionParams> ProductOptionParams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOptions> ProductOptionsChild { get; set; }
        public virtual ProductOptions ProductOptionsParent { get; set; }
    }
}
