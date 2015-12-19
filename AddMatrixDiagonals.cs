using System;
					
public class Program
{
	public static void Main()
	{
		int i=1,j=1;
		int n =3;
		
		FindDiagonal(i,j,n);
	}
	
	public static void FillMatrix()
	{
		Console.WriteLine("Enter n for creating n*n matrix");
		var n = Console.ReadLine();
		
	}
	
	public static void FindDiagonal(int i, int j, int n)
	{
	Console.WriteLine("Primary diagonal");
		for(i=1; i<=n; i++) //calculate primary
		{
			for(j=1;j<=i;j++)
			{
				if(i == j)
				Console.WriteLine(i+","+j);
			}
		}
		
		
		
		Console.WriteLine("\n\nSecondary diagonal");
		j=1;
		for(i=n; i>=1; i--) //calculate secondary
		{
			Console.WriteLine(i+","+j);
			j++;
		}
	}
}
