using System;

namespace RabbitMQ.Wcf.ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("type text:");
                var answer = Console.ReadLine();

                if (answer == "n")
                    break;

                var client = new TestContractClient("Service1OverRabbit");
                client.Create(answer);
            }

            Console.WriteLine("All record sent successfully");
            Console.ReadLine();
        }
    }
}
