using System;
using System.Collections.Generic;
using  BoVoyageMetier.Entities;
using BoVoyage.Framework.UI;

namespace BoVoyageEF
{
    public class DossiersMenu : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageDossiers =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<DossierVoyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<DossierVoyage>(x=>x.NumeroUnique, "No Unique", 4),
                InformationAffichage.Creer<DossierVoyage>(x=>x.EtatDossier, "Etat", 10),
                InformationAffichage.Creer<DossierVoyage>(x=>x.NumeroCarteBancaire, "Prenom", 10),
                InformationAffichage.Creer<DossierVoyage>(x=>x.AnnulationAssurance, "Assurance", 10),
                InformationAffichage.Creer<DossierVoyage>(x=>x.ClientId, "ID Client", 15),
                InformationAffichage.Creer<DossierVoyage>(x=>x.VoyageId, "Id Voyage", 15)
            };


        public DossiersMenu(Application application, string nomModule)
            : base(application, nomModule)
        {
            //this.liste = new DossierData().GetList();
        }

        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Afficher")
            {
                FonctionAExecuter = this.Afficher
            });
            menu.AjouterElement(new ElementMenu("2", "Nouveau")
            {
                FonctionAExecuter = this.Nouveau
            });
            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void AfficherDossier()
        {
            ConsoleHelper.AfficherEntete("Afficher Dossiers");

           // ConsoleHelper.AfficherListe(this.liste, strategieAffichageDossiers);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            var dossierVoyage = new DossierVoyage
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
