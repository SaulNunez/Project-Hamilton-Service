using ProjectHamiltonService.Game;
using ProjectHamiltonService.Game.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static LaCasaDelTerror.Models.Server;

namespace LaCasaDelTerror.Models
{
    public class Lobby
    {
        public string code { get; private set; }
        public List<ServerPlayer> players = new List<ServerPlayer>();
        public Dictionary<Position,Room> topFloor = new Dictionary<Position, Room>();
        public Dictionary<Position, Room> mainFloor = new Dictionary<Position, Room>();
        public Dictionary<Position, Room> basement = new Dictionary<Position, Room>();

        public int CurrentPlayers {
            get
        {
            return players.Count;
        }
}
        /// <summary>
        /// Indice del jugador actual que tiene su partida. Indice corresponde a su posicion en la lista de players
        /// </summary>
        public int currentMoveServerPlayerIndex = 0;
        
        public Lobby()
        {
            code = "ABCD";
        }

        private static readonly HttpClient client = new HttpClient();
        public async Task<bool> CheckPuzzle(string code, string verificationCode)
        {
            if (IsCodeForCurrentTurn(verificationCode))
            {
                //TODO: Cuando este terminada esa API llenar el JSON del request
                var values = new Dictionary<string, string>
                {
                { "code", code },
                { "type", "world" }
                };

                var content = new FormUrlEncodedContent(values);

                //Cambiar dirección del servidor
                var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

                var responseString = await response.Content.ReadAsStringAsync();
            }

            return true;
        }


        public string? AddPlayer(string characterPrototypeId)
        {
            //if (character.Contains(characterPrototypeId))
            //{
            //    return null;
            //}

            var player = new ServerPlayer(Character.roster[characterPrototypeId]);
            players.Add(player);

            return player.code;
        }

        public Players GetPlayer()
        {
            return null;
        }

        public void UseItem(string verification, string itemName)
        {
            //Tener lista de items en player
            //Revisar si tiene item
            //Si si, afecta jugador que nos mando el shit
        }

        public bool IsCodeForCurrentTurn(string code)
        {
            return players[currentMoveServerPlayerIndex].code == code;
        }

        public int Move(string verificationCode, Direction direction)
        {
            if (IsCodeForCurrentTurn(verificationCode))
            {

                var affectedPlayer = players[currentMoveServerPlayerIndex];
                switch (direction)
                {
                    case Direction.DOWN:
                        affectedPlayer.position.y--;
                        break;
                    case Direction.UP:
                        affectedPlayer.position.y++;
                        break;
                    case Direction.LEFT:
                        affectedPlayer.position.x--;
                        break;
                    case Direction.RIGHT:
                        affectedPlayer.position.x++;
                        break;
                }
                affectedPlayer.positionsMoved++;
                return affectedPlayer.currentThrow + affectedPlayer.positionsMoved;
            } else
            {
                return -1;
            }
        }
    }
}
