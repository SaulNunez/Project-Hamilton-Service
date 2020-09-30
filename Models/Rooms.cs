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
        public Guid id;
        [Required]
        public int x;
        [Required]
        public int y;
        public int floor;
        [ForeignKey("Lobbies")]
        public string lobbyId;
        public string roomProtoype;
        public bool playerActionAvailable;

        public Lobbies lobby;
    }
}
