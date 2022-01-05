using LAB5.Entities;
using System;
using zz.Collections;
using zz.Entities;

namespace zz
{
    class Program
    {
        private static MainMenu mm = new();

        static void Main()
        {
            Journal events = new();
            ATE at = new();

            at.CallEvent += events.AddEvent;

            mm.Menu(at);
        }
    }
}
