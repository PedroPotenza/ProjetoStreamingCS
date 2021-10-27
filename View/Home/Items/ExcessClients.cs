using System;
using View.Menu;

namespace Items{

    internal class ExcessClients : IItemMenu
    {
        
        public string Name(){
            return ("Clientes Execentes");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }
    
}