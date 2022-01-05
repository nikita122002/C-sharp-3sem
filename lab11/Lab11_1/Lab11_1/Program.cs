using System;
using System.Threading;
using ClassLibrary1;

namespace Lab11_1
{
    class Program
    {
        static void Main()
        {
            Integral.Message += Event.Status;
            var obj = new ParamsOfIntegration(0, 1, 100000000);
            Thread stream1 = new (Integral.IntegrationOfSinus);
            Thread stream2 = new (Integral.IntegrationOfSinus);
            stream1.Priority = ThreadPriority.Lowest;
            stream2.Priority = ThreadPriority.Highest;
            stream1.Start(obj);
            stream2.Start(obj);

        }
    }
}
