using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV2.Models
{
	internal class Robot
	{
		private Modul? Modul;
		private Dictionary<string, int> Zaznamy = new Dictionary<string, int>();

		public bool ProvedCinnost(Povel povel)
		{
			try
			{
				OdeberModul();
				Modul = Modul.Instance(povel.Modul);
				Modul.Pracuj(povel.Cas);
				if (Zaznamy.ContainsKey(Modul.Nazev))
				{
					Zaznamy[Modul.Nazev] += povel.Cas;
				}
				else
				{
					Zaznamy.Add(Modul.Nazev, povel.Cas);
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void VypisCinnosti()
		{
			Console.Write("\n");
			Console.WriteLine("Zaznam cinnosti:");
			Console.WriteLine("/-");
			foreach(var zaznam in Zaznamy)
			{
				Console.WriteLine($"{zaznam.Key}: {zaznam.Value}");
			}
			Console.Write("-/\n\n");
		}

		public bool OdeberModul()
		{
			if (Modul != null)
				Modul = null;
			return true;
		}
	}
}
