using System;

namespace Items.Menu{

    internal class ShowHistory : IItemMenu
    {
        
        public string Name(){
            return ("Historico Cliente");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }
    
}