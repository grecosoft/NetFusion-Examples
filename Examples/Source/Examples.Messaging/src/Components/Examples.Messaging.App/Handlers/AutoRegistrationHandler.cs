using System;
using System.Linq;
using System.Threading.Tasks;
using Examples.Messaging.App.Adapters;
using Examples.Messaging.Domain.Commands;
using Examples.Messaging.Domain.Entities;

namespace Examples.Messaging.App.Handlers;

public class AutoRegistrationHandler
{
    private readonly IRegistrationDataAdapter _adapter;

    public AutoRegistrationHandler(IRegistrationDataAdapter adapter)
    {
        _adapter = adapter;
    }
    
    public async Task<RegistrationStatus> RegisterAuto(RegisterAutoCommand command)
    {
        AutoInfo[] validModels = await _adapter.GetValidModelsAsync(command.Year);
        return new RegistrationStatus(
            Guid.NewGuid().ToString(),
            IsValidMakeAndModel(command, validModels),
            DateTime.UtcNow);
    }
    
    private static bool IsValidMakeAndModel(RegisterAutoCommand command,
        AutoInfo[] validModels)
    {
        return validModels.Any(
            m => m.Make == command.Make &&
                 m.Model == command.Model);
    }
}