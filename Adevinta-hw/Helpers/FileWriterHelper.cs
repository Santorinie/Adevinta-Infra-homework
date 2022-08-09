﻿using System;
namespace Adevinta_hw.Helpers
{
    public class FileWriterHelper
    {
        private string Path { get; set; }

        public FileWriterHelper(string filePath)
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

