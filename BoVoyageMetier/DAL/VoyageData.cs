using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;
using System.Data.Entity;

namespace BoVoyageMetier.DAL
{
	public class VoyageData
	{
		public List<Voyage> GetList()
		{
			return new BoVoyage().Voyages.Include("Destination").ToList();
			//return new List<Voyage>();
		}

		public Voyage Ajout(Voyage voyage)
		{
			using (var contexte = new BoVoyage())
			{
				contexte.Voyages.Add(voyage);
				contexte.SaveChanges();
			}
			return voyage;
		}

		public Voyage GetById(int voyageId)
		{
			try
			{
				using (var contexte = new BoVoyage())
				{
					return contexte.Voyages.Single(x => x.Id == voyageId);

				}
   				
			}
			catch
			{
				return null;
			}
		}

		public bool Effacer(Voyage voyage)
		{
			using (var contexte = new BoVoyage())
			{
				contexte.Voyages.Attach(voyage);
				contexte.Voyages.Remove(voyage);
				contexte.SaveChanges();
				
			}
			return true;
		}

	}
}
