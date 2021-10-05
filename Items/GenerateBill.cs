using System;

namespace Items.Menu{

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