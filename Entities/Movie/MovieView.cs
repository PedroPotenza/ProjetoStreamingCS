using System;
using Entities.Controller;
using Utils.FileUtil;
using Utils.InputValidation;

namespace Entities.View
{
    static public class MovieView
    {
        static private void ShowMovieShort(Movie movie)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\t" + movie.id);
            Console.Write("\t" + movie.name );
            for(int i = movie.name.Length; i <=50; i++)
                Console.Write(" ");
            Console.Write("\t" + movie.rating + "\n");
            Console.ResetColor();
        }

        static private void ShowMovieLong(Movie movie)
        {
            Console.Clear();
            Console.WriteLine("".PadRight(57,'-'));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Id: " + movie.id);
            Console.WriteLine("Nome: " + movie.name);
            Console.WriteLine("Sinopse: " + movie.plot);
            Console.WriteLine("Ano: " + movie.year);
            Console.WriteLine("Diretor: " + movie.director);
            Console.WriteLine("Classificação: " + movie.rating);
            Console.WriteLine("Generos: ");
            Console.ResetColor();
            Console.WriteLine("".PadRight(57,'-'));
        }

        /// <summary>
        /// Clear console and show a list of movies, every item of list is a short description.
        /// (it just show, the fuction can't move around the pages)
        /// </summary>
        /// <param name="page">The page that should be shown.</param>
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

        static private void ShowItemMovie(int lower, int upper)
        {
            for(;lower<=upper; lower++)
            {
                try{
                    Movie movie = new Movie(lower);
                    ShowMovieShort(movie);
                    
                }
                catch(NullReferenceException)
                {
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Show a list of movies with a page controller and ask to user select a movie. If selected movie exist clear console and show a long description of him, after that confirm the selection.
        /// </summary>
        /// <param name="message">Message show after list movies and before of "Filme selecionado: ".</param>
        /// <returns>If find a movie, returns movie. If not, returns null.</returns>
        static internal Movie ControllerOfListMovies(string message)
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
                            return null;
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
                            Movie movie = MovieController.FindMovie(dataString);
                            
                            if(movie != null)
                            {
                                ask = false;
                                ShowMovieLong(movie);

                                Console.WriteLine("\nConfirma a escolha do filme?");
                                bool opcao = Validation.ReadYesOrNot();
                                return movie;
                            }
                            else 
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Não foi possivel localizar o filme \"{0}\"", dataString);
                                Console.ResetColor();
                                return null;
                            }
                            
                        }
                    }
                }
            }
        }      
    }
}