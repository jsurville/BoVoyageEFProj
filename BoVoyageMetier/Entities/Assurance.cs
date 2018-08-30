using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyageMetier.Entities
{
    public class Assurance
    {
        public decimal Montant { get; set; }
        public TypeAssurance TypeAssurance { get; set; }
    }
    public enum TypeAssurance { Annulation = 1}
}
