using System;
using Entities;
using InputValidation;
using Utils.FileUtil;
using View.Menu;

namespace Home.Items{
    
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

            int opcao = Validation.OptionRead(1,3);
            
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
            //Movie movie = new Movie();
            Movie movie = Movie.ControllerOfListMovies("Informe o Id ou o Nome do filme a ser atualizado.");
            
            if(movie != null)
                movie.ShowMovieShort();
            else
            {
                FileUtil.BackToMenu();      
            }

        }

    }
}