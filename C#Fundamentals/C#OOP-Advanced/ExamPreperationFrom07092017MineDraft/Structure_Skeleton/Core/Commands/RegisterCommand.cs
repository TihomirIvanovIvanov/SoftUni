using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public RegisterCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController)
        : base(arguments)
    {
        this.providerController = providerController;
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        var type = this.Arguments[0];
        var commandArgs = this.Arguments.Skip(1).ToList();

        var result = string.Empty;
        switch (type)
        {
            case nameof(Harvester):
                result = this.harvesterController.Register(commandArgs);
                break;
            case nameof(Provider):
                result = this.providerController.Register(commandArgs);
                break;
        }

        return result;
    }
}