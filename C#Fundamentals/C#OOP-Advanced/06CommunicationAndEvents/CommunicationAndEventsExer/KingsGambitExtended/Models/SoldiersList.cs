using System.Collections.Generic;

public class SoldiersList : List<Soldier>
{
    public void OnSoldierKilled(object sender, KillEventArgs args)
    {
        args.Soldier.SoldierKilled -= this.OnSoldierKilled;
        args.KingDefended.BeingAttacked -= args.Soldier.OnKingBeingAttacked;
        this.Remove(args.Soldier);
    }
}