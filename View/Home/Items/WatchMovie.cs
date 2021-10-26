using System;
using View.Menu;

namespace Home.Items{

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