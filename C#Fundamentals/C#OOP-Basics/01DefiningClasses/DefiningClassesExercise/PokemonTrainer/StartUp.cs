namespace PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string input;
            var trainers = new List<Trainer>();

            while ((input = Console.ReadLine().Trim()) != "Tournament")
            {
                var trainerInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var trainerName = trainerInfo[0];
                var pokemonName = trainerInfo[1];
                var pokemonElement = trainerInfo[2];
                var pokemonHealth = int.Parse(trainerInfo[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                var isConstainsTrainer = false;

                foreach (var trainer in trainers)
                {
                    if (trainer.Name == trainerName)
                    {
                        isConstainsTrainer = true;
                        break;
                    }
                }

                if (isConstainsTrainer)
                {
                    var currentTrainer = trainers.First(t => t.Name == trainerName);
                    currentTrainer.Pokemons.Add(pokemon);
                }
                else
                {
                    var trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
            }

            string elements;
            while ((elements = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    var currentTrainer = trainers.First(t => t.Name == trainer.Name);

                    var countOfThisElements = currentTrainer
                        .Pokemons
                        .Count(p => p.Element == elements);

                    if (countOfThisElements >= 1)
                    {
                        currentTrainer.NumberOfBadges++;
                    }
                    else
                    {
                        currentTrainer
                            .Pokemons
                            .Select(p => p.Health -= 10)
                            .ToList();

                        currentTrainer
                            .Pokemons
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