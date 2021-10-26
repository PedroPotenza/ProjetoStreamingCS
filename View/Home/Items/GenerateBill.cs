using System;
using View.Menu;

namespace Home.Items{

    internal class GenerateBill : IItemMenu
    {
        
        public string Name(){
            return ("Gerar fatura");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }
    
}