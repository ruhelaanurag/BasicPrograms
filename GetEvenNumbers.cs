using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		Program prog = new Program();
		foreach (var even in prog.GetEvenNumbers(10000000))
		{
			Console.WriteLine(even);
		}
		foreach (var even in prog.GetEvenList(10000000))
		{
			Console.WriteLine(even);
		}
		
	}

	public List<int> GetEvenList(int numbersTill)
	{
		var lstEvenNumbers = new List<int>();
		for (int i = 0; i <= numbersTill; i = i + 2)
		{
			lstEvenNumbers.Add(i);
		}

		return lstEvenNumbers;
	}

	public IEnumerable<int> GetEvenNumbers(int numbersTill)
	{
		for (int i = 0; i <= numbersTill; i = i + 2)
		{
			yield return i;
		}
	}
}
