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
        public Faction Classic_Faction { get; set; }

        [Required(ErrorMessage = "Region is required")]
        [Display(Name = "Region")]
        public Region Classic_Region { get; set; }

        [Display(Name = "Battle tag (optional)")]
        public string Classic_BattleTag { get; set; }

        [Required(ErrorMessage = "Character name is required")]
        [Display(Name = "Character name")]
        public string Poe_CharacterName { get; set; }

        [Required(ErrorMessage = "Account name is required")]
        [Display(Name = "Account name")]
        public string Poe_AccountName { get; set; }
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
