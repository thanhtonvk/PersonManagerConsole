using System;

namespace Project1.Utilites
{
    public class Validation
    {
        public static string InputString()
        {
            string input = Console.ReadLine();
            while (true)
            {
                if (input != "") break;
                Console.Write("String is empty: ");
                input = Console.ReadLine();
            }

            return input;
        }

        public static int InputNumber()
        {
            String input = Console.ReadLine();
            int number;
            while (true)
            {
                bool isNumerical = int.TryParse(input, out number);
                if (isNumerical && number >= 0) break;
                Console.Write("Input is not numberic or <0: ");
                input = Console.ReadLine();
            }

            return number;
        }
    }
}