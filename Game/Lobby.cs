using ProjectHamiltonService.Game;
using ProjectHamiltonService.Game.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static LaCasaDelTerror.Models.Server;


namespace LaCasaDelTerror.Models
{
    public class Lobbies
    {
        [Key]
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
    }
}
