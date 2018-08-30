using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;

namespace BoVoyageMetier.DAL
{
    public class VoyageData
    {
        public List<Voyage> GetList()
        {
            return new BoVoyage().Voyages.ToList();
            //return new List<Voyage>();
        }
    }
}
