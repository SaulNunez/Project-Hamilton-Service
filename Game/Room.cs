using LaCasaDelTerror.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Models
{
    class Room
    {
        public static Room[] mainFloor = {
            new Room
            {
                name="Commedor",
            },
            new Room
            {
                name="Cuarto de baile",
                adjacentRoomTop=false,
                type=Type.PUZZLE
            },
            new Room
            {
                name="Cocina",
                adjacentRoomTop=false,
            },
            new Room
            {
                name="Cuarto de lavado"
            },
            new Room
            {
                name="Conservatorio",
                adjacentRoomTop=false
            },
            new Room
            {
                name="Jardin",
                adjacentRoomLeft=false,
                adjacentRoomRight=false,
                adjacentRoomTop=false,
                type=Type.PUZZLE
            },
            new Room
            {
                name="Cuarto de conservas",
                type=Type.ITEM
            },
            new Room
            {
                name="Workshop",
            },
            new Room
            {
                name="Baño",
                type=Type.ITEM
            },
            new Room
            {
                name="Cuarto de mayordomo",
                type=Type.ITEM
            },
            new Room
            {
                name="Elevador",
                movesToFloor=new int[]{0,1,2 }
            },
            new Room
            {
                name="Entrada",
                movesToFloor=new int[]{2}
            },
            new Room
            {
                name="Cuarto colapsado",
                statsEffects= new Stats
                {
                    sanity= 0,
                    physical= -1,
                    intelligence= 0,
                    balls= 0
                }
            }
    };
    
        public enum Type
        {
            PUZZLE,
            ITEM,
            NONE
        }

        public string name;

        public Type type = Type.NONE;

        public bool adjacentRoomRight = true;
        public bool adjacentRoomLeft = true;
        public bool adjacentRoomTop = true;
        public bool adjacentRoomBottom = true;

        public Stats statsEffects;
        public int[] movesToFloor = Array.Empty<int>();
    }
}
