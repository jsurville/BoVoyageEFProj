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
			if (voyage.DateAller > DateTime.Now.AddDays(3) && voyage.DateRetour> voyage.DateAller.AddDays(2)&& 
				new DestinationData().GetById(voyage.DestinationId)!=null)
			{
				voyageData.Ajout(voyage);
			}


			return voyage;
		}

		public bool Supprimer(int voyageId)
		{
			var voyageData = new VoyageData();
			var voyage = voyageData.GetById(voyageId);
			return voyageData.Effacer(voyage);
			
			
		}
	}
}
