using System;

public class King : INameable
{
    public King(string name)
    {
        this.Name = name;
    }

    public event EventHandler BeingAttacked;

    public string Name { get; set; }

    public void TakeAttack()
    {
        this.OnBeingAttacked();
    }

    private void OnBeingAttacked()
    {
        Console.WriteLine($"King {this.Name} is under attack!");

        this.BeingAttacked?.Invoke(this, EventArgs.Empty);
    }
}