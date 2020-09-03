namespace MordorsCruelPlan.Factories
{
    using FoodModels;

    public class FoodFactory
    {
        public Food CreateFood(string type)
        {
            type = type.ToLower();

            return type switch
            {
                "cram" => new Cram(),
                "lembas" => new Lembas(),
                "apple" => new Apple(),
                "melon" => new Melon(),
                "honeycake" => new HoneyCake(),
                "mushrooms" => new Mushrooms(),
                _ => new EverythingElse(),
            };
        }
    }
}