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
    
    public partial class ProductPrice
    {
        public System.Guid ProductPriceId { get; set; }
        public string Region { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> MaxPrice { get; set; }
        public Nullable<decimal> MinPrice { get; set; }
        public System.Guid ProductId { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
