using System;
using System.Collections.Generic;
using System.IO;
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
            new Puzzles {
                id = "vars_a1",
                type = Type.Variables,
                instructions= "Imprime la variable miTexto.\n<b>Nota: Imprimir esta en la sección de texto.</b>",
                defaultWorkspaceFilename="vars_a1.xml",
                expectedOutput="Hola mundo"
            },
            new Puzzles
            {
                id= "vars_a2",
                type= Type.Variables,
                instructions= "Has que la variable suma sea igual a 4, e imprímela.",
                defaultWorkspaceFilename="vars_a2.xml",
                expectedOutput="4"
            },
            new Puzzles
            {
                id="vars_b1",
                type= Type.Variables,
                instructions= "Haz una variable llamada miVariable, haz que tome el valor de 7 e imprímela en pantalla.",
                expectedOutput="7",
                defaultWorkspaceFilename="vars_b1.xml"
            },
            new Puzzles
            {
                id="vars_b2",
                type=Type.Variables,
                instructions="Haz una variable llamada bienvenida y haz que imprima “Hola <i>mi_nombre</i>”",
                expectedOutput="Hola *",
                defaultWorkspaceFilename="vars_b2.xml"
            },
            new Puzzles
            {
                id="vars_c1",
                type=Type.Variables,
                instructions="Suma x con y. E imprime el resultado.",
                expectedOutput="7",
                defaultWorkspaceFilename="vars_c1.xml"
            },
            new Puzzles
            {
                id="vars_c2",
                type=Type.Variables,
                instructions="Obten el cuadrado de entrada e imprimelo. <b>Nota: Puedes obtener el cuadrado multiplicando el valor por si mismo</b>",
                expectedOutput="4"
            },
            new Puzzles
            {
                id="cond_a1",
                type=Type.Variables,
                instructions="Si entrada es verdadero, entonces imprime “Todo bien”. Ver qué haya un if. Entrada es igual a verdadero. Ver qué la salida es todo bien."
            },
            new Puzzles
            {
                id="cond_a2",
                type=Type.Variables,
                instructions="Si num es mayor o igual a 7, escribe aprobado. Num es 7, ver qué haya un if y que haya “aprobado” en pantalla."
            }
        };

        public string GetWorkspaceXmlFromFile()
        {
            if (instructions == null)
            {
                return "";
            }

            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "Game", "Assets", "puzzles_workspace", defaultWorkspaceFilename);

            string text = File.ReadAllText(filePath);

            return text;
        }

        public string id;
        public Type type;
        public string defaultWorkspaceFilename;
        public string documentation;
        public string instructions;
        public string expectedOutput;
        public List<string> functionsExpected;
    }
}
