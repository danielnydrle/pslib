using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV4.Models
{
	internal class Smerovac
	{
		private static Smerovac? instance = null;

		public List<OdberVysilani> RegistrovaneOdbery = new List<OdberVysilani>();

		public List<Zprava> FrontaVysilani = new List<Zprava>();
		private Smerovac() { }

		public static Smerovac Instance
		{
			get
			{
				if (instance == null)
					instance = new Smerovac();
				return instance;
			}
		}

		public static void PridejZpravuDoFronty(Zprava zprava)
		{
			Zprava? aktualniZpravaVysilace = ZiskejVysilaniVysilace(zprava.VysilacId, zprava.TypVysilani);
			if (aktualniZpravaVysilace != null)
				Instance.FrontaVysilani.Remove((Zprava)aktualniZpravaVysilace);
			Instance.FrontaVysilani.Add(zprava);
		}

		public static Zprava? ZiskejVysilaniVysilace(string vysilacId, string typVysilani)
		{
			return Instance.FrontaVysilani.Any(z => z.VysilacId == vysilacId && z.TypVysilani == typVysilani)
				? Instance.FrontaVysilani.First(z => z.VysilacId == vysilacId && z.TypVysilani == typVysilani)
				: null;
		}

		public static void ZaregistrujPrijimacKOdberu(Guid prijimacId, string vysilacId, string typVysilani)
		{
			OdberVysilani novyOdber = new OdberVysilani(prijimacId, vysilacId, typVysilani);
			if (!Instance.RegistrovaneOdbery.Any(x => x.PrijimacId == prijimacId))
				Instance.RegistrovaneOdbery.Add(novyOdber);
			int odberIndex = Instance.RegistrovaneOdbery.FindIndex(x => x.PrijimacId == prijimacId);
			Instance.RegistrovaneOdbery[odberIndex] = novyOdber;
		}

		public static Zprava? ZiskejOdebiraneVysilaniPrijimace(Guid prijimacId)
		{
			if (prijimacId == Guid.Empty)
				return null;
			OdberVysilani odber = Instance.RegistrovaneOdbery.Find(x => x.PrijimacId == prijimacId);
			return ZiskejVysilaniVysilace(odber.VysilacId, odber.TypVysilani);
		}

		public static void OdeberVysilaniZFronty(string vysilacId, string typVysilani)
		{
			Zprava vysilani = Instance.FrontaVysilani.FirstOrDefault(x => x.VysilacId == vysilacId && x.TypVysilani == typVysilani);
			if (Instance.FrontaVysilani.Any(x => x.VysilacId == vysilacId && x.TypVysilani == typVysilani))
				Instance.FrontaVysilani.Remove(vysilani);
		}
		
		public static void OdeberPrijimacZOdberu(Guid prijimacId, string vysilacId, string typVysilani)
		{
			OdberVysilani odber = new OdberVysilani(prijimacId, vysilacId, typVysilani);
			if (Instance.RegistrovaneOdbery.Any(x => x.Equals(odber)))
				Instance.RegistrovaneOdbery.Remove(odber);
		}
		internal struct OdberVysilani
		{
			public Guid PrijimacId { get; set; }
			public string VysilacId { get; set; }
			public string TypVysilani { get; set; }

			public OdberVysilani(Guid prijimacId, string vysilacId, string typVysilani)
			{
				PrijimacId = prijimacId;
				VysilacId = vysilacId;
				TypVysilani = typVysilani;
			}
		}
	}
}
