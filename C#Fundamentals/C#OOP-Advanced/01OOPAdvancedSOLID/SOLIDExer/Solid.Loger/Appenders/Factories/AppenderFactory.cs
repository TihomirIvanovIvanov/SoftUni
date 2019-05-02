namespace Solid.Loger.Appenders.Factories
{
    using Appenders.Contracts;
    using Contracts;
    using Layouts.Contracts;
    using Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            type = type.ToLower();

            switch (type)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}