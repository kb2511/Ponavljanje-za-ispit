using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak7_Delegat
{
	[Serializable]
	public class Osoba
	{
		public string Ime { get; set; }
		public void Pozdravi()
		{
			Console.WriteLine($"Pozdrav {Ime}!");
		}
	}
}
