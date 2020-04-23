using System;
using Newtonsoft.Json;

public class Program
{
	public static void Main()
	{
		var e = new Employee() {Name = "John Doe", Salary = 1230};
		Console.WriteLine(e.ToString());
	}

	class Employee
	{
		public string Name { get; set; }
		public int Salary { get; set; }

		public override string ToString()
		{
			var obj = JsonConvert.SerializeObject(this);
			//return $"{this.Name} {this.Salary}";
			return obj;
		}
	}
}
