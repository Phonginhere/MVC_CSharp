using Microsoft.Azure.Storage.Queue;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Storage.Auth;
using System;
using System.Text;

namespace Azure_Storage_Table
{
	class Program
	{
        static String connect = "DefaultEndpointsProtocol=https;AccountName=sqlvattwtwpybsdjcs;AccountKey=3633/nZVDS43fuhaNFVy7p9F23+OPuxbYSauDKxqvZaveg40hlwR83nnaKQgGiSxNd7jt7/UhXUkKmKfBTLW7w==;EndpointSuffix=core.windows.net";
        static void Main(string[] args)
		{
            CloudStorageAccount cloudacc = CloudStorageAccount.Parse(connect);
            if (cloudacc != null)
            {
                CloudTableClient cloudTableClient = cloudacc.CreateCloudTableClient();
                CloudTable clouldTable = cloudTableClient.GetTableReference(cloudTableEntityName);
				getTableEntity(cloudacc);
				AddTableEntity(clouldTable);
				Console.ReadLine();
            }
        }
        static string cloudTableEntityName = "tablea1908g";
        static void getTableEntity(CloudStorageAccount cloudStorageAccount)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            CloudTable cloudQueue = cloudTableClient.GetTableReference(cloudTableEntityName);

            var myQueryTable = new TableQuery<Student>();
            var students = cloudQueue.ExecuteQuery(myQueryTable);

            foreach (var s in students)
            {
                Console.WriteLine("Data : |{0,19} | %{1,15} | {2,15} | {3,10} | {4,10}",
                    s.PartitionKey, s.RowKey, s.name, s.mark, s.comment);
            }
        }
		static bool AddTableEntity(CloudTable table)
		{
			// dữ liệu mẫu
			var newEntity = new Student()
			{
				PartitionKey = "p_Phong 20/09/06",
				RowKey = "Phong 21/09/06",
				name = "Trần Hải Phong 21/09/06",
				mark = "10",
				comment = "ko có gì"
			};

			TableOperation insert = TableOperation.Insert(newEntity);
			try
			{
				Console.InputEncoding = Encoding.UTF8;
				Console.WriteLine("Begin Insert Data...");
				Console.WriteLine("Data: | {0,19} | {1,15} | {2,15} | {3,10} | {4,10} ", newEntity.PartitionKey, newEntity.RowKey, newEntity.name, newEntity.mark, newEntity.comment);
				table.Execute(insert);
				//Console.ReadLine();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}
	}
}
