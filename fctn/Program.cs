using System;

namespace fctn
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckArguments(args);
            
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