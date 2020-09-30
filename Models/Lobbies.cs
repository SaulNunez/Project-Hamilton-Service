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
        public string code;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime creationTime;
        public bool onProgress;
    }
}
