using System;
using Examples.Mapping.Domain.Services;

namespace Examples.Mapping.App.Services;

public class EntityIdGenerator : IEntityIdGenerator
{
    public string GenerateId()
    {
        return Guid.NewGuid().ToString();
    }
}