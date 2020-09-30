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
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationTime { get; set; }
        public bool OnProgress { get; set; }
        
        [ForeignKey("Players")]
        public virtual Players CurrentPlayer { get; set; }
    }
}
