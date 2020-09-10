namespace FoodShortage.Contracts
{
    public interface IBuyerble
    {
        string Name { get; }

        int Food { get; }

        void BuyFood();
    }
}
