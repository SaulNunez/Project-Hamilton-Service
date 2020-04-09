using LaCasaDelTerror.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Models
{
    public class Items
    {
        public static Dictionary<string, Items> items = new Dictionary<string, Items>();
        
        static Items()
        {
            items.Add("revolver", new Items
            {
                needsThrow=true,
                statEffects=new Stats
                {
                    physical=-1
                },
                singleUse=true
            });

            items.Add("magic_stone", new Items
            {
                singleUse=true,
                needsThrow=true
            });
            items.Add("small_totem", new Items { 
                statEffects=new Stats
                {
                    sanity=-1
                }
            });
            items.Add("sacrificial_dagger", new Items
            {
                needsThrow=true,
                //TODO: Agregar informacion de custom throw
                statEffects = new Stats{
                
                }
            });
            items.Add("buttler_key", new Items
            {
                specialItem=SpecialItems.KEY,
                singleUse=true
            });
            items.Add("adrenaline_shot", new Items
            {
                singleUse = true,
                statEffects = new Stats
                {
                    sanity = -1,
                    physical = 1,
                    balls = 2
                }
            });
        }

        public enum SpecialItems
        {
            KEY,
            LADDER,
            NONE
        }

        public bool needsThrow = false;
        public Stats? statEffects;
        public bool singleUse = false;
        public bool affectsOtherPlayer =  false;
        public SpecialItems specialItem = SpecialItems.NONE;
    }
}
