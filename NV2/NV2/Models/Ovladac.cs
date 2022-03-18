using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV2.Models
{
	static class Ovladac //utility
	{
		public static void PredejPovel(Robot robot, Povel povel)
		{
			robot.ProvedCinnost(povel);
		}
	}
}
