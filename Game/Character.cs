﻿using LaCasaDelTerror.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Models
{
    public class Character
    {
        public static Dictionary<string, Character> roster = new Dictionary<string, Character>();

        static Character()
        {
            //Lista de personajes
        }

        public string name;
        public Stats stats;
    }
}
