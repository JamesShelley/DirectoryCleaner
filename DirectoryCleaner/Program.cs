using System;
using System.IO;

namespace DirectoryCleaner
{
    class Program
    {


        public static void Main(string[] args)
        {
            int largestWidth = Console.LargestWindowWidth - 50;
            int largestHeight = Console.LargestWindowHeight - 10;

            Console.SetWindowSize(largestWidth, largestHeight);
            Console.WriteLine("Please input a directory to check:");
            string userInput = Console.ReadLine();
            GetSubDirectories(userInput);
            Console.ReadLine();
        }

        public static void GetSubDirectories(string Path)

        {
            Console.WriteLine("Directory: " + Path);
            getFilesInDirectory(Path);
            string[] subdirectoryEntries = Directory.GetDirectories(Path);
            foreach (string subdirectory in subdirectoryEntries)
            {
                LoadSubDirs(subdirectory);
            }
        }
        private static void LoadSubDirs(string dir)

        {
            Console.WriteLine("Directory: " + dir);
            getFilesInDirectory(dir);
            string[] subdirectoryEntries = Directory.GetDirectories(dir);

            foreach (string subdirectory in subdirectoryEntries)
            {
                LoadSubDirs(subdirectory);
            }
        }

        private static void getFilesInDirectory(string currentDir)
        {
            string[] filesInDir = Directory.GetFiles(currentDir);
            foreach(string file in filesInDir)
            {
                Console.WriteLine("\tFile located: "  + file + ", Length in Bytes: " + file.Length);
            }
        }
    }
}
