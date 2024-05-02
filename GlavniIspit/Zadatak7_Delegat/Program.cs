using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak7_Delegat
{
	public delegate void IspisDelegat();
	internal class Program
	{
		public static event IspisDelegat PokreniIspis;
		static void Main(string[] args)
		{
			if(PokreniIspis == null)
			{
				Console.WriteLine("Nitko se jos nije pretplatio!");
			}

			Console.WriteLine("-------------------------------------------");

			Osoba osoba = new Osoba()
			{
				Ime = "Ana"
			};

			PokreniIspis += osoba.Pozdravi;

			PokreniIspis?.Invoke();

			//serijalizacija
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream("osoba.txt", FileMode.Create, FileAccess.Write);
			formatter.Serialize(stream, osoba);
			stream.Close();

			//deserijalizacija za provjeru
			stream = new FileStream("osoba.txt", FileMode.Open, FileAccess.Read);
			Osoba osobaNew = (Osoba)formatter.Deserialize(stream);

			Console.WriteLine(osoba.Ime);


			Console.ReadKey();
		}
	}
}
