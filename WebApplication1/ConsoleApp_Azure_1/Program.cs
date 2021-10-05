using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;

namespace Queue_Storage_In_Azure
{
    class Program
    {
        public static string connstring = "DefaultEndpointsProtocol=https;AccountName=sqlvattwtwpybsdjcss;AccountKey=7nbfYGd9EDEKOekc+DVDZECWzT5F/mhnt0RBbQ8rvqaTX4ple9cCSeLBC97CjhJLjiHeVh4Kd/Cl8CxMptrpig==;EndpointSuffix=core.windows.net";
        static String myQueueName = "queuea1908g";
        static void Main(string[] args)
        {
            //AddMessage();
            RetrieveMessage();
            //AddMessage();
            Console.ReadKey();
        }

        public static void AddMessage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connstring);
            CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference(myQueueName);
            CloudQueueMessage queueMessage = new CloudQueueMessage("Hello, Message Created by Console Application");
            cloudQueue.AddMessage(queueMessage);
            Console.WriteLine("Message sent");

        }

        public static void RetrieveMessage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connstring);
            CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference(myQueueName);
            CloudQueueMessage queueMessage = cloudQueue.GetMessage();
            Console.WriteLine(queueMessage.AsString);
            cloudQueue.DeleteMessage(queueMessage);

        }
    }
}
