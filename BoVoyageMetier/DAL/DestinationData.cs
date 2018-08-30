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
