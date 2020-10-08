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
                instructions="Si entrada es verdadero, entonces imprime “Todo bien”. ",
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
                type=Type.Cycles,
                instructions="Imprime los números del 1 al 10. Revisar que tenga un ciclo.",
                expectedOutput="1 2 3 4 5 6 7 8 9 10"
            },
            new Puzzles
            {
                id="loop_a2",
                type=Type.Cycles,
                instructions="Imprime 10 veces “Hola”. Revisar que hola este escrito en 10 líneas.",
                expectedOutput="Hola Hola Hola Hola Hola Hola Hola Hola Hola Hola"
            },
            new Puzzles
            {
                id="loop_b1",
                type=Type.Cycles,
                instructions="Realiza un programa que imprima todos los dígitos pares del 1 al 10.",
                expectedOutput="2 4 6 8 10"
            },
            new Puzzles
            {
                id="loop_b2",
                type=Type.Cycles,
                instructions="Realiza un programa que imprima la tabla de 4. Del 4 al 10.",
                expectedOutput="4 8 12 16 20 24 28 32 36 40"
            },
            new Puzzles
            {
                id="loop_c1",
                type=Type.Cycles,
                instructions="Escribe en pantalla los números primos del 1 al 20. Recuerda que si un número se puede dividir entre sí mismo y entre 1 y ninguno otro más entonces es primo, el uno no se considera número primo.",
                expectedOutput="2 3 5 7 11 13 17 19"
            },
            new Puzzles
            {
                id="loop_c2",
                type=Type.Cycles,
                instructions="Obtén el factorial de 4. E imprimelo en pantalla. Nota: Factorial es el producto de todos los números enteros positivos desde el uno hasta n, por ejemplo: 2! seria 1 x 2 = 2",
                expectedOutput="24"
            },
            new Puzzles
            {
                id="func_a1",
                instructions="Haz una función llamada suma que acepte dos números y retorna su suma.Revisar que exista función y revisar que la podamos usar.",
                type= Type.Functions,
                functionsExpected = new List<string>{"suma"},
                functionTests = new List<FunctionTest>
                {
                    new FunctionTest
                    {
                        functionName="suma",
                        functionParameters= new List<object> { 2, 2 },
                        outputResult="4"
                    }
                }
            },
            new Puzzles
            {
                id="func_a2",
                instructions="Haz una función que se llame max, y retorna el número más grande. Revisar que exista  función y que funcione así.",
                type= Type.Functions,
                functionsExpected = new List<string>{"max"},
                functionTests = new List<FunctionTest>
                {
                    new FunctionTest
                    {
                        functionName="max",
                        functionParameters= new List<object> { 2, 4 },
                        outputResult="4"
                    }
                }
            },
            new Puzzles
            {
                id="func_b1",
                instructions="Realiza una función se llame bienvenida que acepte una cadena de texto y retorne “Hola, [entrada]”. ",
                type= Type.Functions,
                functionsExpected = new List<string>{"bienvenida"},
                functionTests = new List<FunctionTest>
                {
                    new FunctionTest
                    {
                        functionName="bienvenida",
                        functionParameters= new List<object> { "mundo" },
                        outputResult="Hola mundo"
                    }
                }
            },
            new Puzzles
            {
                id="func_b1",
                instructions="Realiza una función se llame bienvenida que acepte una cadena de texto y retorne “Hola, [entrada]”. ",
                type= Type.Functions,
                functionsExpected = new List<string>{"bienvenida"},
                functionTests = new List<FunctionTest>
                {
                    new FunctionTest
                    {
                        functionName="bienvenida",
                        functionParameters= new List<object> { "mundo" },
                        outputResult="Hola mundo"
                    }
                }
            },
            new Puzzles
            {
                id="func_b2",
                instructions="Realizar una función que se llame recortar, que acepte tres valores número, mínimo y máximo. El primero es el número a recortar." +
                    "<ul>" +
                    "<li>Si es mayor a máximo, retorna máximo</li>" +
                    "<li>Si es menor a mínimo, retorna mínimo</li>" +
                    "<li>Si esta entre menor y máximo, retorna el valor</li>" +
                    "<ul>",
                type= Type.Functions,
                functionsExpected = new List<string>{"recortar"},
                functionTests = new List<FunctionTest>
                {
                    new FunctionTest
                    {
                        functionName="recortar",
                        functionParameters= new List<object> { 6, 1, 4 },
                        outputResult="4"
                    },
                    new FunctionTest
                    {
                        functionName="recortar",
                        functionParameters= new List<object> { -1, 1, 4 },
                        outputResult="1"
                    },
                    new FunctionTest
                    {
                        functionName="recortar",
                        functionParameters= new List<object> { 2, 1, 4 },
                        outputResult="2"
                    }
                }
            },
            new Puzzles
            {
                id="func_c1",
                instructions="Haz una función llamada esPrimo que retorne verdadero si es un numero primo y falso si no. Recuerda que si un número se puede dividir entre sí mismo y entre 1 y ninguno otro más entonces es primo, el uno no se considera número primo.",
                type= Type.Functions,
                functionsExpected = new List<string>{"esPrimo"},
                functionTests = new List<FunctionTest>
                {
                    new FunctionTest
                    {
                        functionName="esPrimo",
                        functionParameters= new List<object> { 6 },
                        outputResult="false"
                    },
                    new FunctionTest
                    {
                        functionName="esPrimo",
                        functionParameters= new List<object> { 7 },
                        outputResult="true"
                    }
                }
            },
            new Puzzles
            {
                id="func_c2",
                instructions="•	Haz una función que se llame areaRectangulo y acepte el largo y ancho y retorne el área. ",
                type= Type.Functions,
                functionsExpected = new List<string>{"areaCirculo"},
                functionTests = new List<FunctionTest>
                {
                    new FunctionTest
                    {
                        functionName="areaCirculo",
                        functionParameters= new List<object> { 2, 2 },
                        outputResult="4"
                    }
                }
            },
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
        public List<FunctionTest> functionTests;


        public class FunctionTest
        {
            public string functionName;
            public List<object> functionParameters;
            public string outputResult;
        }
    }
}
