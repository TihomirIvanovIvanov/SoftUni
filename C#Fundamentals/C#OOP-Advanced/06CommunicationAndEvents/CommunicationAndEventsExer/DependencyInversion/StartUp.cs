using P03_DependencyInversion;
using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

        string[] input = Console.ReadLine().Split();
        while (input[0] != "End")
        {
            if (input[0].Equals("mode"))
            {
                calculator.ChangeStrategy(char.Parse(input[1]));
            }
            else
            {
                var firstNum = int.Parse(input[0]);
                var secondNum = int.Parse(input[1]);

                Console.WriteLine(calculator.PerformCalculation(firstNum, secondNum));
            }

            input = Console.ReadLine().Split();
        }
    }
}