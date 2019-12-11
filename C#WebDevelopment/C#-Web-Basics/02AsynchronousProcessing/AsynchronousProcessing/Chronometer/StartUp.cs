namespace Chronometer
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "exit")
            {
                switch (input)
                {
                    case "start": chronometer.Start(); break;

                    case "stop": chronometer.Stop(); break;

                    case "lap": Console.WriteLine(chronometer.Lap()); break;

                    case "time": Console.WriteLine(chronometer.GetTime); break;

                    case "reset": chronometer.Reset(); break;

                    case "laps":
                        Console.WriteLine("Laps: " + (chronometer.Laps.Count == 0 
                            ? "no laps."
                            : "\r\n" + string.Join("\r\n", chronometer.Laps.Select((lap, index) => $"{index}. {lap}"))));
                        break;
                }
            }
        }
    }
}
