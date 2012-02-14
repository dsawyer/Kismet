using System;
using System.Collections.Generic;
using System.Linq;
using KismetDataTypes;

namespace Kismet
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (Kismet game = new Kismet())
            {
                game.Run();
            }
        }
    }
#endif
}

