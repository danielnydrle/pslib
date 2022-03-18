using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV4.Models
{
	public readonly struct Zprava
	{
		public string VysilacId { get; }
		public string TypVysilani { get; }
		public string Data { get; }

		public Zprava(string vysilacId, string typVysilani, string data)
		{
			VysilacId = vysilacId;
			TypVysilani = typVysilani;
			Data = data;
		}

		public override string ToString()
		{
			return $"Vysilani {TypVysilani} z vysilace {VysilacId}: {Data}";
		}
	}
}
