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
                /*else
                {
                    dossierReservation.EtatDossierReservation = EtatDossierReservation.Refuse;
                    dossierReservation.RaisonAnnulationDossier = RaisonAnnulationDossier.PaiementRefuse;
                    new DossierData().Update(dossierReservation);
                }*/


            }
            return dossierReservation;
        }

        public DossierReservation Accepter(int dossierReservationId)
        {
            var dossierReservation = new DossierData().GetById(dossierReservationId);
            if (dossierReservation != null &&
                dossierReservation.EtatDossierReservation == EtatDossierReservation.EnCours)
            {
                var voyage = new VoyageData().GetById(dossierReservation.VoyageId);
                if (voyage.PlacesDisponibles >= dossierReservation.Participants.Count)
                {
                    dossierReservation.EtatDossierReservation = EtatDossierReservation.Accepte;
                    new DossierData().Update(dossierReservation);
                    voyage.PlacesDisponibles -= dossierReservation.Participants.Count;
                    new VoyageData().Update(voyage);
                }
                else
                {
                    dossierReservation.EtatDossierReservation = EtatDossierReservation.Refuse;
                    dossierReservation.RaisonAnnulationDossier = RaisonAnnulationDossier.PlacesInsuffisantes;
                    new DossierData().Update(dossierReservation);
                }
            }
            return dossierReservation;
        }

        public bool Annuler(int dossierReservationId, RaisonAnnulationDossier raisonAnnulationDossier)
        {
            var dossierReservation = new DossierData().GetById(dossierReservationId);
            if (dossierReservation != null 
                && dossierReservation.RaisonAnnulationDossier==RaisonAnnulationDossier.Client
                && dossierReservation.EtatDossierReservation== EtatDossierReservation.EnAttente)

            {
                dossierReservation.EtatDossierReservation = EtatDossierReservation.Clos;
                new DossierData().Update(dossierReservation);
                return true; 
            }
            else
                return false;
        }
    }
}
