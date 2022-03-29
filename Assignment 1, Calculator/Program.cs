using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Calculator
{ 
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            bool runCaluculator = true;
            while (runCaluculator)
            {
                runCaluculator = ShowCalculatorDisplay();
            }
        }
        private static bool ShowCalculatorDisplay() 
        {
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                 Gör en räkneoperation med två tal");
            Console.WriteLine("            Du kan använda ett av de fyra räknesätten + - * /");
            Console.WriteLine("                        Använd mellanslag mellan siffrorna och operatorn och tyck Enter");
            Console.Write("                Exempelvis:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("        2022 - 1973");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                            1 + 1");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("           25 * -4");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("                                10 / 0,02            ");
            Console.ResetColor();
            Console.WriteLine("Skriv A och tryck Enter för att Avsluta");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("                 ");
            Console.ForegroundColor = GetRandomConsoleColor();
            string input = Console.ReadLine();                        //Visual Studio gives me a squiggly line with a comment here, that I don't understand.
            if (input != "a" && input != "A")
            {
                Console.Clear();
                Console.WriteLine("");
                string[] inputElement = input.Split(' ');
                var totalElements = inputElement.Length;
                if (totalElements == 3)
                {
                    if (double.TryParse(inputElement[0], out double valueA) && double.TryParse(inputElement[2], out double valueB))
                    {
                        string operation = inputElement[1];
                        switch (operation)
                        {
                            case "+":
                                Addition(valueA, operation, valueB);
                                return true;
                            case "-":
                                Subtraction(valueA, operation, valueB);
                                return true;
                            case "*":
                                Multiplication(valueA, operation, valueB);
                                return true;
                            case "/":
                                Division(valueA, operation, valueB);
                                return true;
                            default:
                                Console.WriteLine(" " + inputElement[0] + " " + inputElement[1] + " " + inputElement[2] + " = Ej korrekt räknesätt");
                                return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine(" " + inputElement[0] + " " + inputElement[1] + " " + inputElement[2] + " = Ej korrekta tal (använd , vid decimaltal)");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("");
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        private static void Addition(double valueA, string operation, double valueB)
        {
            Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (valueA + valueB));
        }
        private static void Subtraction(double valueA, string operation, double valueB)
        {
            Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (valueA - valueB));
        }
        private static void Multiplication(double valueA, string operation, double valueB)
        {
            Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (valueA * valueB));
        }
        private static void Division(double valueA, string operation, double valueB)
        {
            if (valueB != 0)
            {
                Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (valueA / valueB));
            }
            else
            {
                Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = Det går inte att dividera med 0");
            }
        }

        private static readonly Random randomColor = new();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(randomColor.Next(consoleColors.Length));    //Visual Studio gives me a squiggly line with a comment here, that I don't understand.
        }
    } 
}
