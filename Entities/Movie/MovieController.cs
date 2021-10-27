using System;
using System.IO;
using System.Linq;
using Utils.FileUtil;

namespace Entities.Controller
{
    internal class MovieController //: Controller
    {

        static string filePath = @"./DataBase/Movie.txt";

        /*
        override internal void changeFilePath()
        {
            filePath = @"./DataBase/Movie.txt";
        }
        */

         static internal int Count() 
        {
            var lineCount = 0;
            using (var reader = File.OpenText(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            return(lineCount);
        }

        static public void Update(string newText, int line_to_edit)
        {
            
            string tempFile = @"./DataBase/Temp.txt";

            // Read from the target file and write to a new file.
            int line_number = 1;
            string line = null;
            using (StreamReader reader = new StreamReader(filePath))
            using (StreamWriter writer = new StreamWriter(tempFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line_number == line_to_edit)
                    {
                        writer.WriteLine(newText);
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                    line_number++;
                }
            }

            string name = filePath.Split('/').Last();
            File.Delete(filePath);
            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(tempFile, name);

            //reference:
            //https://stackoverflow.com/questions/1971008/edit-a-specific-line-of-a-text-file-in-c-sharp
            //https://stackoverflow.com/questions/3218910/rename-a-file-in-c-sharp
            //https://docs.microsoft.com/pt-br/dotnet/api/microsoft.visualbasic.fileio.filesystem.renamefile?view=net-5.0
            
        }

        //Idea: make a interface? or a abstract class and override methods like add, update, delete
        static internal void Add()
        {

        }

        //OBS: I think this logic maybe be something irrelevant... LineById and FindById sounds a bit redudant lol
        static internal string[] LineById(int id)
        {
            var reader = File.OpenText(filePath);
            
            for(int i=1; i < id - 1000; i++)
                reader.ReadLine();
            
            string line = reader.ReadLine();
            reader.Close();
            string[] atributes = line.Split(';');
            return atributes;
        }

        static private Movie FindById(int id)
        {
            if(id >= 1001 && id <= 1000 + MovieController.Count())
            {
                Movie movie = new Movie(id);
                return movie;
            }
            else
            {
                return null;
            }
        }

        static private Movie FindByName(string name)
        {

            var reader = File.OpenText(filePath);

            bool exist = false;     
            while(!exist)
            {           
                string line = reader.ReadLine();
                string[] atributes = line.Split(';');

                string nameOnLine = atributes[1];
             
                if(nameOnLine == name)
                {
                    Movie movie = new Movie(int.Parse(atributes[0]));
                    return movie;
                }
            }
            
            return null;
            
        }


        /// <summary>
        /// Search for a movie by Id or Name. Already with exception tratament if the movie isn't possible to be find.
        /// </summary>
        /// <param name="dataMovie">Id or Name to search.</param>
        /// <returns>If find a movie, returns movie. If not, returns null.</returns>
  
        static internal Movie FindMovie(string dataMovie)
        {

            bool searchById = Int32.TryParse(dataMovie, out int Id);
            return searchById ? FindById(Id) : FindByName(dataMovie);

        }
    }
}