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
    
    public partial class ProductOptionParams
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductOptionParams()
        {
            this.ProductOptionParams1 = new HashSet<ProductOptionParams>();
        }
    
        public System.Guid ParameterId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterTooltip { get; set; }
        public decimal ParameterPrice { get; set; }
        public Nullable<System.Guid> ParentOptionId { get; set; }
        public string ParameterSale { get; set; }
        public Nullable<System.Guid> ParameterParentId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOptionParams> ProductOptionParams1 { get; set; }
        public virtual ProductOptionParams ProductOptionParams2 { get; set; }
    }
}
