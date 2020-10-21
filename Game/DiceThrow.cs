using ProjectHamiltonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game
{
    public class DiceThrow
    {
        static readonly Random rand = new Random();

        public enum ThrowTypes
        {
            OneSixFaceDice,
            TwoSixFaceDice
        }

        public int DoThrow(ThrowTypes type)
        {
            if(type == ThrowTypes.OneSixFaceDice)
            {
                return rand.Next(1, 6);
            } else if(type == ThrowTypes.TwoSixFaceDice)
            {
                return rand.Next(1, 12);
            }

            return 0;
        }
    }
}
