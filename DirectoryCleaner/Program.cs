using System;
using System.IO;

namespace DirectoryCleaner
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
             *  try
             {
                 Console.WriteLine("Please input a directory to check:");
                 string userInput = Console.ReadLine();
                 string[] dirs = Directory.GetFiles(userInput); 
                 //string[] dirs = Directory.GetFiles(userInput, "c*");
                 Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
                 foreach (string dir in dirs)
                 {
                     DateTime lastAccessTime = Directory.GetLastAccessTime(dir);
                     long fileSize = dir.Length;
                     Console.WriteLine("File: " + dir + ", Last Access Time: " + lastAccessTime + ", File Size: " + fileSize);
                 }
             }
             catch (Exception e)
             {
                 Console.WriteLine("The process failed: {0}", e.ToString());
             }
             Console.WriteLine("------------\n");
             */
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
//                Console.WriteLine("\tFile in: " + currentDir + " is: " + file);
                Console.WriteLine("\tFile located: "  + file);
            }
        }
    }
}
