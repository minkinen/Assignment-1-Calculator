using System.Text;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            bool runCalculator = true;
            while (runCalculator)
            {
                runCalculator = ShowCalculatorDisplay();
            }
        }
        private static bool ShowCalculatorDisplay()
        {
            Text.MenuText();
            string input = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("");
            double[] numberSet = { 1000, 99.99, -4.56, 0.03, 100 };
            switch (input)
            {
                case "a":
                case "A":
                    return false;
                case "++":
                    Addition setAddition = new Addition();
                    double setSum = setAddition.Calculation(numberSet);
                    string numberSetAddition = Text.NumberSet("+", numberSet);
                    Console.WriteLine(numberSetAddition + setSum);
                    return true;
                case "--":
                    Subtraction setSubtraction = new Subtraction();
                    double setDifference = setSubtraction.Calculation(numberSet);
                    string numberSetSubtraction = Text.NumberSet("-", numberSet);
                    Console.WriteLine(numberSetSubtraction + setDifference);
                    return true;
                default:

                    if (input != "a" && input != "A")
                    {

                        string[] inputElements = input.Split(' ');
                        if (inputElements.Length == 3)
                        {
                            if (double.TryParse(inputElements[0], out double valueA) && double.TryParse(inputElements[2], out double valueB))
                            {
                                string operation = inputElements[1];
                                switch (operation)
                                {
                                    case "+":
                                        Addition addition = new Addition();
                                        double sum = addition.Calculation(valueA, valueB);
                                        Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (sum));
                                        return true;
                                    case "-":
                                        Subtraction subtraction = new Subtraction();
                                        double difference = subtraction.Calculation(valueA, valueB);
                                        Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (difference));
                                        return true;
                                    case "*":
                                        Multiplication multiplication = new Multiplication();
                                        double product = multiplication.Calculation(valueA, valueB);
                                        Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (product));
                                        return true;
                                    case "/":
                                        Divisor divisor = new Divisor();
                                        if (divisor.IsZero(valueB))
                                        {
                                            Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = Det går inte att dividera med 0");
                                        }
                                        else
                                        {
                                            Division division = new Division();
                                            double quotient = division.Calculation(valueA, valueB);
                                            Console.WriteLine(" " + valueA + " " + operation + " " + valueB + " = " + (quotient));
                                        }
                                        return true;
                                    default:
                                        Console.WriteLine(" " + inputElements[0] + " " + inputElements[1] + " " + inputElements[2] + " = Ej korrekt räknesätt");
                                        return true;
                                }
                            }
                            else
                            {
                                Console.WriteLine(" " + inputElements[0] + " " + inputElements[1] + " " + inputElements[2] + " = Ej korrekta tal (använd , vid decimaltal)");
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
        }
    }

    public class Addition
    {
        public double Calculation(double valueA, double valueB)
        {
            double result = valueA + valueB;
            return result;
        }

        // Overloaded method for Addition that accepts a array as inputparameter.
        public double Calculation(double[] numberSet)
        {
            double sum = 0;
            foreach (double number in numberSet)
            {
                sum += number;
            }
            return sum;
        }

        // Just for testing a function for field variables in xUnit.
        private double _testAddition;
        public double valueX { get; set; }
        public double valueY { get; set; }
        public double testAddition
        {
            get
            {
                _testAddition = valueX + valueY;
                return _testAddition;
            }
            set { _testAddition = value; }
        }
    }

    public class Subtraction
    {
        public double difference { get; set; }
        public double Calculation(double valueA, double valueB)
        {
            double result = valueA - valueB;
            return result;
        }

        // Overloaded method for Subtract that accepts a array as inputparameter.
        public double Calculation(double[] numberSet)
        {
            difference = 0;
            foreach (double number in numberSet)
            {
                difference -= number;
            }
            return difference;
        }
    }

    public class Multiplication
    {
        public double secretTestValue = 100;
        public double Calculation(double valueA, double valueB)
        {
            double result = valueA * valueB;
            return result;
        }
    }

    public class Division
    {
        public double Calculation(double valueA, double valueB)
        {
            double result = valueA / valueB;
            return result;
        }
    }
    public class Divisor
    {
        public bool IsZero(double valueB)
        {
            if (valueB == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }


    class Text
    {
        public static void MenuText()
        {
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                           Gör en räkneoperation med två tal");
            Console.WriteLine("      Du kan använda ett av de fyra räknesätten + - * /");
            Console.WriteLine("                  Använd mellanslag mellan siffrorna och operatorn och tyck Enter");
            Console.Write("          Exempelvis:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("        2022 - 1973");
            Console.ResetColor();
            Console.WriteLine("        Skriv ++ och Enter för ett exempel på en längre addition.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                      1 + 1");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("           25 * -4");
            Console.ResetColor();
            Console.WriteLine("        Skriv -- och Enter för ett exempel på en längre subtraktion.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("                          10 / 0,02            ");
            Console.ResetColor();
            Console.WriteLine("Skriv A och tryck Enter för att Avsluta");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("                 ");
            Console.ForegroundColor = Colors.GetRandomConsoleColor();
        }
        public static string NumberSet(string operation, double[] numberSet)
        {
            StringBuilder expression = new StringBuilder("");
            if (operation == "-")
            {
                expression.Append("0 - ");
            }
            for (int i = 0; i < numberSet.Length; i++)
            {
                string number = numberSet[i].ToString();
                expression.Append(number);
                if (i < numberSet.Length - 1)
                {
                    expression.Append(" " + operation + " ");
                }
                else
                {
                    expression.Append(" = ");
                }
            }
            return expression.ToString();
        }
    }
    class Colors
    {
        public static ConsoleColor GetRandomConsoleColor()
        {
            Random randomColor = new Random();
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(randomColor.Next(consoleColors.Length));    //Visual Studio gives me a squiggly green line with a comment here, that I don't understand.
        }

    }
}



// Your assignment for this week is to test the previously createdcalculator. 
// You shall also overload your addition(+) and subtract(-) method with versions that takesa array as inputparameter. 
// Approval demands:
// (X) xUnit test the divisionmethod for dividing with Zero(No exception crash allowed)
// (X) Each mathematical operation should be testable by xUnit.
// (X) Application need to have a Overloaded method for Addition & Subtract that accepts a array as inputparameter.
// Optional:
// •Handle Exceptions that may happen. In particular when user enters input.
// •Application need to be able to perform mathematical operations addition, subtraction, with multiple values.
