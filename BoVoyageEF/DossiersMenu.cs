using System;
using System.Collections.Generic;
using  BoVoyageMetier.Entities;
using BoVoyage.Framework.UI;
using BoVoyageMetier.DAL;

namespace BoVoyageEF
{
    public class DossiersMenu : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageDossiers =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<DossierReservation>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<DossierReservation>(x=>x.NumeroUnique, "No Unique", 4),
                InformationAffichage.Creer<DossierReservation>(x=>x.EtatDossier, "Etat", 10),
                InformationAffichage.Creer<DossierReservation>(x=>x.NumeroCarteBancaire, "Prenom", 10),
               // InformationAffichage.Creer<DossierReservation>(x=>x.AnnulationAssurance, "Assurance", 10),
                InformationAffichage.Creer<DossierReservation>(x=>x.ClientId, "ID Client", 15),
                InformationAffichage.Creer<DossierReservation>(x=>x.VoyageId, "Id Voyage", 15)
            };


        public DossiersMenu(Application application, string nomModule)
            : base(application, nomModule)
        {
            //this.liste = new DossierData().GetList();
        }

        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Liste des Dossiers")
            {
                FonctionAExecuter = this.Afficher
            });
            menu.AjouterElement(new ElementMenu("2", "Enregistrer un Nouveau Dossier")
            {
                FonctionAExecuter = this.NouveauDossier
            });
            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void AfficherDossier()
        {
            ConsoleHelper.AfficherEntete("Liste des Dossiers");

            ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);
        }

        private void NouveauDossier()
        {
            ConsoleHelper.AfficherEntete("Nouveau Dossier");

            var dossierVoyage = new DossierReservation
            {
                //Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
                //Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom ?"),
                //Email = ConsoleSaisie.SaisirChaineOptionnelle("Email ?"),
                //DateNaissance = ConsoleSaisie.SaisirDateOptionnelle("Date d'inscription ?")
            };

           // this.liste.Add(client);
        }
    }
}
