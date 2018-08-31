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
            var dossierData = new DossierData();
            dossierData.Ajouter(dossierReservation);
            return dossierReservation;
        }

        public DossierReservation ValiderSolvabilite(int dossierReservationId)
        {
            var dossierReservation = new DossierData().GetById(dossierReservationId);
            if (dossierReservation != null &&
                dossierReservation.EtatDossierReservation == EtatDossierReservation.EnAttente)
            {
                var carteBancaireServie = new CarteBancaireService();
                if (carteBancaireServie.ValiderSolvabilite(dossierReservation.NumeroCarteBancaire,
                    dossierReservation.PrixTotal))
                {
                    dossierReservation.EtatDossierReservation = EtatDossierReservation.EnCours;
                    new DossierData().Update(dossierReservation);
                }

            }
            return dossierReservation;
        }

        public DossierReservation Accepter(int dossierReservationId)
        {
            var dossierReservation = new DossierData().GetById(dossierReservationId);
            if (dossierReservation != null &&
                dossierReservation.EtatDossierReservation == EtatDossierReservation.EnAttente)
            {
                var carteBancaireServie = new CarteBancaireService();
                if (carteBancaireServie.ValiderSolvabilite(dossierReservation.NumeroCarteBancaire,
                    dossierReservation.PrixTotal))
                {
                    dossierReservation.EtatDossierReservation = EtatDossierReservation.EnCours;
                }
            }
            return dossierReservation;
        }
    }
}
