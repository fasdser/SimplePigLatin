using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimplePigLatin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PigIt("Pig latin is cool"));
            Console.ReadKey();
        }


        public static string PigIt(string str)
        {
            string ay = "ay";
            string result = "";
            string[] arrayStr = str.Split(' ');
            for (int i = 0; i < arrayStr.Length; i++)
            {
                result += arrayStr[i].Remove(0, 1);
                if (Char.IsLetter(arrayStr[i].First()))
                {
                    result += arrayStr[i].First() + ay + " ";
                }

                if (!Char.IsLetter(arrayStr[i].First()))
                {
                    result += arrayStr[i].First() + " ";
                }

            }


            return result.Remove(result.Length - 1);
        }

        public static string PigIt1(string str)
        {
            return string.Join(" ", str.Split(' ').Select(w => w.Any(char.IsPunctuation) ? w : w.Substring(1) + w[0] + "ay"));
        }

        public static string PigIt2(string str)
        {
            return Regex.Replace(str, @"((\S)(\S+))", "$3$2ay");
        }
    }

    public class Kata
    {
        public static string PigIt(string str) => Regex.Replace(str, @"\w+", word => word.Value.MoveFirstLetter().AddAy());
    }

    static class WordExtensions
    {
        public static string AddAy(this string word)
        {
            return word + "ay";
        }

        public static string MoveFirstLetter(this string word)
        {
            return new string(word.Skip(1).Concat(word.Take(1)).ToArray());
        }
    }
}
