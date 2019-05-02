namespace Solid.Loger.Layouts.Factories.Contracts
{
    using Layouts.Contracts;

    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
