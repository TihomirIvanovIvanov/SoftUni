using System;

public class Footman : Soldier
{
    private const int DefaultHits = 2;

    public Footman(string name, King kingToDefend) 
        : base(name, DefaultHits, kingToDefend)
    {
    }

    public override void OnKingBeingAttacked(object sender, EventArgs e)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}