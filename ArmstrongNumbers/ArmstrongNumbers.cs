using System;
using System.IO;

namespace ArmstrongNumbers
{
    class ArmstrongNumbers
    {
        static int Main(string[] args)
        {
            // Check the argument and file exists
            if (args.Length == 0 || !File.Exists(args[0]))
            {
                Console.Write("You failed to specify the file to read, or entered a non existant file path.\nPlease try again with the file name as the first argument.");
                return 0;
            }

            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (null == line) continue;

                    if ("" == line) continue;

                    PrintArmstrongNumber(line);
                }
            }

            return 0;
        }

        /// <summary>
        /// An Armstrong number is an n-digit number that is equal to the sum of the n'th powers of its digits. Determine if the input numbers are Armstrong numbers. 
        /// ie.
        /// 6    = 6^n, n = 1                   true
        /// 153  = 1^n + 5^n + 3^n, n = 3       true
        /// 351  = 3^n + 5^n + 1^n, n = 3       false
        /// </summary>
        /// <param name="sumOfParts"></param>
        static void PrintArmstrongNumber(string splitNum)
        {
            int num;
            int sumOfParts = 0;
            int convertedNum = Convert.ToInt32(splitNum);

            for (int index = 0; index < splitNum.Length; ++index)
            {
                num = Convert.ToInt32(splitNum.Substring(index, 1));
                sumOfParts += Convert.ToInt32(Math.Pow(num, splitNum.Length));
            }

            Console.WriteLine((sumOfParts == convertedNum ? "True" : "False"));
        }
    }
}
