using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace EhProducer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "EhConnectionString";
            EventHubClient client = EventHubClient.CreateFromConnectionString(connectionString);
            int i = 0;
            while (true)
            {
                i++;
                client.Send(new EventData(Encoding.UTF8.GetBytes($"Message {i}")));
                Console.WriteLine($"Message {i}");
                Task.Delay(200).Wait();
            }

            
        }
    }
}
