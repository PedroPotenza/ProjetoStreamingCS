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
            File.AppendAllText(filePath, newText);
        }
    }
}