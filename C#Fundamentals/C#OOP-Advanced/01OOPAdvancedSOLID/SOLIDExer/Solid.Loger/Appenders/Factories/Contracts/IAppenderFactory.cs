namespace Solid.Loger.Appenders.Factories.Contracts
{
    using Appenders.Contracts;
    using Layouts.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}