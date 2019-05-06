using System;

public abstract class Soldier : INameable
{
    private readonly King kingDefended;

    private int hitsTaken;

    public Soldier(string name, int hitsTaken, King kingToDefend)
    {
        this.Name = name;
        this.hitsTaken = hitsTaken;
        this.kingDefended = kingToDefend;
    }

    public event EventHandler<KillEventArgs> SoldierKilled;

    public string Name { get; }

    public abstract void OnKingBeingAttacked(object sender, EventArgs e);

    public void TakeAttack()
    {
        this.hitsTaken--;

        if (this.hitsTaken <= 0)
        {
            this.OnSoldierKilled();
        }
    }

    private void OnSoldierKilled()
    {
        this.SoldierKilled?.Invoke(this, new KillEventArgs(this, this.kingDefended));
    }
}