using System;
using Entities;

namespace ProjetoStreamingCS
{
    public class ListUtil
    {
        static public void ShowListMovie(string mensage)
        {
            
            int firstIdOfPage = 1;
            int page = 1;
            int lastPage = (FileUtil.CountFile(@"./DataBase/Movies.txt")/10)+1;

            ListOfMovies:
                Console.Clear(); 
                Console.WriteLine("----------------------------------- LISTA DE FILMES -----------------------------------");
                
                    Console.WriteLine("\n\tId\tNome\t\t\t\t\t\t\tClassificação");
                    ShowItemMovie(firstIdOfPage, firstIdOfPage+9);
    
                Console.WriteLine("\n-------------------------------------- [{0}/{1}] -----------------------------------------", page,lastPage);
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPara avançar uma página na lista de filmes digite \"next\"");
                Console.WriteLine("Para voltar uma página na lista de filmes digite \"back\"");
                Console.WriteLine("Para voltar ao menu principal digite \"home\"");
                Console.ResetColor();

                Console.WriteLine("\n" + mensage);
            Ask:
                string dataString = Validation.StringReadValidation("Filme Selecionado: ");

            if(dataString == "next")
            {
                if(page != lastPage){
                    firstIdOfPage += 10;
                    page++;
                    goto ListOfMovies;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nUltima página alcançada!\n");
                Console.ResetColor();
                goto Ask; //if the user are on last page dont write all the context again
            } 

            if(dataString == "home")
            {
                FileUtil.BackToMenu();
            } 
            else 
            {
                if(dataString == "back")
                {
                    if(page != 1)
                    {
                        firstIdOfPage -= 10;
                        page--;    
                        goto ListOfMovies;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nVocê ja está na primeira pagina!\n");
                    Console.ResetColor();
                    goto Ask;
                }

                bool findById = Int32.TryParse(dataString, out int Id);
                
                Movie movie = new Movie();
                if(findById)
                {
                    if(Id >= 1001 && Id<=FileUtil.CountFile(@"./DataBase/Movies.txt"))
                    {
                        movie = new Movie(Id);
                        movie.ShowMovieLong();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não foi possivel localizar o filme com o Id correspondente a \"{0}\"", Id);
                        Console.ResetColor();
                        goto Ask;
                    }
                }
                else
                {
                    try
                    {
                        movie = new Movie(dataString);
                    }
                    catch(NullReferenceException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não foi possivel localizar o filme \"{0}\"", dataString);
                        Console.ResetColor();
                        goto Ask;
                    }
                }
   
                movie.ShowMovieLong();

                Console.WriteLine("\nConfirma a escolha do filme?");
                bool opcao = Validation.ReadYesOrNot();

                if(opcao)
                {
                    Console.WriteLine("recebe as infos");
                    //receber novas informações
                }
                else
                {
                    goto ListOfMovies;
                }
            }
        }
        static private void ShowItemMovie(int lower, int upper)
        {
            for(;lower<=upper; lower++)
            {
                try{
                    Movie movie = new Movie(1000+lower);
                    movie.ShowMovieShort();
                    
                }
                catch(NullReferenceException)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}