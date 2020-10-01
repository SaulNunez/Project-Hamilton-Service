using LaCasaDelTerror.Assets;
using ProjectHamiltonService.Game.Abstracts;
using ProjectHamiltonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game
{
    public class MansionCreation
    {
        GameContext gameContext;

        public MansionCreation(GameContext gameContext)
        {
            this.gameContext = gameContext;
        }

        public async Task populateFloorAsync(string lobbyCode, List<LaCasaDelTerror.Assets.Rooms> floorRooms, int floorToPopulate)
        {
            List<Position> mainFloorOutline = new List<Position>() { new Position(0, 0) };
            var rooms = new List<Models.Rooms>();

            Random rnd = new Random();

            floorRooms.ForEach(room =>
            {
                var pos = mainFloorOutline[(int)Math.Floor((double)rnd.Next(mainFloorOutline.Count))];


                rooms.Add(new Models.Rooms
                {
                    X = pos.x,
                    Y = pos.y,
                    Floor = floorToPopulate,
                    LobbyId = lobbyCode,
                    RoomProtoype = room.id,
                    PlayerActionAvailable = true
                });

                var edges = new List<Position>();

                if (room.adjacentRoomRight)
                {
                    edges.Add(new Position(pos.x + 1, pos.y));
                }

                if (room.adjacentRoomLeft)
                {
                    edges.Add(new Position(pos.x - 1, pos.y));
                }

                if (room.adjacentRoomBottom)
                {
                    edges.Add(new Position(pos.x, pos.y - 1));
                }

                if (room.adjacentRoomTop)
                {
                    edges.Add(new Position(pos.x, pos.y + 1));
                }

                mainFloorOutline.Remove(pos);

                edges.ForEach((newPos) =>
                {
                    if (!mainFloorOutline.Contains(newPos)
                        && rooms.Find((room) => room.X == newPos.x && room.Y == newPos.y) == null)
                    {

                        mainFloorOutline.Add(newPos);
                    }
                });
            });


            gameContext.Rooms.AddRange(rooms);

            await gameContext.SaveChangesAsync();
        }
    }
}
