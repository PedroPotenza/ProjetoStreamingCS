using System;
using System.IO;
using Entities;
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
            Console.WriteLine(" 2 - Atualizar um filme existente");
            Console.WriteLine(" 3 - Voltar ao menu principal");

            int opcao = Validation.OptionReadValidation(1,3);
            
            switch(opcao)
            {
                case 1:{
                    Console.Clear();
                    RegisterMovieInFile();
                    break;
                }

                case 2:{
                    
                    UpdateMovie();
                    break;
                }

                case 3:{
                    FileUtil.BackToMenu();
                    break;
                }
            }                     
        }  

        private void RegisterMovieInFile()
        {
            //se ele quer adicionar um, atualiza o id automatico e pede as informações
            Console.WriteLine( "RegisterMovieInFile");
        }

        private void UpdateMovie()
        {

            int firstIdOfPage = 1;
            ChangePage:
            Console.Clear(); 
            Console.WriteLine("------------------------------------------ LISTA DE FILMES ----------------------------");
            
                Console.WriteLine("\n\tId\tNome\t\t\t\t\t\t\tClassificação");
                bool HaveNextPage = ShowListMovie(firstIdOfPage, firstIdOfPage+9);
                if(!HaveNextPage) HaveNextPage = false; //if in this page dont have any more movies, dont be possible go to next page

            Console.WriteLine("\n----------------------------------------------[ 1/10]-----------------------------------");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPara avançar uma página na lista de filmes digite \"next\"");
            Console.WriteLine("Para voltar uma página na lista de filmes digite \"back\"");
            Console.ResetColor();

            Console.WriteLine("\nInforme o Id ou o Nome do Filme");
            string dataString = Validation.StringReadValidation("Filme Selecionado: ");

            if(dataString == "next")
            {
                if(HaveNextPage){
                    firstIdOfPage += 10;
                }
                goto ChangePage;
            } 

            if(dataString == "back")
            {
                if(firstIdOfPage != 1)
                {
                    firstIdOfPage -= 10;    
                }
                goto ChangePage;
            }


            //pergunta qual ele quer dar update (ele pode dar o id ou o nome do filme)
            //apos selecionar o filme, limpa a tela 
            //imprime todas as informações do filme
            //recebe as novas informações

            Console.WriteLine("Update Movie");
        }

        private bool ShowListMovie(int lower, int upper)
        {
            for(; lower<=upper; lower++)
            {
                try{
                    Movie movie = new Movie(1000+lower);
                    movie.ShowMovieShort();
                    
                }
                catch(NullReferenceException)
                {
                    Console.WriteLine();
                    return false;
                }
            }
            return true;
        }
    }
}