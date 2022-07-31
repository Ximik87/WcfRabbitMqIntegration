using System.ServiceModel;
using Contracts;

namespace RabbitMQ.Wcf.ConsoleClientLoad
{
    public class TestContractClient : ClientBase<ITestContract>, ITestContract
    {

        public TestContractClient(string configurationName)
            : base(configurationName)
        {
        }

        public void Create(string name)
        {
            Channel.Create(name);
        }
    }
}