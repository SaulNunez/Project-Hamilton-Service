using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Assets.Abstracts
{
    public class Stats
    {
        public int Sanity { get; set; }
        public int Physical { get; set; }
        public int Intelligence { get; set; }
        public int Bravery { get; set; }

        [Obsolete]
        public static Stats operator +(Stats a, Stats b)
        => new Stats
        {
            Sanity = a.Sanity + b.Sanity,
            Physical = a.Physical + b.Physical,
            Intelligence = a.Intelligence + b.Intelligence,
            Bravery = a.Bravery + b.Bravery
        };

        [Obsolete]
        public static Stats operator -(Stats a, Stats b)
        => new Stats
        {
            Sanity = a.Sanity - b.Sanity,
            Physical = a.Physical - b.Physical,
            Intelligence = a.Intelligence - b.Intelligence,
            Bravery = a.Bravery - b.Bravery
        };
    }
}
