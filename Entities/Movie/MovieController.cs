using System;
using Utils.FileUtil;

namespace Entities.Controller
{
    public class MovieController
    {
        static private string filePath = @"./DataBase/Movies.txt";
        static public void addMovie()
        {

        }

        /// <summary>
        /// Search for a movie by Id or Name. Already with exception tratament if the movie isn't possible to be find.
        /// </summary>
        /// <param name="dataMovie">Id or Name to search.</param>
        /// <returns>If find a movie, returns movie. If not, returns null.</returns>
  
        static internal Movie FindMovie(string dataMovie)
        {

            bool findById = Int32.TryParse(dataMovie, out int Id);
            if(findById)
            {

                if(Id >= 1001 && Id<=1000+FileUtil.CountFile(filePath))
                {
                    Movie movie = new Movie(Id);
                    return movie;
                }
                else
                {
                    //WRONG: This don't supposed to be here
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Não foi possivel localizar o filme com o Id correspondente a \"{0}\"", Id);
                    Console.ResetColor();
                    //WRONG: This don't supposed to be here
                    return null;
                }

            }
            else
            {
                try
                {
                    Movie movie = new Movie(dataMovie);
                    return movie;
                }
                catch(NullReferenceException) //ASK: it's possible to see if that movie exist without a exception? 
                {
                    //WRONG: This don't supposed to be here
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Não foi possivel localizar o filme \"{0}\"", dataMovie);
                    Console.ResetColor();
                    //WRONG: This don't supposed to be here
                    return null;
                }

            }
        }
    }
}