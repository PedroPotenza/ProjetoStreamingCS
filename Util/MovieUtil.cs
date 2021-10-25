using System;
using Entities;
using InputValidation;

namespace ProjetoStreamingCS
{
    public class MovieUtil
    {/*
        static public void ShowListMovie(int page)
        {
            int lastPage = (FileUtil.CountFile(@"./DataBase/Movies.txt")/10)+1;
            int firstIdOfPage = 1000 + (10*(page-1))+1;
            int lastIdOfPage = firstIdOfPage + 9;

            Console.Clear(); 
                Console.WriteLine("----------------------------------- LISTA DE FILMES -----------------------------------");
                
                    Console.WriteLine("\n\tId\tNome\t\t\t\t\t\t\tClassificação");
                    ShowItemMovie(firstIdOfPage, lastIdOfPage);
    
                Console.WriteLine("\n-------------------------------------- [{0}/{1}] -----------------------------------------", page,lastPage);
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPara avançar uma página na lista de filmes digite \"next\"");
                Console.WriteLine("Para voltar uma página na lista de filmes digite \"back\"");
                Console.WriteLine("Para voltar ao menu principal digite \"home\"");
                Console.ResetColor();
        }

        /// <summary>
        /// USAR ESSE METODO PARA CHAMAR 
        /// </summary>
        /// <param name="message"></param>
        static public bool ControllerOfListMovies(string message, Movie movie)
        {
            int page = 1;
            int lastPage = (FileUtil.CountFile(@"./DataBase/Movies.txt")/10)+1;

            while(true)
            {

                ShowListMovie(page);

                Console.WriteLine("\n" + message);
                
                bool ask = true;
                while(ask)
                {
                    string dataString = Validation.StringRead("Filme Selecionado: ");

                    switch(dataString)
                    {
                        case "home":
                        {
                            FileUtil.BackToMenu();
                            //don't repeat anything, go to home
                            return false;
                        }         

                        case "next":
                        {
                            if(page != lastPage)
                            {
                                page++;
                                ask = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\nUltima página alcançada!\n");
                                Console.ResetColor(); 
                            }
                            break;
                        }

                        case "back":
                        {
                            if(page != 1)
                            {
                                page--;    
                                ask = false;
                            } 
                            else 
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\nVocê ja está na primeira pagina!\n");
                                Console.ResetColor();
                            }
                            break;
                        }

                        default:
                        {
                            bool findSucess = FindMovie(dataString, movie);
                            
                            if(findSucess)
                            {
                                ask = false;
                                movie.ShowMovieLong();

                                Console.WriteLine("\nConfirma a escolha do filme?");
                                bool opcao = Validation.ReadYesOrNot();
                                return opcao;
                            }
                            else 
                            {
                                return false;
                            }
                            
                        }

                    }
                }
            }
        }

        static private bool FindMovie(string dataMovie, Movie movie)
        {

            bool findById = Int32.TryParse(dataMovie, out int Id);
            if(findById)
            {

                if(Id >= 1001 && Id<=FileUtil.CountFile(@"./DataBase/Movies.txt"))
                {
                    movie = new Movie(Id);
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Não foi possivel localizar o filme com o Id correspondente a \"{0}\"", Id);
                    Console.ResetColor();
                    return false;
                }

            }
            else
            {
                try
                {
                    movie = new Movie(dataMovie);
                    return true;
                }
                catch(NullReferenceException) //ASK: it's possible to see if that movie exist without a exception? 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Não foi possivel localizar o filme \"{0}\"", dataMovie);
                    Console.ResetColor();
                    return false;
                }

            }
        }
        static private void ShowItemMovie(int lower, int upper)
        {
            for(;lower<=upper; lower++)
            {
                try{
                    Movie movie = new Movie(lower);
                    movie.ShowMovieShort();
                    
                }
                catch(NullReferenceException)
                {
                    Console.WriteLine();
                }
            }
        }      
    */}
}
