using Microsoft.Extensions.CommandLineUtils;
using Pangramm.Models;
using System;
using System.Collections.Generic;

namespace Pangramm
{
    class Program
    {
        /// <summary>
        /// 1,5 h
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            try
            {
                parseArgs(args, out string input);

                PangrammChecker checker = new PangrammChecker(input);
                if (checker.containsAllAlphabetLettersMoreThanOnce)
                {
                    Console.WriteLine($"\"{input}\" contains all alphabet letters more than once");
                }
                if (checker.containsAllLettersExactlyOnce)
                {
                    Console.WriteLine($"\"{input}\" contains all alphabet letters exactly once");
                }
                if(checker.doesNotContainAllAlphabetLettersOnce)
                {
                    Console.WriteLine($"\"{input}\" does not contain all alphabet letters at least once");
                }

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Die Eingabeparameter hatten das falsche Format");
            }
        }

        public static void parseArgs(string[] args, out string input)
        {
            input = "";
            if (args.Length == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (args[i].ToLower() == "-input")
                    {
                        input = args[i + 1];
                    }

                }
            }
            else
            {
                Console.WriteLine("Not enought Options given");
            }
        }
    }
}
