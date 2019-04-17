using System;
using System.Collections.Generic;
using System.IO;

namespace fctn
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckArguments(args);
            string directory = args[0];
            string pattern = args[1];
            string[] files = GetFiles(directory);
            string[] filesContainingString = GetFilesContaining(pattern, files);
            PrintEachFile(filesContainingString);
        }

        /**
         * Prints the relative path of each file in the parameterized array.
         */
        private static void PrintEachFile(string[] filesContainingString)
        {
            foreach (var file in filesContainingString)
            {
                Console.WriteLine(file);
            }
        }

        /**
         * Gets files containing the goven pattern.
         */
        private static string[] GetFilesContaining(string pattern, string[] files)
        {
            List<string> list = new List<string>();
            
            foreach (var file in files)
            {
                string text = File.ReadAllText(file);
                if (text.Contains(pattern))
                {
                    list.Add(file);
                }
            }

            return list.ToArray();
        }

        /**
         * Recursively gets all files from the given directory.
         */
        private static string[] GetFiles(string directory)
        {
            List<string> files = new List<string>();
            List<string> directories = new List<string>();
            directories.Add(directory);

            while (directories.Count != 0)
            {
                string dir = directories[0];
                directories.RemoveAt(0);
                
                foreach (var file in Directory.GetFiles(dir))
                {
                    files.Add(file);
                }
                
                foreach (var subdir in Directory.GetDirectories(dir))
                {
                    directories.Add(subdir);
                }
                
            }
            
            
            return files.ToArray();
        }


        /**
         * Determines if enough arguments have been provided to the program.
         * If no arguments have been provided then the program will exit.
         */
        private static void CheckArguments(string[] args)
        {
            if (args.Length < 1)
            {
                string usageMessage = "Usage: " + System.AppDomain.CurrentDomain.FriendlyName + " /path/to/directory string_to_find";
                Console.WriteLine(usageMessage);
                Environment.Exit(1);
            }
        }
    }
}