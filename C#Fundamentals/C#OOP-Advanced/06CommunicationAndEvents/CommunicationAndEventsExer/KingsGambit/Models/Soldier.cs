using System;

public abstract class Soldier : INameable
{
    public Soldier(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public abstract void OnKingBeingAttacked(object sender, EventArgs e);
}