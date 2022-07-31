using System;
using System.ServiceModel;
using Contracts;

namespace RabbitMQ.Wcf.ConsoleHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(TestService));
            host.Open();

            Console.WriteLine("Service Ready");
            Console.ReadLine();

            host.Close();
        }
    }
}
