using Microsoft.AspNetCore.Identity;
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
        public Guid Id { get; set; }
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int Sanity { get; set; }
        [Required]
        public int Physical { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int Bravery { get; set; }
        public int AvailableMoves { get; set; }
        [Required]
        public string CharacterPrototypeId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Lobbies")]
        public string LobbyId { get; set; }
        public int TurnThrowResult { get; set; }
        public int TurnIndex { get; set; }

        public virtual Lobbies Lobby { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual ThrowRequest AvailableThrowRequest { get; set; }
    }
}
