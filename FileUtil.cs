using System;
using System.IO;
using System.Linq;

namespace ProjetoStreamingCS
{
    public class FileUtil
    {
        
        static public void UpdateLine(string filePath, string newText, int line_to_edit)
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

        static public void AddLine(string filePath, string newText)
        {
            File.AppendAllText(filePath, Environment.NewLine + newText);
        }

        static public int CountFile(string filePath)
        {
            var lineCount = 0;
            using (var reader = File.OpenText(@filePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
            return(lineCount);
        }

         static public void BackToMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu principal.");
            Console.ResetColor();
        }
    }
}