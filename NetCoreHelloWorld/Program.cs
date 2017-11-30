using System;

namespace NetCoreHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MathOperation();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        private static void MathOperation()
        {
            // Read first number   
            Console.Write("Enter Number 1: ");
            var var1 = Console.ReadLine();
            // Convert string to int  
            int num1 = Convert.ToInt32(var1);

            // Read second number  
            Console.Write("Enter Number 2: ");
            var var2 = Console.ReadLine();
            // Convert string to int  
            int num2 = Convert.ToInt32(var2);

            // Read operation type - operator  
            Console.Write("Enter one Operator (Add/Sub/Mul/Div): ");
            var op = Console.ReadLine();

            switch (op)
            {
                case "Add":
                    Console.WriteLine("Add {0}:", num1 + num2);
                    break;
                case "Sub":
                    Console.WriteLine("Sub {0}:", num1 - num2);
                    break;
                case "Mul":
                    double result = num1 * num2;
                    Console.WriteLine("Div {0}:", result);
                    break;
                case "Div":
                    double res = (double)num1 / num2;
                    Console.WriteLine("Div {0}:", res);
                    break;
                default:
                    Console.WriteLine("Operation failed!");
                    break;
            }
        }
    }
}
