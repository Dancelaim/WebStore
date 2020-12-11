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
            this.ProductOptionParams1 = new HashSet<ProductOptionParams>();
        }
    
        public System.Guid OptionParamsId { get; set; }
        public string ParamName { get; set; }
        public string ParamTooltip { get; set; }
        public decimal ParamPrice { get; set; }
        public Nullable<System.Guid> ProductOptionId { get; set; }
        public string Sale { get; set; }
        public Nullable<System.Guid> ParamParentId { get; set; }
    
        public virtual ProductOptions ProductOptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOptionParams> ProductOptionParams1 { get; set; }
        public virtual ProductOptionParams ProductOptionParams2 { get; set; }
    }
}
