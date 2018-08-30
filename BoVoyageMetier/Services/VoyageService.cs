using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.DAL;
using BoVoyageMetier.Entities;

namespace BoVoyageMetier.Services
{
	public class VoyageService
	{
		public Voyage Ajout(Voyage voyage)
		{
			var voyageData = new VoyageData();
			voyageData.Ajout(voyage);
			return voyage;
		}

		public bool Supprimer(int voyageId)
		{
			return true;
		}
	}
}
