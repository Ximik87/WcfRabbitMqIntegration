using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQ.Wcf.ConsoleClientLoad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ready ???");
            Console.ReadLine();
            var tasks = new List<Task>();
            var counter = new RpsCounter();
            for (int i = 0; i < 110; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => MultiThread(counter), TaskCreationOptions.LongRunning));
            }

            Task.WaitAll(tasks.ToArray());
        }

        private static void MultiThread(RpsCounter count)
        {
            var client = new TestContractClient("Service1OverRabbit");
            while (true)
            {
                count.Reset();

                var guid = Guid.NewGuid();
                client.Create(guid.ToString());
                count.Inc();
                Thread.Sleep(1);
            }
        }
    }

    internal class RpsCounter
    {
        private readonly object _sync = new object();
        private readonly Stopwatch _watch = Stopwatch.StartNew();
        private int _count;

        public void Inc()
        {
            Interlocked.Increment(ref _count);
        }

        public void Reset()
        {
            if (_watch.ElapsedMilliseconds <= 1000)
                return;

            Console.WriteLine("Send message RPS:" + _count);
            lock (_sync)
            {
                _watch.Restart();
                _count = 0;
            }
        }
    }
}