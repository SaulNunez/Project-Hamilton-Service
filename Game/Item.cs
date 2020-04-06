using LaCasaDelTerror.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Models
{
    public class Items
    {
        public enum SpecialItems
        {
            KEY,
            LADDER,
            NONE
        }

        public Stats? statEffects;
        public bool singleUse = false;
        public bool affectsOtherPlayer =  false;
        public SpecialItems specialItem = SpecialItems.NONE;
    }
}
