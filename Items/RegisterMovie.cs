using System;

namespace Items.Menu{
    
    internal class RegisterMovie : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar Filme");
        }

        public void Execute(){

            Console.WriteLine("---- " + Name() + " ----\n");  
            /*
            instancio um objeto filme
            informa qual o codigo do filme a ser cadastrado (1001 + contador de filmes atuais no banco)
            ler os dados do filme (e inserir no objeto)
            escrever objeto no arquivo Movies.txt
            incrementar a quantidade de filmes no Contadores.txt
            */

        }  
    }
}