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
            return new BoVoyage().Destinations.ToList();
           // return new List<Destination>();
        }

		public Destination Ajout(Destination destination)
		{
			using (var contexte = new BoVoyage())
			{
				contexte.Destinations.Add(destination);
				contexte.SaveChanges();
			}
				return destination;
			
		}
    }
}
