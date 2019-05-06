using System;

class RoyalGuard : Soldier
{
    public RoyalGuard(string name) 
        : base(name)
    {
    }

    public override void OnKingBeingAttacked(object sender, EventArgs e)
    {
        Console.WriteLine($"Royal Guard { this.Name } is defending!");
    }
}