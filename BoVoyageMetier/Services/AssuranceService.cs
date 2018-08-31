using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;
using BoVoyageMetier.DAL;

namespace BoVoyageMetier.Services
{
	public class AssuranceService
	{
		public bool Ajout(int assuranceId, int dossierReservationId)
		{
			return new AssuranceData().Ajout(assuranceId, dossierReservationId);
		}

	}
}
