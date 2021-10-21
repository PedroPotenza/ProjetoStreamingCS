using System;
using ProjetoStreamingCS;

namespace Items.Menu{
    
    internal class RegisterMovie : IItemMenu
    {
        
        public string Name(){
            return ("Cadastrar/Atualizar Filme");
        }

        public void Execute(){

            Console.WriteLine("---- " + Name() + " ----\n");

            Console.WriteLine(" 1 - Cadastrar um novo filme");
            Console.WriteLine(" 2 - Cadastrar um novo filme");
            Console.WriteLine(" 3 - Voltar ao menu principal");

            int opcao = Validation.OptionReadValidation(1,3);
            
            switch(opcao)
            {
                case 1:{
                    Console.Clear();
                    Console.WriteLine( "RegisterMovieInFile");
                    //RegisterMovieInFile
                    break;
                }

                case 2:{
                    Console.Clear();
                    Console.WriteLine("Update Movie");
                    //UpdateMovie
                    break;
                }

                case 3:{
                    FileUtil.BackToMenu();
                    break;
                }
            }
            

            //Selecionou no registrar Filme
            //aparece uma mensagem perguntando se ele quer adicionar um filme ou atualizar um existente
                //se ele quer adicionar um, atualiza o id automatico e pede as informações
                //se ele quer atualizar:
                    //aparece uma lista com 10 filmes
                    //pergunta qual ele quer dar update (ele pode dar o id ou o nome do filme)
                    //apos selecionar o filme, limpa a tela 
                    //imprime todas as informações do filme
                    //recebe as novas informações

        }  
    }
}