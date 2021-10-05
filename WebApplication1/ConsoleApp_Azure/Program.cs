using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Azure.Storage;
using System;

namespace ConsoleApp_Azure
{
    class Program
    {
        static string conn = "DefaultEndpointsProtocol=https;AccountName=sqlvattwtwpybsdjcs;AccountKey=3633/nZVDS43fuhaNFVy7p9F23+OPuxbYSauDKxqvZaveg40hlwR83nnaKQgGiSxNd7jt7/UhXUkKmKfBTLW7w==;EndpointSuffix=core.windows.net";
        static string queuename = "bloba1908g";
        static void Main(string[] args)
        {
            CloudStorageAccount cloudStorageAcoount = CloudStorageAccount.Parse(conn);
            if (cloudStorageAcoount != null)
            {
                BlobContainerClient blobContainerClient = new BlobContainerClient(conn, queuename);
                blobContainerClient.CreateIfNotExists();
                Console.WriteLine("Data blob");
				// List all blobs in the container
				//var Upload = blobContainerClient.GetBlobClient("Screenshot (4).png"); //upload
				//using (var fileStream = System.IO.File.OpenRead(@"D:\o C\Pictures\Screenshots\Screenshot (4).png")) 
				//{
				//	Upload.Upload(fileStream);
				//	Console.WriteLine("Upload thành công");
				//}
				var blobs = blobContainerClient.GetBlobs();
                foreach (BlobItem blobItem in blobs)
                {
                    Console.WriteLine("\t" + blobItem.Name);
                }
                var Download = blobContainerClient.GetBlobClient("Duyli.jpg");
                using (var fileStream = System.IO.File.OpenWrite(@"D:\o C\Pictures\Screenshots\Duyli.jpg"))
                {
                    Download.DownloadTo(fileStream);
                    Console.WriteLine("Download thành công");
                }
                //GetBlob(cloudStorageAcoount);
                Console.ReadLine();
            }
        }
    }
}
