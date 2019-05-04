namespace TrafficLights
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var trafficLight = new TrafficLight[input.Length];

            for (int i = 0; i < trafficLight.Length; i++)
            {
                trafficLight[i] = (TrafficLight)Activator.CreateInstance(typeof(TrafficLight), new object[] { input[i] });
            }

            var numberOfChange = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfChange; i++)
            {
                var result = new List<string>();

                foreach (var traffic in trafficLight)
                {
                    traffic.Change();
                    var field = typeof(TrafficLight).GetField("currentSignal", BindingFlags.Instance | BindingFlags.NonPublic);

                    result.Add(field.GetValue(traffic).ToString());
                }

                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}
