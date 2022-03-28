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
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu() 
        {
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                 Gör en räkneoperation med två tal");
            Console.WriteLine("            Du kan använda ett av de fyra räknesätten + - * /");
            Console.WriteLine("                        Använd mellanslag när du skriver ut det du vill beräkna");
            Console.Write("                Exempelvis:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("        2022 - 1973");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                            1 + 1");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("           25 * -4");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("                                10 / 0,02           ");
            Console.ResetColor();
            Console.WriteLine("Skriv A för att Avsluta");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("                 ");
            Console.ForegroundColor = GetRandomConsoleColor();
            string str = Console.ReadLine();                        //Visual Studio gives me a squiggly line with a comment here, that I don't understand.
            if (str != "a" && str != "A")
            {
                Console.Clear();
                string[] inputElement = str.Split(' ');
                var totalElements = inputElement.Count();
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
                                return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine(" " + inputElement[0] + " " + inputElement[1] + " " + inputElement[2] + " = Ej korrekta tal (använd , vid decimaltal)");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("");
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
            Console.WriteLine("");
            Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (valueA + valueB));
        }
        private static void Subtraction(double valueA, string operation, double valueB)
        {
            Console.WriteLine("");
            Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (valueA - valueB));
        }
        private static void Multiplication(double valueA, string operation, double valueB)
        {
            Console.WriteLine("");
            Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (valueA * valueB));
        }
        private static void Division(double valueA, string operation, double valueB)
        {
            if (valueB != 0)
            {
                Console.WriteLine("");
                Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (valueA / valueB));
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = Det går inte att dividera med 0");
            }
        }

        private static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }
    } 
}
