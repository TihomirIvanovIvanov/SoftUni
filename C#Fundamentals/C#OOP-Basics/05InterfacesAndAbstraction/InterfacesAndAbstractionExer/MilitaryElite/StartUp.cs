namespace MilitaryElite
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<Soldier> soldiers = new List<Soldier>();

        public static void Main()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var personInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var type = personInfo[0];
                var firstName = personInfo[1];
                var lastName = personInfo[2];
                var id = personInfo[3];
                var salary = decimal.Parse(personInfo[4]);

                switch (type)
                {
                    case nameof(Private):
                        AddPrivate(personInfo);
                        break;
                    case nameof(LieutenantGeneral):
                        AddLieutenantGeneral(personInfo);
                        break;
                    case nameof(Engineer):
                        AddEngineer(personInfo);
                        break;
                    case nameof(Commando):
                        AddCommando(personInfo);
                        break;
                    case nameof(Spy):
                        AddSpy(personInfo);
                        break;
                }
            }

            soldiers.ForEach(Console.WriteLine);
        }

        private static void AddSpy(string[] personInfo)
        {
            var spy = new Spy(personInfo[1], personInfo[2], personInfo[3], int.Parse(personInfo[4]));

            soldiers.Add(spy);
        }

        private static void AddCommando(string[] personInfo)
        {
            try
            {
                var commando = new Commando(personInfo[1], personInfo[2], personInfo[3], decimal.Parse(personInfo[4]), personInfo[5]);

                for (int i = 6; i < personInfo.Length; i += 2)
                {
                    try
                    {
                        var mission = new Mission(personInfo[i], personInfo[i + 1]);
                        commando.AddMission(mission);
                    }
                    catch { }
                }

                soldiers.Add(commando);
            }
            catch { }
        }

        private static void AddEngineer(string[] personInfo)
        {
            try
            {
                var engineer = new Engineer(personInfo[1], personInfo[2], personInfo[3], decimal.Parse(personInfo[4]), personInfo[5]);

                for (int i = 6; i < personInfo.Length; i += 2)
                {
                    var repair = new Repair(personInfo[i], int.Parse(personInfo[i + 1]));
                    engineer.AddRepear(repair);
                }

                soldiers.Add(engineer);
            }
            catch { }
        }

        private static void AddLieutenantGeneral(string[] personInfo)
        {
            var general = new LieutenantGeneral(personInfo[1], personInfo[2], personInfo[3], decimal.Parse(personInfo[4]));

            for (int i = 5; i < personInfo.Length; i++)
            {
                var @private = (Private)soldiers.Single(s => s.Id == personInfo[i]);
                general.AddPrivate(@private);
            }

            soldiers.Add(general);
        }

        private static void AddPrivate(string[] personInfo)
        {
            var @private = new Private(personInfo[1], personInfo[2], personInfo[3], decimal.Parse(personInfo[4]));

            soldiers.Add(@private);
        }
    }
}