using System;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace lab3_z2
{
    public class Program
    {


        public static string WordSearch(string TextOut, string[] sentences, string KeyWord)
        {
 
            bool containsWord = false;
            using (StreamWriter fileWriter = new StreamWriter("E:\\repository\\lab3_z2\\output.txt"))
            {
                foreach (string sentence in sentences)
                {
                    // Convert both keyword and sentence to lowercase before comparing them
                    if (sentence.ToLower().Contains(KeyWord.ToLower()))
                    {
                        containsWord = true;
                        fileWriter.Write(sentence);
                    }
                }
            }
            if (!containsWord)
            {
                return "Keyword not found.";
            }
            return "Search complete.";
        }



        static void Main(string[] args)
        {
            
            StreamReader FileRead = new StreamReader("E:\\repository\\lab3_z2\\input.txt");
            string TextOut = FileRead.ReadToEnd();
            Console.WriteLine("text = " + TextOut);
            string[] sentences = TextOut.Split(new string[] { ".", "!", "?" }, StringSplitOptions.None);

            while (true)
            {


                Console.WriteLine("Введіть слово для пошуку: ");
                string KeyWord = Console.ReadLine();


                if (WordSearch(TextOut, sentences, KeyWord) == "Search complete.")
                {
                    Console.WriteLine("Keyword found.");
                    WordSearch(TextOut, sentences, KeyWord);
                    break;
                }
                else
                {
                    Console.WriteLine("Keyword not found. Please try again.");
                }
            }
        }


    }
}