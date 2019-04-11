namespace MordorsCruelPlan.Factories
{
    using MoodModels;

    public class MoodFactory
    {
        public Mood CreateMood(string type)
        {
            type = type.ToLower();

            switch (type)
            {
                case "sad":
                    return new Sad();
                case "angry":
                    return new Angry();
                case "happy":
                    return new Happy();
                case "javascript":
                    return new JavaScript();
                default:
                    throw new System.Exception("Invalid type!");
            }
        }
    }
}