using System;
using System.Threading.Tasks;
using Demo.Domain.Commands;
using Demo.Domain.Entities;
using Demo.Domain.Adapters;
using System.Linq;
using NetFusion.Messaging;

namespace Demo.App.Handlers
{
    public class AutoRegistrationHandler : IMessageConsumer
    {
        private readonly IRegistrationDataAdapter _adapter;

        public AutoRegistrationHandler(
            IRegistrationDataAdapter adapter)
        {
             _adapter = adapter;
        }

        [InProcessHandler]
        public async Task<RegistrationStatus> RegisterAuto(RegisterAutoCommand command)
        {
            if (command.Year < 2000)
            {
                throw new InvalidOperationException(
                    "Cars must be newer than the 2000 model year.");
            }

            AutoInfo[] validModels = await _adapter.GetValidModelsAsync(command.Year);

            return new RegistrationStatus {
                IsSuccess = IsValidMakeAndModel(command, validModels),
                ReferenceNumber = Guid.NewGuid().ToString(),
                DateAccountActive = DateTime.UtcNow
            };
        }

        private static bool IsValidMakeAndModel(RegisterAutoCommand command,
            AutoInfo[] validModels)
        {
            return validModels.Any(
                m => m.Make == command.Make &&
                m.Model == command.Model);
        }
    }
}
