namespace MessageReceiverNetClassic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RabbitMQMessageReceiver.DoWork();
        }
    }
}
