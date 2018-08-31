using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyageMetier.Services
{
    class CarteBancaireService
    {
        public bool ValiderSolvabilite(string numeroCarteBancaire, int prixTotal)
        {
            try
            {
                return ((int.Parse(numeroCarteBancaire) - prixTotal) % 2) == 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
