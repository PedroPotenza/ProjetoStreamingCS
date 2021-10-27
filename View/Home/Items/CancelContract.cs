using System;
using View.Menu;

namespace Items{

    internal class CancelContract : IItemMenu
    {
        
        public string Name(){
            return ("Cancelar Contrato");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }
    
}