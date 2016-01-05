using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace deletedir
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get the current Directory path
            String currPath = Directory.GetCurrentDirectory();

            //if an argument has passed from console pass
            if (args.Length > 0)
            {
                //get path variable from the first argument
                String path = args[0].ToString();


                if (IsFullPath(path) && ( !path.Equals(".") || !path.Equals(@"\") ))
                {
                    path = currPath + @"\" + path;
                }


                if (Directory.Exists(path))
                {
                    DeleteDirectory(path);
                }
                else
                {
                    Console.WriteLine("The provided argument isn't a directory");
                }


            }
            else
            {
                //Give some feedback for how to use the utillity
                Console.WriteLine("You must provide a path to delete");
                Console.WriteLine("Usage: ");
                Console.WriteLine("deletedir [path] ");
                
                Console.WriteLine("\nExample: ");
                Console.WriteLine("deletedir TestFolder ");
            }


        }

        static bool IsFullPath(String path)
        {
            return path.Contains(@":");
        }

        static void DeleteDirectory(String path)
        {
            string[] files = Directory.GetFiles(path);
            string[] directories = Directory.GetDirectories(path);

            //Delete All files inside the targeted directory
            foreach (String file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            //Then Delete All directories inside the targeted directory
            foreach (String directory in directories)
            {
                Directory.Delete(directory);
            }

            //Delete the targeted directory
            Directory.Delete(path);
        }
    }
}
