using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV4.Models
{
	internal class Vysilac
	{
		public string Id { get; set; }
		private static List<Vysilac> Vysilace = new List<Vysilac>();
		private static List<string> TypyVysilani = new List<string>() { "ZABAVA", "ZPRAVY", "SPORT", "FILMY" };
		private static List<string> PrijimanaVysilani = new List<string>() { };

		private Vysilac(string id)
		{
			Id = id;
		}

		public static Vysilac Instance(string id)
		{
			Vysilac instance = Vysilace.FirstOrDefault(x => x.Id == id);
			if (instance == null)
			{
				instance = new Vysilac(id);
				Vysilace.Add(instance);
			}
			return instance;
		}

		private Zprava VytvorZpravu(string typVysilani, string data)
		{
			if (!TypyVysilani.Contains(typVysilani))
				TypyVysilani.Add(typVysilani);
			return new Zprava(Id, typVysilani, data);
		}

		public void ZastavVysilani(string typVysilani)
		{
			Smerovac.OdeberVysilaniZFronty(Id, typVysilani);
		}

		public void PosliZpravu(string typVysilani, string data)
		{
			Smerovac.PridejZpravuDoFronty(VytvorZpravu(typVysilani, data));
		}
	}
}
