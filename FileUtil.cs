using System;
using System.IO;

namespace ProjetoStreamingCS
{
    public class FileUtil
    {
        static public void UpdateLine(string filePath, string newText, int line)
        {
            string[] plans = File.ReadAllLines(filePath);
            plans[line - 1] = newText;
            File.WriteAllLines(filePath, plans);
            //reference:
            //https://stackoverflow.com/questions/1971008/edit-a-specific-line-of-a-text-file-in-c-sharp
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