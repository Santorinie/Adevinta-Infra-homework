using System;
namespace Adevinta_hw.Helpers
{
    public class FileTaskHelper
    {

        // This class helps Writing and Reading files


        private string Path { get; set; }

        public FileTaskHelper(string filePath)
        {
            this.Path = filePath;
        }

        public string Read()
        {
            return File.ReadAllText(Path);
        }
        public void Write(string content)
        {
            File.WriteAllText(Path,content);
        }
    }
}

