//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.ServiceBus.Messaging;

//namespace EhConsumer
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            var connectionString = "Endpoint=sb://ve1appseventssb.servicebus.windows.net/;SharedAccessKeyName=presentation;SharedAccessKey=BJYPCmQJM/cputzoDmPP1qmXymYP1/KKZ6N5yYkYGJY=;EntityPath=panel-app-eventshub-e1";
//            //var connectionString = "Endpoint=sb://winops-event-hubs.servicebus.windows.net/;SharedAccessKeyName=manager;SharedAccessKey=T+9AE70ujS/EKMUY9svheMQIe9Yx61UsCHo2c4lryT4=;EntityPath=testhub";
//            var client = EventHubClient.CreateFromConnectionString(connectionString);
//            var consumerGroup = client.GetConsumerGroup("presentation");
//            List<Task> receiving = new List<Task>();
//            foreach (var partitionId in client.GetRuntimeInformation().PartitionIds)
//            {
//                var receiver = consumerGroup.CreateReceiver(partitionId, DateTime.UtcNow);
//                receiving.Add(ReceiveData(receiver,partitionId));
//            }
//            Task.WaitAll(receiving.ToArray());
//        }

//        public static async Task ReceiveData(EventHubReceiver receiver,string partitionId)
//        {
//            int received = 0;
//            while (true)
//            {
//                var message = await receiver.ReceiveAsync();
//                if (message != null)
//                {
//                    received++;
//                    var menssagem = Encoding.UTF8.GetString(message.GetBytes());
//                    if(received % 100 == 0)
//                    {
//                        Console.WriteLine($"Read: {received} messages. Partition: {partitionId}");
//                    }
//                }
//            }

//        }
//    }
//}
