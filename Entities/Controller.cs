using System.IO;
using System.Linq;

namespace Entities.Controller
{
    abstract class Controller
    {
        
        static public string filePath;

        virtual internal void changeFilePath()
        {

        }

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
    }
}