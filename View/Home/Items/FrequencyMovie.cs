using System;
using View.Menu;

namespace Items{

    internal class FrequencyMovie : IItemMenu
    {
        
        public string Name(){
            return ("Frequencia de um Filme");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }
    
}