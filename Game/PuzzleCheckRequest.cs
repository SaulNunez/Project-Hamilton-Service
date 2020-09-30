using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game
{
    public class PuzzleCheckRequest
    {
        public PuzzleCheckRequest(string code, string expectedOutput, Puzzles.Type type,
            List<PuzzleFunctionCheck> puzzleFunctionChecks,
            List<string> functionsExpected
            )
        {
            this.code = code;
            this.expectedOutput = expectedOutput;
            switch (type)
            {
                case Puzzles.Type.Conditionals:
                    checkType = "check_for_branching";
                    break;
                case Puzzles.Type.Cycles:
                    checkType = "check_for_loops";
                    break;
                case Puzzles.Type.Functions:
                    checkType = "check_for_functions";
                    break;
            }

            checkFunctionExists = puzzleFunctionChecks;
            this.functionChecks = functionsExpected;
        }

        public string code;
        public string expectedOutput;
        public string checkType;
        public List<PuzzleFunctionCheck> checkFunctionExists;
        public List<string> functionChecks;
    }

    public class PuzzleFunctionCheck
    {
        public string name;
        public List<object> parameters;
        public string output;
    }
}
