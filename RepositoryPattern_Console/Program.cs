using RepositoryPattern_Console.Consoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomConsole _console;

            Console.WriteLine("Choose Language:\n" +
                "1. English (Ingles)\n" +
                "2. Spanish (Espanyol)");

            switch (Console.ReadLine())
            {
                case "1":
                    _console = new CustomConsole();
                    break;
                case "2":
                     _console = new CustomConsoleDos();
                    break;
                default:
                    _console = new CustomConsole();
                    break;
            }
            StreamingContentUI _ui = new StreamingContentUI(_console);

            _ui.Start();
        }
    }
}
