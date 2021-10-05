using System;

namespace Items.Menu{

    internal class WatchMovie : IItemMenu
    {
        
        public string Name(){
            return ("Assistir filme");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }
    
}