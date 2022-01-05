using System;
using System.IO;
using System.Threading.Tasks;

namespace Lab11
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Func<ClientsOfBank, bool> check = ClientsOfBank.IfTrue;
            var memoryStream = new MemoryStream();
            var streamService = new StreamService();
            var stream1 = streamService.WriteToStreamTask(memoryStream);
            var stream2 = streamService.CopyFromStreamTask(memoryStream, "Client.dat");
            await Task.WhenAll(new Task[] { stream1, stream2 });
            Console.WriteLine("Клиентов проходящих фильтр - " + $"{await streamService.GetStatisticsAsync("Client.dat", check)}");
            
        }
    }
}
