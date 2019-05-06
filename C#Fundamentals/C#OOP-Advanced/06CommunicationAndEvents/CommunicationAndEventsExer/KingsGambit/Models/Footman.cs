using System;

public class Footman : Soldier
{
    public Footman(string name) 
        : base(name)
    {
    }

    public override void OnKingBeingAttacked(object sender, EventArgs e)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}