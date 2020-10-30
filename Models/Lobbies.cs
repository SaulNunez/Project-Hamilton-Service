 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Models
{
    public class Lobbies
    {
        [Key]
        public string Code { get; set; }
        public DateTime CreationTime { get; set; }
        public bool OnProgress { get; set; }
        
        public Guid PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public virtual Players CurrentPlayer { get; set; }

        public virtual List<Rooms> Rooms { get; set; }
        public virtual List<Players> Players { get; set; }
    }
}
