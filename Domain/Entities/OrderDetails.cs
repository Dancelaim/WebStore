using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowCarry.Domain.Entities
{
    public class OrderDetails
    {
        [Key]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "The email address is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string Email { get; set; }
        [Display(Name = "Discord(Optional)")]
        public string Discord { get; set; }
        [Required(ErrorMessage = "Character name is required")]
        [Display(Name = "Character name")]
        public string CharacterName { get; set; }
        [Required(ErrorMessage = "Realm(server) name is required")]
        [Display(Name = "Realm(server) name")]
        public string RealmName { get; set; }
        [Required(ErrorMessage = "Faction is required")]
        public Faction Faction { get; set; }
        [Required(ErrorMessage = "Region is required")]
        public Region Region { get; set; }
        [Display(Name = "Battle tag (optional)")]
        public string BattleTag { get; set; }
        [Required(ErrorMessage = "Character name is required")]
        [Display(Name = "Character name")]
        public string ClassicCharacterName { get; set; }
        [Required(ErrorMessage = "Realm(server) name is required")]
        [Display(Name = "Realm(server) name")]
        public string ClassicRealmName { get; set; }
        [Required(ErrorMessage = "Faction is required")]
        public string ClassicFaction { get; set; }
        [Required(ErrorMessage = "Region is required")]
        public string ClassicRegion { get; set; }
        [Display(Name = "Battle tag (optional)")]
        public string ClassicBattleTag { get; set; }
        [Required(ErrorMessage = "Character name is required")]
        [Display(Name = "Character name")]
        public string PoeCharacterName { get; set; }
        [Required(ErrorMessage = "Account name is required")]
        [Display(Name = "Account name")]
        public string PoeAccountName { get; set; }
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
