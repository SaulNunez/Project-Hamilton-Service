using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Models
{
    public class Players
    {
        public Guid id;
        [Required]
        public int x;
        [Required]
        public int y;
        [Required]
        public int floor;
        [Required]
        public int sanity;
        [Required]
        public int physical;
        [Required]
        public int intelligence;
        [Required]
        public int bravery;
        public int availableMoves;
        [Required]
        public string characterPrototypeId;
        public string name;
        [ForeignKey("Lobbies")]
        public string lobbyId;

        public Lobbies lobby;
    }
}
