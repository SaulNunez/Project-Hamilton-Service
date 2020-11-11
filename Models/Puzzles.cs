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

        //Acciones en juego de respuesta correcta
        public int BraveryStatDiff { get; set; }
        public int IntelligenceStatDiff { get; set; }
        public int SanityStatDiff { get; set; }
        public int PhysicalStatDiff { get; set; }
        
        [NotMapped]
        public bool ModifiesStats { get => BraveryStatDiff > 0 || IntelligenceStatDiff > 0 || SanityStatDiff > 0 || PhysicalStatDiff > 0; }


        public int NewX { get; set; }
        public int NewY { get; set; }


        public int NewFloor { get; set; }

        [NotMapped]
        public bool ModifiesPosition { get => NewX != -1 || NewY != -1 || NewFloor != -1; }
    }
}
