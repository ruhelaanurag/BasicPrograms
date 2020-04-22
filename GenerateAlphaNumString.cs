using System;
using System.Linq;

public class Program
{
	public static void Main()
	{
		Random ran = new Random();
		String b = "abcdefghijklmnopqrstuvwxyz0123456789";
		//String sc = "!@#$%^&*~";
		int length = 32;
		String random = "";
		for (int i = 0; i < length; i++)
		{
			int a = ran.Next(b.Length); //string.Lenght gets the size of string
			random = random + b.ElementAt(a);
		}

		//for (int j = 0; j < 2; j++)
		//{
		//	int sz = ran.Next(sc.Length);
		//	random = random + sc.ElementAt(sz);
		//}

		Console.WriteLine("The random alphabet generated is: {0}", random);
		Console.ReadLine();
	}
}
