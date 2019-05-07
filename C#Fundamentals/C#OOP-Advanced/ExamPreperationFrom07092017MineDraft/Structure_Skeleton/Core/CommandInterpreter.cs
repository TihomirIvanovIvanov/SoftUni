using System;
using System.Collections.Generic;
using System.Linq;

public class CommandInterpreter : ICommandInterpreter
{
    private const string HarvestController = "harvesterController";
    private const string ProvideController = "providerController";
    private const string CommandSuffix = "Command";

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        var commndName = args[0];

        var commandType = Type.GetType(commndName + CommandSuffix);

        var paramInfo = commandType
            .GetConstructors()
            .First()
            .GetParameters();

        var ctorParams = new object[paramInfo.Length];

        for (int i = 0; i < ctorParams.Length; i++)
        {
            if (paramInfo[i].Name == HarvestController)
            {
                ctorParams[i] = this.HarvesterController;
            }
            else
            {
                if (paramInfo[i].Name == ProvideController)
                {
                    ctorParams[i] = this.ProviderController;
                }
                else
                {
                    ctorParams[i] = args.Skip(1).ToList();
                }
            }
        }

        var result = string.Empty;

        var command = (ICommand)Activator.CreateInstance(commandType, ctorParams);
        result = command.Execute();
        return result;
    }
}