namespace StorageBox
{
    public class StartUp
    {
        public static void Main()
        {
            var box = new Box<int>();
            for (int i = 0; i <= 10; i++)
            {
                box.Add(i);
            }
            System.Console.WriteLine(box);
        }
    }
}
