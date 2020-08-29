using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main()
        {
            var trainers = new List<Trainer>();
            string input;
            while ((input = Console.ReadLine().Trim()) != "Tournament")
            {
                var trainerInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var name = trainerInfo[0];
                var pokemon = trainerInfo[1];
                var element = trainerInfo[2];
                var health = int.Parse(trainerInfo[3]);

                var pokemons = new Pokemon(pokemon, element, health);
                var isContainsTrainer = false;

                foreach (var trainer in trainers)
                {
                    if (trainer.Name == name)
                    {
                        isContainsTrainer = true;
                        break;
                    }
                }

                if (isContainsTrainer)
                {
                    var currentTrainer = trainers.First(t => t.Name == name);
                    currentTrainer.Pokemons.Add(pokemons);
                }
                else
                {
                    var trainer = new Trainer(name);
                    trainer.Pokemons.Add(pokemons);
                    trainers.Add(trainer);
                }
            }

            string elements;
            while ((elements = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    var currentTrainer = trainers.First(t => t.Name == trainer.Name);

                    var countOfThisElements = currentTrainer.Pokemons
                        .Count(p => p.Element == elements);

                    if (countOfThisElements >= 1)
                    {
                        currentTrainer.NumberOfBadges++;
                    }
                    else
                    {
                        currentTrainer.Pokemons
                            .Select(p => p.Health -= 10)
                            .ToList();

                        currentTrainer.Pokemons
                            .RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            trainers
               .OrderByDescending(t => t.NumberOfBadges)
               .ToList()
               .ForEach(t => Console.WriteLine($"{t.Name} {t.NumberOfBadges} {t.Pokemons.Count}"));
        }
    }
}
