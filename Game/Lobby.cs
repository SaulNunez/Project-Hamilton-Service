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
        public string Code { get; set; }
        public List<Players> Players { get; set; }
        public List<Rooms> Rooms { get; set; }

        public int CurrentPlayers {
            get
        {
            return Players.Count;
        }
}
        /// <summary>
        /// Indice del jugador actual que tiene su partida. Indice corresponde a su posicion en la lista de players
        /// </summary>
        public int currentMoveServerPlayerIndex = 0;
        
        private Lobby()
        {
            Code = "ABCD";
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
            Players.Add(player);

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
            return true;
        }

        public int Move(string verificationCode, Direction direction)
        {
            if (IsCodeForCurrentTurn(verificationCode))
            {

                var affectedPlayer = Players[currentMoveServerPlayerIndex];
                switch (direction)
                {
                    case Direction.DOWN:
                        affectedPlayer.Y--;
                        break;
                    case Direction.UP:
                        affectedPlayer.Y++;
                        break;
                    case Direction.LEFT:
                        affectedPlayer.X--;
                        break;
                    case Direction.RIGHT:
                        affectedPlayer.X++;
                        break;
                }
                affectedPlayer.PositionsMoved++;
                return affectedPlayer.CurrentThrow + affectedPlayer.PositionsMoved;
            } else
            {
                return -1;
            }
        }
    }
}
