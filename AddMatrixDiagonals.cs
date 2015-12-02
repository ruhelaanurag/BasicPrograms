using System;
					
public class Program
{
	public static void Main()
	{
		int i,j=1;
		int n =3;
		
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
