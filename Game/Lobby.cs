using ProjectHamiltonService.Game;
using ProjectHamiltonService.Game.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LaCasaDelTerror.Models
{
    public class Lobby
    {

        private string[] character = { "char1", "char2", "char3", "char4" };

        public string name;
        public List<ServerPlayer> players = new List<ServerPlayer>();
        public Dictionary<Position,Room> topFloor = new Dictionary<Position, Room>();
        public Dictionary<Position, Room> mainFloor = new Dictionary<Position, Room>();
        public Dictionary<Position, Room> basement = new Dictionary<Position, Room>();

        public int currentPlayers {
            get
        {
            return players.Count;
        }
}
        public int turnOf = 0;
        
        public Lobby(string lobby)
        {
            name = lobby;
        }

        private void SetupRooms()
        {
            foreach(var room in Room.mainFloor)
            {

            }
        }

        public List<Character> AvailableCharacters()
        {
            //TODO: Hacer una implementacion completa
            return new List<Character>();
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
            if (character.Contains(characterPrototypeId))
            {
                return null;
            }

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
            return players[turnOf].code == code;
        }

        public int MoveHorizontal(string verificationCode, int direction)
        {
            if (IsCodeForCurrentTurn(verificationCode))
            {
                //Para que siempre sea -1, 0 o 1
                direction = Math.Sign(direction);

                var affectedPlayer = players[turnOf];
                affectedPlayer.position.x += direction;
                affectedPlayer.positionsMoved++;
                return affectedPlayer.currentThrow + affectedPlayer.positionsMoved;
            } else
            {
                return -1;
            }
        }
        
        public int MoveVertical(string verificationCode, int direction)
        {
            if (IsCodeForCurrentTurn(verificationCode))
            {
                //Para que siempre sea -1, 0 o 1
                direction = Math.Sign(direction);

                var affectedPlayer = players[turnOf];
                affectedPlayer.position.y += direction;
                affectedPlayer.positionsMoved++;
                return affectedPlayer.currentThrow + affectedPlayer.positionsMoved;
            }
            else
            {
                return -1;
            }
        }
    }
}
