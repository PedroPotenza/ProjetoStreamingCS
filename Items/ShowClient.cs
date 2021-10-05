using System;

namespace Items.Menu{

    internal class ShowClient : IItemMenu
    {
        
        public string Name(){
            return ("Dados Cliente");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }
    
}