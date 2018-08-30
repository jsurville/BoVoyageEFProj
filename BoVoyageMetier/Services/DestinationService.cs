using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;
using BoVoyageMetier.DAL;

namespace BoVoyageMetier.Services
{
	public class DestinationService
	{
		public Destination Ajout(Destination destination)
		{
			var dest = new DestinationData();
			dest.Ajout(destination);
			return destination;
		}
	}
}
