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
                    new VoyageService().Reserver(voyage, dossierReservation.Participants.Count);
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


        public DossierReservation Cloturer(int dossierReservationId)
        {
            var dossierReservation = new DossierData().GetById(dossierReservationId);
            if (dossierReservation != null &&
                dossierReservation.EtatDossierReservation == EtatDossierReservation.Accepte
                && DateTime.Now <= new VoyageData().GetById(dossierReservation.VoyageId).DateAller)
            {
                dossierReservation.EtatDossierReservation = EtatDossierReservation.Clos;
                new DossierData().Update(dossierReservation);

                new CarteBancaireService().PayerAgence(dossierReservation.PrixParPersonne * 0.9m);
            }
            return dossierReservation;
        }


        public bool Annuler(int dossierReservationId, RaisonAnnulationDossier raisonAnnulationDossier)
        {
            bool succes = false;
            var dossierReservation = new DossierData().GetById(dossierReservationId);

            if (dossierReservation != null
                && dossierReservation.RaisonAnnulationDossier == 0
                && dossierReservation.EtatDossierReservation != EtatDossierReservation.Refuse
                && raisonAnnulationDossier == RaisonAnnulationDossier.Client)
            {
                dossierReservation.EtatDossierReservation = EtatDossierReservation.Annule;
                dossierReservation.RaisonAnnulationDossier = RaisonAnnulationDossier.Client;
                if (dossierReservation.Assurances.Where(x => x.TypeAssurance == TypeAssurance.Annulation).Count() > 0)
                {
                    var rembourser = new CarteBancaireService().Rembourser(dossierReservation.NumeroCarteBancaire,
                        dossierReservation.PrixTotal);
                }
                new DossierData().Update(dossierReservation);
                succes = true;
            }

            if (dossierReservation != null
                && dossierReservation.RaisonAnnulationDossier == raisonAnnulationDossier
                && dossierReservation.EtatDossierReservation == EtatDossierReservation.Refuse )
            {
                dossierReservation.EtatDossierReservation = EtatDossierReservation.Annule;             
         
                new DossierData().Update(dossierReservation);
                succes = true;
            }


            return succes;
        }
    }
}
