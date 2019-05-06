using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        IList<Soldier> soldiers = new List<Soldier>();
        King king = new King(Console.ReadLine());

        var royalGuardsNames = Console.ReadLine().Split();

        foreach (var royalGuardName in royalGuardsNames)
        {
            var currentRoyalGuard = new RoyalGuard(royalGuardName);
            soldiers.Add(currentRoyalGuard);

            king.BeingAttacked += currentRoyalGuard.OnKingBeingAttacked;
        }

        var footmanNames = Console.ReadLine().Split();

        foreach (var footmanGuardName in footmanNames)
        {
            var currentFootmanGuard = new Footman(footmanGuardName);
            soldiers.Add(currentFootmanGuard);

            king.BeingAttacked += currentFootmanGuard.OnKingBeingAttacked;
        }

        string[] command = Console.ReadLine().Split();
        while (!command[0].Equals("End"))
        {
            switch (command[0])
            {
                case "Kill":
                    Soldier deadSoldier = soldiers.FirstOrDefault(s => s.Name.Equals(command[1]));
                    king.BeingAttacked -= deadSoldier.OnKingBeingAttacked;
                    soldiers.Remove(deadSoldier);
                    break;
                case "Attack":
                    king.TakeAttack();
                    break;
            }

            command = Console.ReadLine().Split();
        }
    }
}