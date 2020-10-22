using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderDetails
    {
        public string Email { get; set; }
        public string Discord { get; set; }
        public string CharacterName { get; set; }
        public string RealmName { get; set; }
        public Faction Faction { get; set; }
        public Region Region { get; set; }
        public string BattleTag { get; set; }
        public string ClassicCharacterName { get; set; }
        public string ClassicRealmName { get; set; }
        public string ClassicFaction { get; set; }
        public string ClassicRegion { get; set; }
        public string ClassicBattleTag { get; set; }
        public string PoeCharacterName { get; set; }
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
