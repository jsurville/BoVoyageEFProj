using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;

namespace BoVoyageMetier.DAL
{
	public class DestinationData
	{
		public List<Destination> GetList()
		{
			using (var contexte = new BoVoyage())
			{
				return contexte.Destinations.ToList();
			}
		}

		public Destination GetById(int destinationId)
		{
			try
			{
				using (var contexte = new BoVoyage())
				{
					return contexte.Destinations.Single(x => x.Id == destinationId);
				}
			}
			catch
			{
				return null;
			}

		}

		public Destination Ajout(Destination destination)
		{
			try
			{
				using (var contexte = new BoVoyage())
				{
					contexte.Destinations.Add(destination);
					contexte.SaveChanges();
				}
				return destination;
			}
			catch
			{
				return null;
			}
		}
	}
}
