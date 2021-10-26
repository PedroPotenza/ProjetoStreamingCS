using System;
using View.Menu;

namespace Home.Items{

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