using System;
using gasolineraKalum.Entities;
using gasolineraKalum.Controllers;
using static gasolineraKalum.Util.Printer;
using gasolineraKalum.Menu;

namespace gasolineraKalum
{
    class Program
    {
        static void Main(string[] args)
        {
            Beep();
            WriteTitle("Gasolinera KAlum");
            new MenuPrincipal().MostrarMenu();
            PrecionarEnter();
        }
    }
} 
    