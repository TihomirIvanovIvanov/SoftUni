using System;

[SoftUni("Ventsi")]
class StartUp
{
    [SoftUni("Gosho")]
    public static void Main()
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}