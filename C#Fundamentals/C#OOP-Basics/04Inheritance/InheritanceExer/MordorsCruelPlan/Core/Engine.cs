namespace MordorsCruelPlan.Core
{
    using Factories;
    using FoodModels;
    using MoodModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private FoodFactory foodFactory;
        private MoodFactory moodFactory;
        private List<Food> foods;

        public Engine()
        {
            this.foodFactory = new FoodFactory();
            this.moodFactory = new MoodFactory();
            this.foods = new List<Food>();
        }

        public void Run()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                var type = input[i];

                var food = foodFactory.CreateFood(type);
                foods.Add(food);
            }

            var points = foods.Sum(f => f.Happiness);
            Mood mood;

            if (points < -5)
            {
                mood = moodFactory.CreateMood("angry");
            }
            else if (points >= -5 && points < 0)
            {
                mood = moodFactory.CreateMood("sad");
            }
            else if (points >= 1 && points < 15)
            {
                mood = moodFactory.CreateMood("happy");
            }
            else
            {
                mood = moodFactory.CreateMood("javascript");
            }


            Console.WriteLine(points);
            Console.WriteLine(mood.GetType().Name);
        }
    }
}