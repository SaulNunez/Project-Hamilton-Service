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
                type=Type.Conditionals,
                instructions="Si entrada es verdadero, entonces imprime “Todo bien”. Ver qué haya un if. Entrada es igual a verdadero. Ver qué la salida es todo bien.",
                defaultWorkspaceFilename="cond_a1.xml"
            },
            new Puzzles
            {
                id="cond_a2",
                type=Type.Conditionals,
                instructions="Si num es mayor o igual a 7, escribe aprobado. Num es 7, ver qué haya un if y que haya “aprobado” en pantalla.",
                defaultWorkspaceFilename="cond_a2.xml"
            },
            new Puzzles
            {
                id="cond_b1",
                type=Type.Conditionals,
                instructions="Si miVariable es mayor a cero has que imprima “Es positivo”, si no imprime “Es negativo”.",
                expectedOutput="Es positivo",
                defaultWorkspaceFilename="cond_b1.xml"
            },
            new Puzzles
            {
                id="cond_b2",
                type=Type.Conditionals,
                instructions="¡Si calificacion es mayor o igual a 7, escribe “Pasaste!”",
                expectedOutput="Pasaste!",
                defaultWorkspaceFilename="cond_b2.xml"
            },
            new Puzzles
            {
                id="cond_c1",
                type=Type.Conditionals,
                instructions="Si x es igual a y, entonces imprimir “Es igual”.",
                defaultWorkspaceFilename="cond_c1.xml",
                expectedOutput=""
            },
            new Puzzles
            {
                id="cond_c2",
                type=Type.Conditionals,
                instructions="Si es entrada es cero imprime “Esta entrada es cero”, si entrada es positiva imprime “Esta entrada es mayor a cero”, si entrada es negativa imprime “Esta entrada es menor a cero”.",
                defaultWorkspaceFilename="cond_c2.xml",
                expectedOutput="Esta entrada es menor a cero"
            },
            new Puzzles
            {
                id="loop_a1",
                type=Type.Cycles
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
