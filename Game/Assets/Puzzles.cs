using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game
{
    public class Puzzles
    {
        public enum Type
        {
            Variables,
            Conditionals,
            Cycles,
            Functions
        }

        public static List<Puzzles> puzzles = new List<Puzzles>
        {

        };

        public string id;
        public Type type;
        public string defaultWorkspace;
        public string documentation;
        public string instructions;
        public string expectedOutput;
        public List<string> functionsExpected;
    }
}
