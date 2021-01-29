using System;
using System.IO;

namespace Autopark.Creator
{
    public class LoadFile
    {
        public static string CreatePath(string fileName)
        {
            string path = @"V:\dev\AutoparkProject\Autopark\Data\" + fileName;

            try
            {
                if (!File.Exists(path))
                    throw new Exception("File don't exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }

            return path;
        }

        public static string[] GetStrings(string path)
        {
            using (StreamReader st = File.OpenText(path))
            {
                return File.ReadAllLines(path);
            }
        }

        public static string ReadAllText(string path)
        {
            using (StreamReader st = File.OpenText(path))
            {
                return File.ReadAllText(path);
            }
        }
    }
}
