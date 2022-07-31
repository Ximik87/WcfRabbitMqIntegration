using System;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageReceiverNetClassic
{
    internal class RabbitMQMessageReceiver
    {
        public static void DoWork()
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {     
                var channel = connection.CreateModel();

                //Create a queue for messages destined to this service, bind it to the service URI routing key
                string queue = channel.QueueDeclare();
                var exchange = "amq.direct";
                channel.QueueBind(queue, exchange, "/wcfQueue", null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) => { NewMethod(ea, channel); };
                channel.BasicConsume(queue, true, consumer);

                Console.WriteLine(" Receiver started!\n Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        private static void NewMethod(BasicDeliverEventArgs ea, IModel channel)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine("Received: \n{0}", message);
        }
    }
}
