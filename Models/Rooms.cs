using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Models
{
    public class Rooms
    {
        public Guid Id { get; set; }
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
        public int Floor { get; set; }
        [ForeignKey("Lobbies")]
        public string LobbyId { get; set; }
        public string RoomProtoype { get; set; }
        public bool PlayerActionAvailable { get; set; }

        public virtual Lobbies Lobby { get; set; }
    }
}
