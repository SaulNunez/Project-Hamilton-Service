using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Models.Abstracts
{
    class Stats
    {
        public int sanity;
        public int physical;
        public int intelligence;
        public int balls;

        public static Stats operator +(Stats a, Stats b)
        => new Stats
        {
            sanity = a.sanity + b.sanity,
            physical = a.physical + b.physical,
            intelligence = a.intelligence + b.intelligence,
            balls = a.balls + b.balls
        };

        public static Stats operator -(Stats a, Stats b)
        => new Stats
        {
            sanity = a.sanity - b.sanity,
            physical = a.physical - b.physical,
            intelligence = a.intelligence - b.intelligence,
            balls = a.balls - b.balls
        };
    }
}
