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
            var directory = (args.Length == 1) ? "." : args[0];
            var pattern = (args.Length == 1) ?  args[0] : args[1];
            var files = GetFiles(directory);
            var filesContainingString = GetFilesContaining(pattern, files);
            PrintEachFile(filesContainingString);
        }

        /**
         * Prints the relative path of each file in the parameterized array.
         */
        private static void PrintEachFile(IEnumerable<string> filesContainingString)
        {
            foreach (var file in filesContainingString)
            {
                Console.WriteLine(file);
            }
        }

        /**
         * Gets files containing the goven pattern.
         */
        private static string[] GetFilesContaining(string pattern, IEnumerable<string> files)
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
            var files = new List<string>();
            var directories = new List<string> {directory};

            while (directories.Count != 0)
            {
                var dir = directories[0];
                directories.RemoveAt(0);

                files.AddRange(Directory.GetFiles(dir));
                directories.AddRange(Directory.GetDirectories(dir));
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
                string usageMessage = "Usage: " + System.AppDomain.CurrentDomain.FriendlyName +
                                      " /path/to/directory string_to_find";
                Console.WriteLine(usageMessage);
                Environment.Exit(1);
            }
        }
    }
}