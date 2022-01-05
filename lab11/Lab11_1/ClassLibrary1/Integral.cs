using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Integral
    {
        public delegate void about(double result);
        public static event about Message;

        public static void IntegrationOfSinus(object sinus)
        {
            double result = 0;
            Console.WriteLine(Thread.CurrentThread.ThreadState);
            Stopwatch watch = new ();
            watch.Start();

            var integrationparams = (ParamsOfIntegration)sinus;
            var step = (integrationparams.To - integrationparams.From) / integrationparams.n;

            for (var i = 0; i < integrationparams.n; i++)
                result += Math.Sin(integrationparams.From + step * (i + 0.5));

            result *= step;
            watch.Stop();
            Message?.Invoke(result);
            Console.WriteLine(watch.Elapsed);
        }
    }
}
