using System;
using View.Menu;

namespace Home.Items{

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