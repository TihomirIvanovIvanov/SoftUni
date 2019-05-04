using InfernoInfinity.Core;
using System;

public class StartUp
{
    public static void Main()
    {
        try
        {
            Engine engine = new Engine();
            engine.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}