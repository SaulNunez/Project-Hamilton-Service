using ProjectHamiltonService.Game.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaCasaDelTerror.Models
{
    public class Lobby
    {
        private const string db = "juego.sqlite";

        private string[] character = { "char1", "char2", "char3", "char4" };

        public string name;
        public List<Players> players = new List<Players>();
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

        }

        public string[] AvailableCharacters()
        {
            var characters = new List<string>();
            return characters.ToArray();
        }

        public void AddPlayer(string characterProtype)
        {
            if (character.Contains(characterProtype))
            {
                return;
            }
            //players.Add(new Players());
        }

        public void UseItem(string itemName)
        {
            //Tener lista de items en player
            //Revisar si tiene item
            //Si si, afecta jugador que nos mando el shit
        }

        public void MoveRight(string hubCode)
        {
           
        }

        public void MoveLeft(string hubCode)
        {

        }

        public void MoveTop(string hubCode)
        {

        }

        public void MoveBottom(string hubCode)
        {

        }
    }
}
