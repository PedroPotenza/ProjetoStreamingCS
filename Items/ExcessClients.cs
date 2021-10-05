using System;

namespace Items.Menu{

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