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
                name="Revolver",
                description="Una pistola con unos cuantos tiros. Es un arma para defensa personal. Útil cuando otro jugador en el cuarto o un cuarto inmediatamente aledaño, también puedes dispararte en el pie, no juzgamos. Tira un dado de 6 al usar el arma, si es 2 o menor se encasquillo el arma, no hay tiro. Produce 1 de daño físico a quien va dirigido.",
                statEffects=new Stats
                {
                    Physical=-1
                },
                category= PuzzleCategory.StatsChange,
                singleUse=true
            },
            new Items
            {
                id = "magic_stone",
                name= "Piedra mágica",
                description="Si no te gusto el número que obtuviste, puedes hacer otro tiro de dado.",
                category= PuzzleCategory.ThrowChange,
                singleUse =true,
                needsThrow=true
            },
            new Items {
                id = "small_totem",
                name= "Totem pequeño",
                description="Cada vez por turno podrás tocar el Tótem antes de hacer cualquier cosa que requiera el dado para agregar 2 a ese tiro. ",
                category= PuzzleCategory.ThrowChange,
                statEffects=new Stats
                {
                    Sanity=-1
                }
            },
            new Items
            {
                id= "sacrificial_dagger",
                name="Daga sacrificial",
                description= "Lesiona a un contrincante si están en el mismo cuarto. Uno de daño físico.",
                category= PuzzleCategory.StatsChange,
                needsThrow =true,
                //TODO: Agregar informacion de custom throw
            },
            new Items
            {
                id= "buttler_key",
                name="Llave del mayordomo",
                singleUse=true,
                description="Abre cualquier puerta o cofre",
                category= PuzzleCategory.Key
            },
            new Items
            {
                id= "cuerda",
                name= "Cuerda",
                singleUse=true,
                description="En el sótano te permite subir al piso con agujero, siempre que haya sido descubierto",
                category=PuzzleCategory.MovementMod

            },
            new Items
            {
                id= "adrenaline_shot",
                name="Jeringa de adrenalina",
                description="Aumenta valentía por 2",
                category= PuzzleCategory.StatsChange,
                singleUse = true,
                statEffects = new Stats
                {
                    Physical = 1
                }
            },
            new Items
            {
                id="battery",
                name="Una pila tipo C",
                description="Útil para tu linterna en caso de repuestos",
                category=PuzzleCategory.PlayerImpact,
                singleUse=true
            }
        };

        public enum PuzzleCategory
        {
            StatsChange,
            ThrowChange,
            MovementMod,
            PlayerImpact,
            Key
        }

        public string id;
        public string name;
        public string description;
        public bool needsThrow = false;
        public Stats statEffects;
        public PuzzleCategory category;
        public bool singleUse = false;
        public bool affectsOtherPlayer = false;
    }
}
