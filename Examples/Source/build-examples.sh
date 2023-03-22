
dotnet clean ./Examples.Monitoring/src
dotnet clean ./Examples.RabbitMQ/src
dotnet clean ./Examples.Redis/src
dotnet clean ./Examples.ServiceBus/src

dotnet build ./Examples.Monitoring/src
dotnet build ./Examples.RabbitMQ/src
dotnet build ./Examples.Redis/src
dotnet build ./Examples.ServiceBus/src

