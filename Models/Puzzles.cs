using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Models
{
    public class Puzzles
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime PuzzleStart { get; set; }
        public DateTime PuzzleEnd { get; set; }
        [ForeignKey("Players")]
        public Guid PlayersId { get; set; }
        public string PuzzlePrototype { get; set; }
        public bool SolvedCorrectly { get; set; }
    }
}
