using System;
using System.IO;
using System.Text;

namespace DirectoryCleaner
{
    class Program
    {

        public static string outputFileDirectory = @"C:\Temp\FileCleaner\cleaner-result.txt";

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
            createFileLocation();

            Console.WriteLine("Original directory: " + Path);
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
            foreach (string file in filesInDir)
            {
                Console.WriteLine("\tFile located: " + file + ", Length in Bytes: " + file.Length);
                try { 
                using (System.IO.StreamWriter addToFile = new System.IO.StreamWriter(outputFileDirectory, true))
                {
                    addToFile.WriteLine("\tFile located: " + file + ", Length in Bytes: " + file.Length);
                }
            }catch (System.IO.IOException e) {
                    Console.WriteLine("Error: the output file might be in use by another program?");

               }
            }
        }

        private static void createFileLocation()
        {

            string path = @"C:\temp\FileCleaner";

            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    // Create the file, or overwrite if the file exists.
                    File.Create(outputFileDirectory);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

       

        }
    }
}
