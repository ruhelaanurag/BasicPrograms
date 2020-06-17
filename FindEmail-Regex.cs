using System;
using System.Text.RegularExpressions;

					
public class Program
{
	public static void Main()
	{
		var conteudo = @"DC=com, DC=someorg, O=internal, OU=people, ABC.0.7.1818.12340990.100.1.1=somrandom.hello@someorg.com, CN=Some random hello 1761722";
		var pattern = @"([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+)";
		
		Regex r = new Regex(pattern, RegexOptions.IgnoreCase);		
		
		Match m = r.Match(conteudo);
		if (m.Success) 
		{
			Console.WriteLine(m.Groups[1]);
		}
		//var last = conteudo.LastIndexOf(' ');
		//Console.WriteLine(conteudo.Substring(last+1));
	}
}
