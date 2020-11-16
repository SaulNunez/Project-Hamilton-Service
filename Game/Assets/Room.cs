using LaCasaDelTerror.Assets.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Assets
{
    public class Rooms
    {
        public enum HouseFloors
        {
            BASEMENT = -1,
            MAIN_FLOOR = 0,
            TOP_FLOOR = 1
        }

        public static List<Rooms> mainFloor = new List<Rooms>(){
            new Rooms
            {
                id = "dinning_room",
                Name="Comedor",
            },
            new Rooms
            {
                id="ballroom",
                Name="Cuarto de baile",
                adjacentRoomTop=false,
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                id="kitchen",
                Name="Cocina",
                adjacentRoomTop=false,
            },
            new Rooms
            {
                id="lavado",
                Name="Cuarto de lavado"
            },
            new Rooms
            {   
                id="conservatory",
                Name="Conservatorio",
                adjacentRoomTop=false
            },
            new Rooms
            {
                id="garden",
                Name="Jardin",
                adjacentRoomLeft=false,
                adjacentRoomRight=false,
                adjacentRoomTop=false,
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                id="food_storage",
                Name="Cuarto de conservas",
                Type=RoomType.ITEM
            },
            new Rooms
            {
                id="workshop",
                Name="Taller",
            },
            new Rooms
            {
                id="bathroom",
                Name="Baño",
                Type=RoomType.ITEM
            },
            new Rooms
            {
                id="gunther_room",
                Name="Cuarto de mayordomo",
                Type=RoomType.ITEM
            },
            new Rooms
            {
                id="lift",
                Name="Elevador",
                MovesToFloor=new int[]{-1,1 },
                MovesToRoom="lift"
            },
            new Rooms
            {
                id="entrance",
                Name="Entrada",
                MovesToFloor=new int[]{1},
                MovesToRoom="stairs"
            },
            new Rooms
            {
                id="collapsed_room",
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
                id="library",
                Name="Librería",
                Type= RoomType.PUZZLE
            },
            new Rooms
            {
                id="gym",
                Name="Gimnasio",
                Type= RoomType.PUZZLE
            },
            new Rooms
            {
                id="office",
                Name="Oficina"
            },
            new Rooms
            {
                id="kids_room",
                Name="Cuarto de los niños"
            },
            new Rooms
            {
                id="parents_room",
                Name="Cuarto"
            },
            new Rooms
            {
                id="nursery",
                Name="Cuarto de cunas",
                Type= RoomType.PUZZLE
            },
            new Rooms {
                id="visits_room",
                Name="Cuarto de huespedes"
            },
            new Rooms
            {
                id="storage",
                Name="Cuarto de storage"
            },
            new Rooms
            {
                id="hole",
                Name="Piso con agujero",
                MovesToFloor=new int[]{0}
            },
            new Rooms
            {
                id="vault",
                Name="Vault",
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                id="terraza",
                Name="Terraza",
                adjacentRoomBottom=false,
                adjacentRoomLeft=false,
                adjacentRoomTop=false
            },
            new Rooms
            {
                id="laboratory",
                Name="Laboratorio"
            },
            new Rooms
            {
                id="relax_room",
                Name="Cuarto de descanso"
            },
            new Rooms {
                id="laboratory",
                Name="Laboratorio"
            },
            new Rooms
            {
                id="play_room",
                Name="Cuarto de juego de niños",
                Type=RoomType.ITEM
            },
            new Rooms
            {
                id="lift",
                Name="Elevador",
                MovesToFloor= new int[]{-1, 1},
                MovesToRoom="lift"
            },
            new Rooms
            {
                id="stairs",
                Name="Escaleras",
                MovesToFloor= new int[]{1}
            }
        };

        public static List<Rooms> basement = new List<Rooms>()
        {
            new Rooms
            {
                id="storage_room",
                Name="Cuarto de almacenamiento",
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                id="boilers",
                Name="Calefacción",
                adjacentRoomTop=false,
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                id="lift",
                Name="Elevador",
                MovesToFloor= new int[]{0, 1},
                MovesToRoom="lift"
            },
            new Rooms
            {
                id="colapsed_room",
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
                id="wines",
                Name="Cuarto de vinos",
                Type=RoomType.ITEM
            },
            new Rooms
            {
                id="monster",
                Name="Cuarto de monstruo",
                Type=RoomType.PUZZLE
            },
            new Rooms {
                id="treasure_room",
                Name="Cuarto de tesoro",
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                id="armery",
                Name="Cuarto de armamento"
            },
            new Rooms
            {
                id="subterranean_lake",
                Name="Lago subterraneo"
            },
            new Rooms
            {
                id="cript",
                Name="Cripta",
                Type=RoomType.PUZZLE
            },
            new Rooms
            {
                id="messy_room",
                Name="Cuarto de tiradero"
            },
            new Rooms {
                id="bloody_room",
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
        public string? MovesToRoom { get; set; } = null;
        public int[] MovesToFloor { get; set; }
        public int? MovesToPositionX { get; set; } = null;
        public int? MovesToPositionY { get; set; } = null;

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

        public static Rooms? FindRoom(HouseFloors floor, string id)
        {
            Rooms room = null;
            switch(floor){
                case HouseFloors.BASEMENT:
                    room = basement.Find(r => r.id == id);
                    break;
                case HouseFloors.MAIN_FLOOR:
                    room = mainFloor.Find(r => r.id == id);
                    break;
                case HouseFloors.TOP_FLOOR:
                    room = topFloor.Find(r => r.id == id);
                    break;
            }
            return room;
        }
    }
}
