using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Lab11
{
    class StreamService
    {
        private readonly object locker = new ();

        public void WriteToStream(Stream stream)
        {
            lock (locker)
            {
                var random = new Random();
                Console.WriteLine($"Запись в поток №{Thread.CurrentThread.ManagedThreadId}");
                var streamwriter = new StreamWriter(stream) { AutoFlush = true };
                for (int i = 0; i < 100; i++)
                    streamwriter.WriteLine(i + "\n" + GenerateName(8) + "\n" + GenerateYear());

                Console.WriteLine($"конец записи потока №{Thread.CurrentThread.ManagedThreadId}");
            }
        }

        public Task WriteToStreamTask(Stream stream) => Task.Run(() => WriteToStream(stream));

        public void CopyFromStream(Stream stream, string filename)
        {
            lock (locker)
            {
                Console.WriteLine($"Копируется с потока №{Thread.CurrentThread.ManagedThreadId}");
                stream.Seek(0, SeekOrigin.Begin);
                if (File.Exists(filename)) File.Delete(filename);
                using var fileStream = File.Open(filename, FileMode.OpenOrCreate);
                stream.CopyTo(fileStream);
                Console.WriteLine($"конец копирования потока №{Thread.CurrentThread.ManagedThreadId}");
            }
        }

        public Task CopyFromStreamTask(Stream stream, string filename) => Task.Run(() => CopyFromStream(stream, filename));

        public int GetStatistics(string filename, Func<ClientsOfBank, bool> filter)
        {
            lock (locker)
            {
                Console.WriteLine($"подсчет в потоке №{Thread.CurrentThread.ManagedThreadId}");
                var streamReader = new StreamReader(File.Open(filename, FileMode.Open));
                var count = 0;
                while (!streamReader.EndOfStream)
                {
                    var client = new ClientsOfBank
                    {
                        ID = Convert.ToInt32(streamReader.ReadLine()),
                        Name = streamReader.ReadLine(),
                        Year = Convert.ToInt32(streamReader.ReadLine()),
                    };
                    if (filter(client))
                        count++;
                }
                streamReader.Dispose();
                Console.WriteLine($"конец вычисления статистики из потока №{Thread.CurrentThread.ManagedThreadId}");
                return count;
            }
        }

        public async Task<int> GetStatisticsAsync(string filename, Func<ClientsOfBank, bool> filter) =>
            await Task.Run(() => GetStatistics(filename, filter));

        public static string GenerateName(int len)
        {
            Random r = new();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }
        public static int GenerateYear()
        {
            Random random = new();
            int year = random.Next(1, 21) + 2000;
            return year;
        }
    }
}
