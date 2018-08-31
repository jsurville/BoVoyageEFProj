using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;
using System.Data.Entity;

namespace BoVoyageMetier.DAL
{
	public class DossierData
	{
		public List<DossierReservation> GetList()
		{
			using (var contexte = new BoVoyage())
			{
				return contexte.DossierReservations.Include("Participants").Include("Voyage").ToList();
			}
		}

		public DossierReservation GetById(int dossierReservationId)
		{
			using (var contexte = new BoVoyage())
			{
				return contexte.DossierReservations.Include("Participants").Single(x => x.Id == dossierReservationId);
			}
		}

		public DossierReservation Ajouter(DossierReservation dossierReservation)
		{
			using (var contexte = new BoVoyage())
			{
				contexte.DossierReservations.Add(dossierReservation);
				contexte.SaveChanges();
			}
			return dossierReservation;
		}

		public DossierReservation Update(DossierReservation dossierReservation)
		{
			using (var contexte = new BoVoyage())
			{
				contexte.DossierReservations.Attach(dossierReservation);
				contexte.Entry(dossierReservation).State = EntityState.Modified;
				contexte.SaveChanges();
			}
			return dossierReservation;
		}

        public bool Delete(DossierReservation dossierReservation)
        {
            try
            {
                using (var contexte = new BoVoyage())
                {
                    contexte.DossierReservations.Attach(dossierReservation);
                    contexte.DossierReservations.Remove(dossierReservation);
                    contexte.SaveChanges();
                    return true;
                }

            }
            catch
            {
                return false;
            }
            
        }
    }
}

