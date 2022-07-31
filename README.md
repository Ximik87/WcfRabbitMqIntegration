# WcfRabbitMqIntegration

This repository demonstrate example integration Wcf of RabbitMQ binding and tools for testing this integration

These projects are on .Net framework:

- RabbitMQ.ServiceModel - RabbitMQBinging for WCF, original source [here](https://github.com/rabbitmq/rabbitmq-dotnet-client/tree/v4_0_1/projects/wcf/RabbitMQ.ServiceModel)
- RabbitMQ.Wcf.ConsoleClient - WCF client for RabbitMQBinding, for send test messages
- RabbitMQ.Wcf.ConsoleClientLoad - WCF client for RabbitMQBinding, for performance testing
- RabbitMQ.Wcf.ConsoleHost - simple WCF host, for process test messages
- MessageReceiverNetClassic - tool for receive and decode RabbitMQ message from WCF client