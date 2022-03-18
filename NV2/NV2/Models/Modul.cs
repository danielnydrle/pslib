using NV2.Models.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV2.Models
{
	abstract class Modul //servant
	{
		public abstract string Nazev { get; }
		public int Cas { get; set; }

		public enum ModulType
		{
			Brouseni,
			Rezani,
			Svarovani,
			Vrtani
		}

		public static Modul Instance(ModulType cinnost) //factory method
		{
			return cinnost switch
			{
				ModulType.Brouseni => new Brouseni(),
				ModulType.Rezani => new Rezani(),
				ModulType.Svarovani => new Svarovani(),
				ModulType.Vrtani => new Vrtani(),
			};
		}

		public bool Pracuj(int cas)
		{
			if (cas > 0)
			{
				VypisPraci();
				Cas += cas;
				return true;
			}
			return false;
		}

		protected virtual void VypisPraci()
		{
			Console.WriteLine("default module");
		}
	}
}
