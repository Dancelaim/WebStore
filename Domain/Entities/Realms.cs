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
    
    public partial class Realms
    {
        public System.Guid RealmId { get; set; }
        public System.Guid ProductGameId { get; set; }
        public string RealmName { get; set; }
    
        public virtual ProductGame ProductGame { get; set; }
    }
}
