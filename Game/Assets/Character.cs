using LaCasaDelTerror.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Models
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
