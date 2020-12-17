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
    
    public partial class ProductOptionParams
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductOptionParams()
        {
            this.ProductOptionParamsParent = new HashSet<ProductOptionParams>();
        }
    
        public System.Guid ParameterId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterTooltip { get; set; }
        public decimal ParameterPrice { get; set; }
        public Nullable<System.Guid> ParentOptionId { get; set; }
        public string ParameterSale { get; set; }
        public Nullable<System.Guid> ParameterParentId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOptionParams> ProductOptionParamsParent { get; set; }
        public virtual ProductOptionParams ProductOptionParamsChild { get; set; }
        public virtual ProductOptions ProductOptions { get; set; }
    }
}
