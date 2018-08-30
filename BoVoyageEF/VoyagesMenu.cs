using System;
using System.Collections.Generic;
using  BoVoyageMetier.Entities;
using BoVoyage.Framework.UI;
using BoVoyageMetier.DAL;

namespace BoVoyageEF
{
    public class VoyagesMenu : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageDestination =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Destination>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Destination>(x=>x.Continent, "Continent", 10),
                InformationAffichage.Creer<Destination>(x=>x.Pays, "Pays", 10),
                InformationAffichage.Creer<Destination>(x=>x.Region, "Région", 10),
                InformationAffichage.Creer<Destination>(x=>x.Description, "Description", 20),                
            };

        private readonly List<Destination> liste = new List<Destination>();

        public VoyagesMenu(Application application, string nomModule)
            : base(application, nomModule)
        {
            this.liste = new DestinationData().GetList();
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

        private void AfficherDestination()
        {
            ConsoleHelper.AfficherEntete("Afficher Destinations");

            ConsoleHelper.AfficherListe(this.liste, strategieAffichageDestination);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            var destination = new Destination
            {
                Continent = ConsoleSaisie.SaisirChaineObligatoire("Continent ?"),
                Pays = ConsoleSaisie.SaisirChaineObligatoire("Pays ?"),
                Region = ConsoleSaisie.SaisirChaineObligatoire("Region ?"),
                Description = ConsoleSaisie.SaisirChaineOptionnelle("Description ?")
            };

            this.liste.Add(destination);
        }
    }
}
