using LaCasaDelTerror.Assets.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Assets
{
    public class Items
    {
        public static List<Items> items = new List<Items>()
        {
            new Items
            {
                id = "revolver",
                statEffects=new Stats
                {
                    Physical=-1
                },
                singleUse=true
            },
            new Items
            {
                id = "magic_stone",
                singleUse =true,
                needsThrow=true
            },
            new Items {
                id = "small_totem",
                statEffects=new Stats
                {
                    Sanity=-1
                }
            },
            new Items
            {
                id= "sacrificial_dagger",
                needsThrow =true,
                //TODO: Agregar informacion de custom throw
            },
            new Items
            {
                id= "buttler_key",
                specialItem =SpecialEffect.KEY,
                singleUse=true
            },
            new Items
            {
                id= "adrenaline_shot",
                singleUse = true,
                statEffects = new Stats
                {
                    Physical = 1
                }
            }
        };

        public enum SpecialEffect
        {
            NONE,
            KEY,
            LADDER,
            TELETRANSPORT
        }

        public string id;
        public bool needsThrow = false;
        public Stats statEffects;
        public bool singleUse = false;
        public bool affectsOtherPlayer =  false;
        public SpecialEffect specialItem = SpecialEffect.NONE;
    }
}
