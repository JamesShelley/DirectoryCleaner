using System;
using System.IO;

namespace DirectoryCleaner
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Only get files that begin with the letter "c".
                string[] dirs = Directory.GetFiles(@"c:\users\james\Desktop", "d*");
                Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
                foreach (string dir in dirs)
                {
                    DateTime dt = Directory.GetLastAccessTime(dir);
                    Console.WriteLine("File: " + dir + ", Last Access Time: " + dt);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            Console.ReadLine();
        }

    }
}
