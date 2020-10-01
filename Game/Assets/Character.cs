using LaCasaDelTerror.Assets.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Assets
{
    public class Character
    {
        public static List<Character> roster = new List<Character>
        {

        };

        static Character()
        {
            //Lista de personajes
        }

        public string name;
        public Stats stats;
        public string description;
        public string id;
    }
}
