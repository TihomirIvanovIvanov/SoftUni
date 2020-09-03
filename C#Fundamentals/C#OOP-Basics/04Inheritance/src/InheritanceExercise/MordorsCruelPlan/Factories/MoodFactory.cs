namespace MordorsCruelPlan.Factories
{
    using MoodModels;

    public class MoodFactory
    {
        public Mood CreateMood(string type)
        {
            type = type.ToLower();

            return type switch
            {
                "sad" => new Sad(),
                "angry" => new Angry(),
                "happy" => new Happy(),
                "javascript" => new JavaScript(),
                _ => throw new System.Exception("Invalid type!"),
            };
        }
    }
}