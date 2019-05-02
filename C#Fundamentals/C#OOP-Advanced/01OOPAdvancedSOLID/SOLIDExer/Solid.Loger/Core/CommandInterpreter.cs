namespace Solid.Loger.Core
{
    using Appenders.Contracts;
    using Appenders.Factories;
    using Appenders.Factories.Contracts;
    using Contracts;
    using Layouts.Factories;
    using Layouts.Factories.Contracts;
    using Loggers.Enums;
    using Solid.Loger.Layouts.Contracts;
    using System;
    using System.Collections.Generic;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            var appenderType = args[0];
            var layoutType = args[1];
            var reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }

            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout);
            appender.ReportLevel = reportLevel;

            this.appenders.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            var reportLevel = Enum.Parse<ReportLevel>(args[0]);
            var dateTime = args[1];
            var message = args[2];

            foreach (var appender in this.appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in this.appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
