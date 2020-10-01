using LaCasaDelTerror.Assets.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Assets
{
    public class Rooms
    {
        public static List<Rooms> mainFloor = new List<Rooms>(){
            new Rooms
            {
                Name="Commedor",
            },
            new Rooms
            {
                Name="Cuarto de baile",
                adjacentRoomTop=false,
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                Name="Cocina",
                adjacentRoomTop=false,
            },
            new Rooms
            {
                Name="Cuarto de lavado"
            },
            new Rooms
            {
                Name="Conservatorio",
                adjacentRoomTop=false
            },
            new Rooms
            {
                Name="Jardin",
                adjacentRoomLeft=false,
                adjacentRoomRight=false,
                adjacentRoomTop=false,
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                Name="Cuarto de conservas",
                Type=RoomType.ITEM
            },
            new Rooms
            {
                Name="Workshop",
            },
            new Rooms
            {
                Name="Baño",
                Type=RoomType.ITEM
            },
            new Rooms
            {
                Name="Cuarto de mayordomo",
                Type=RoomType.ITEM
            },
            new Rooms
            {
                Name="Elevador",
                MovesToFloor=new int[]{-1,0,1 }
            },
            new Rooms
            {
                Name="Entrada",
                MovesToFloor=new int[]{1}
            },
            new Rooms
            {
                Name="Cuarto colapsado",
                StatsEffects= new Stats
                {
                    Sanity= 0,
                    Physical= -1,
                    Intelligence= 0,
                    Bravery= 0
                }
            }
        };

        public static List<Rooms> topFloor = new List<Rooms>()
        {
            new Rooms
            {
                Name="Librería",
                Type= RoomType.PUZZLE
            },
            new Rooms
            {
                Name="Gimnasio",
                Type= RoomType.PUZZLE
            },
            new Rooms
            {
                Name="Oficina"
            },
            new Rooms
            {
                Name="Cuarto de los niños"
            },
            new Rooms
            {
                Name="Cuarto de los padres"
            },
            new Rooms
            {
                Name="Enfermería",
                Type= RoomType.PUZZLE
            },
            new Rooms {
                Name="Cuarto de huespedes"
            },
            new Rooms
            {
                Name="Cuarto de storage"
            },
            new Rooms
            {
                Name="Piso con agujero",
                MovesToFloor=new int[]{0}
            },
            new Rooms
            {
                Name="Vault",
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                Name="Terraza",
                adjacentRoomBottom=false,
                adjacentRoomLeft=false,
                adjacentRoomTop=false
            },
            new Rooms
            {
                Name="Biblioteca"
            },
            new Rooms
            {
                Name="Cuarto de descanso"
            },
            new Rooms {
                Name="Laboratorio"
            },
            new Rooms
            {
                Name="Cuarto de juego de niños",
                Type=RoomType.ITEM
            },
            new Rooms
            {
                Name="Elevador",
                MovesToFloor= new int[]{-1, 0, 1}
            },
            new Rooms
            {
                Name="Escaleras",
                MovesToFloor= new int[]{1}
            }
        };

        public static List<Rooms> basement = new List<Rooms>()
        {
            new Rooms
            {
                Name="Cuarto de almacenamiento",
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                Name="Calentadores de agua",
                adjacentRoomTop=false,
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                Name="Elevador",
            },
            new Rooms
            {
                Name="Cuarto colapsado",
                StatsEffects= new Stats
                {
                    Sanity=0,
                    Physical=-1,
                    Intelligence=0,
                    Bravery=0
                }
            },
            new Rooms
            {
                Name="Cuarto de vinos",
                Type=RoomType.ITEM
            },
            new Rooms
            {
                Name="Cuarto de monstruo",
                Type=RoomType.PUZZLE
            },
            new Rooms {
                Name="Cuarto de tesoro",
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                Name="Cuarto de armamento"
            },
            new Rooms
            {
                Name="Lago subterraneo"
            },
            new Rooms
            {
                Name="Cripta",
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                Name="Cuarto de tiradero"
            },
            new Rooms {
                Name="Cuarto sangriento",
                StatsEffects=new Stats
                {
                    Sanity=-1
                }
            }
        };


        public enum RoomType
        {
            PUZZLE,
            ITEM,
            NONE
        }

        public string Name { get; set; }

        public RoomType Type { get; set; } = RoomType.NONE;

        /// <summary>
        /// Usado para saber si es legal establecer cuartos a un lado de este
        /// </summary>
        public bool adjacentRoomRight = true;
        /// <summary>
        /// Usado para saber si es legal establecer cuartos a un lado de este
        /// </summary>
        public bool adjacentRoomLeft = true;
        /// <summary>
        /// Usado para saber si es legal establecer cuartos a un lado de este
        /// </summary>
        public bool adjacentRoomTop = true;
        /// <summary>
        /// Usado para saber si es legal establecer cuartos a un lado de este
        /// </summary>
        public bool adjacentRoomBottom = true;
        public string id;

        /// <summary>
        /// Usado para saber si es legal establecer cuartos a un lado de este
        /// </summary>

        public Stats StatsEffects { get; set; }
        public int[] MovesToFloor { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Floor { get; set; }

        struct Position
        {
            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int x;
            public int y;
        }
    }
}
