using System;

namespace Items.Menu{

    internal class RegisterContract : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar Contrato");
        }

        public void Execute(){
            Console.WriteLine("---- " + Name() + " ----\n");        
        }
    }
    
}