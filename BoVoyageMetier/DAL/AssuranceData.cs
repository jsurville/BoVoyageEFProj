using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;

namespace BoVoyageMetier.DAL
{
    public class AssuranceData
    {
        //public List<Client> GetList()
        //{
        //    using (var contexte = new BoVoyage())
        //    {
        //        return contexte.Assurances.ToList();
        //    }
            
			
        //}
		public bool Ajout(int assuranceId, int dossierReservationId)
		{

			using (var contexte = new BoVoyage())
			{
				var dossier = contexte.DossierReservations.Single(x=>x.Id==dossierReservationId);
				var assurance = contexte.Assurances.Single(x => x.Id == assuranceId);
				dossier.Assurances.Add(assurance);
				contexte.SaveChanges();
			}
			return true;

		}
	}
}
