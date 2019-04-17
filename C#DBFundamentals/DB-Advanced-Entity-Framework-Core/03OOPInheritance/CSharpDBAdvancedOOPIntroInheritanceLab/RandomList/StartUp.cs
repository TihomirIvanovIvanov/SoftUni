public class StartUp
{
    public static void Main()
    {
        var rnd = new RandomList();
        for (int i = 0; i < 10; i++)
        {
            rnd.Add("value " + i);
        }
        System.Console.WriteLine(rnd.RandomString());
        foreach (var random in rnd)
        {
            System.Console.WriteLine(random);
        }
    }
}

