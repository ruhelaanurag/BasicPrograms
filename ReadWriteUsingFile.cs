using System.IO;
using System;
namespace ConsoleApp
{
    class ReadWriteUsingFile
    {
        static void Main(string[] args)
        {
            TextReader textReader = new StreamReader(@"E:\input.txt");
            TextWriter textWriter = new StreamWriter(@"E:\output.txt", true);
            
            int t = Convert.ToInt32(Console.ReadLine());//Expecting first line to be an Integer.

            for (int tItr = 0; tItr < t; tItr++)
            {
                string s = textReader.ReadLine();
                textWriter.WriteLine(s);
            }

            textWriter.Flush();
            textWriter.Close();
            Console.ReadLine();
        }
    }
}
