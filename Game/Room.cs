using LaCasaDelTerror.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Models
{
    public class Room
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

        public static Room[] topFloor =
        {
            new Room
            {
                name="Librería",
                type= Type.PUZZLE
            },
            new Room
            {
                name="Gimnasio",
                type= Type.PUZZLE
            },
            new Room
            {
                name="Oficina"
            },
            new Room
            {
                name="Cuarto de los niños"
            },
            new Room
            {
                name="Cuarto de los padres"
            },
            new Room
            {
                name="Enfermería",
                type= Type.PUZZLE
            },
            new Room {
                name="Cuarto de huespedes"
            },
            new Room
            {
                name="Cuarto de storage"
            },
            new Room
            {
                name="Piso con agujero",
                movesToFloor=new int[]{1}
            },
            new Room
            {
                name="Vault",
                type=Type.PUZZLE
            },
            new Room
            {
                name="Terraza",
                adjacentRoomBottom=false,
                adjacentRoomLeft=false,
                adjacentRoomTop=false
            },
            new Room
            {
                name="Biblioteca"
            },
            new Room
            {
                name="Cuarto de descanso"
            },
            new Room {
                name="Laboratorio"
            },
            new Room
            {
                name="Cuarto de juego de niños",
                type=Type.ITEM
            },
            new Room
            {
                name="Elevador",
                movesToFloor= new int[]{0, 1, 2}
            },
            new Room
            {
                name="Escaleras",
                movesToFloor= new int[]{1}
            }
        };

        public static Room[] basement =
        {
            new Room
            {
                name="Cuarto de almacenamiento",
                type=Type.PUZZLE
            },
            new Room
            {
                name="Calentadores de agua",
                adjacentRoomTop=false,
                type=Type.PUZZLE
            },
            new Room
            {
                name="Elevador",
            },
            new Room
            {
                name="Cuarto colapsado",
                statsEffects= new Stats
                {
                    sanity=0,
                    physical=-1,
                    intelligence=0,
                    balls=0
                }
            },
            new Room
            {
                name="Cuarto de vinos",
                type=Type.ITEM
            },
            new Room
            {
                name="Cuarto de monstruo",
                type=Type.PUZZLE
            },
            new Room {
                name="Cuarto de tesoro",
                type=Type.PUZZLE
            },
            new Room
            {
                name="Cuarto de armamento"
            },
            new Room
            {
                name="Lago subterraneo"
            },
            new Room
            {
                name="Cripta",
                type=Type.PUZZLE
            },
            new Room
            {
                name="Cuarto de tiradero"
            },
            new Room {
                name="Cuarto sangriento",
                statsEffects=new Stats
                {
                    sanity=-1
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
