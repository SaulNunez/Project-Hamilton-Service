using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ClientRequestModels
{
    public class ShowPuzzleRequest
    {
        public ShowPuzzleRequest(Puzzles puzzle)
        {
            Instructions = puzzle.instructions;
            Documentation = puzzle.documentation;
            InitialWorkspaceConfiguration = puzzle.GetWorkspaceXmlFromFile();
            PuzzleId = puzzle.id;
        }

        public string Instructions { get; set; }
        public string Documentation { get; set; }
        public string InitialWorkspaceConfiguration { get; set; }
        public string PuzzleId { get; set; }
    }
}
