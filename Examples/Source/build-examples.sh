
dotnet clean ./CQRS/src
dotnet clean ./Demo/src
dotnet clean ./DemoSubscriber/src/Demo.Subscriber
dotnet clean ./Mappings/src
dotnet clean ./MongoDb/src
dotnet clean ./RabbitMq/src
dotnet clean ./RabbitMqSubscriber/src/Demo.Subscriber
dotnet clean ./ServiceBus/src
dotnet clean ./ServiceBusSubscriber/src/Demo.Subscriber
dotnet clean ./Settings/src
dotnet clean ./REST/src
dotnet clean ./Bootstrap

dotnet build ./CQRS/src
dotnet build ./Demo/src
dotnet build ./DemoSubscriber/src/Demo.Subscriber
dotnet build ./Mappings/src
dotnet build ./MongoDb/src
dotnet build ./RabbitMq/src
dotnet build ./RabbitMqSubscriber/src/Demo.Subscriber
dotnet build ./ServiceBus/src
dotnet build ./ServiceBusSubscriber/src/Demo.Subscriber
dotnet build ./Settings/src
dotnet build ./REST/src
dotnet build ./Bootstrap
