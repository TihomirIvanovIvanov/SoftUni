using System;

class RoyalGuard : Soldier
{
    private const int DefaultHits = 3;

    public RoyalGuard(string name, King kingToDefend) 
        : base(name, DefaultHits, kingToDefend)
    {
    }

    public override void OnKingBeingAttacked(object sender, EventArgs e)
    {
        Console.WriteLine($"Royal Guard { this.Name } is defending!");
    }
}