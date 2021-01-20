using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WowCarry.Domain.Entities
{
    public class OrderDetails
    {
        [HiddenInput]
        public System.Guid OrderId { get; set; }

        [HiddenInput]
        public Nullable<System.Guid> CustomerId { get; set; }

        [HiddenInput]
        public Nullable<System.Guid> OrderCustomFieldsId { get; set; }

        [Display(Name = "PaymentMethod")]
        public string PaymentMethod { get; set; }

        [Display(Name = "PaymentCode")]
        public string PaymentCode { get; set; }

        [Display(Name = "Total")]
        public Nullable<decimal> Total { get; set; }

        [Display(Name = "OrderStatus")]
        public string OrderStatus { get; set; }

        [Display(Name = "Currency")]
        public string Currency { get; set; }

        [Display(Name = "CustomerIP")]
        public string CustomerIP { get; set; }

        [Display(Name = "UserAgent")]
        public string UserAgent { get; set; }

        [Display(Name = "OrderCreateTime")]
        public Nullable<System.DateTime> OrderCreateTime { get; set; }

        [Display(Name = "OrderUpdateTime")]
        public Nullable<System.DateTime> OrderUpdateTime { get; set; }

        [Display(Name = "EmailSended")]
        public Nullable<bool> EmailSended { get; set; }

        [Display(Name = "EmailSendTime")]
        public Nullable<System.DateTime> EmailSendTime { get; set; }

        [Display(Name = "CarryCoinsSpent")]
        public Nullable<decimal> CarryCoinsSpent { get; set; }

        [Display(Name = "CarryCoinsCollected")]
        public Nullable<decimal> CarryCoinsCollected { get; set; }

        [Key]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "The email address is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string Email { get; set; }

        [Display(Name = "Discord(Optional)")]
        public string Discord { get; set; }

        [Display(Name = "Add your comments (optional)")]
        public string Comments { get; set; }

        [Required(ErrorMessage = "Character name is required")]
        [Display(Name = "Character name")]
        public string Wow_CharacterName { get; set; }

        [Required(ErrorMessage = "Realm(server) name is required")]
        [Display(Name = "Realm(server) name")]
        public string Wow_RealmName { get; set; }

        [Required(ErrorMessage = "Faction is required")]
        [Display(Name = "Faction")]
        public Faction Wow_Faction { get; set; }

        [Required(ErrorMessage = "Region is required")]
        [Display(Name = "Region")]
        public Region Wow_Region { get; set; }

        [Display(Name = "Battle tag (optional)")]
        public string Wow_BattleTag { get; set; }

        [Required(ErrorMessage = "Character name is required")]
        [Display(Name = "Character name")]
        public string Classic_CharacterName { get; set; }

        [Required(ErrorMessage = "Realm(server) name is required")]
        [Display(Name = "Realm(server) name")]
        public string Classic_RealmName { get; set; }

        [Required(ErrorMessage = "Faction is required")]
        [Display(Name = "Faction")]
        public string Classic_Faction { get; set; }

        [Required(ErrorMessage = "Region is required")]
        [Display(Name = "Region")]
        public string Classic_Region { get; set; }

        [Display(Name = "Battle tag (optional)")]
        public string Classic_BattleTag { get; set; }

        [Required(ErrorMessage = "Character name is required")]
        [Display(Name = "Character name")]
        public string Poe_CharacterName { get; set; }

        [Required(ErrorMessage = "Account name is required")]
        [Display(Name = "Account name")]
        public string Poe_AccountName { get; set; }

        [Display(Name = "ShlCharacterName")]
        public string ShlCharacterName { get; set; }

        [Display(Name = "ShlRealmName")]
        public string ShlRealmName { get; set; }

        [Display(Name = "ShlFaction")]
        public string ShlFaction { get; set; }

        [Display(Name = "ShlRegion")]
        public string ShlRegion { get; set; }

        [Display(Name = "ShlBattleTag")]
        public string ShlBattleTag { get; set; }
    }
    public enum Faction
    {
        Horde = 0,
        Alliance = 1
    }
    public enum Region
    {
        EU = 0,
        US = 1
    }
}
