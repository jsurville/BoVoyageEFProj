using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;
using BoVoyageMetier.DAL;

namespace BoVoyageMetier.Services
{
    public class DossierReservationService
    {
		public DossierReservation Ajout(DossierReservation dossierReservation)
		{
            return dossierReservation;
		}

        public DossierReservation ValiderSolvabilite (int dossierReservationId)
        {
            var dossierReservation = new DossierData().GetById(dossierReservationId);
            return dossierReservation;
        }
    }
}
