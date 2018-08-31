using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyageMetier.Services
{
    class CarteBancaireService
    {
        public bool ValiderSolvabilite(string numeroCarteBancaire, decimal prixTotal)
        {
            try
            {
                return ((int.Parse(numeroCarteBancaire) -(int) prixTotal) % 2) == 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
