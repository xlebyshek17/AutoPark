using System;
using System.IO;

namespace Autopark.Creator
{
    public class LoadFile
    {
        public static string CreatePath(string fileName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.FullName + @"\Data\"+ fileName;

            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException("File don't exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }

            return path;
        }

        public static string[] GetStrings(string path, char[] separator)
        {
            using (StreamReader st = File.OpenText(path))
            {
                return st.ReadToEnd().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
