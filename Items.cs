using System;

namespace ProjetoStreamingCS
{
    internal class CadastrarCliente : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar Cliente");
        }

        public void Execute(){
            Console.WriteLine("Opção Cadastrar Cliente selecionada\n");
        }
    }
}