using System;
using System.Collections.Generic;
using  BoVoyageMetier.Entities;
using BoVoyage.Framework.UI;
using BoVoyageMetier.DAL;
using BoVoyageMetier.Services;

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

        private static readonly List<InformationAffichage> strategieAffichageVoyages =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Voyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Voyage>(x=>x.Destination, "Destination", 15),
                InformationAffichage.Creer<Voyage>(x=>x.DateAller, "Date Aller", 15),
                InformationAffichage.Creer<Voyage>(x=>x.DateRetour, "Date Retour", 15),
                InformationAffichage.Creer<Voyage>(x=>x.NombreVoygeur, "Nbre Voyageurs", 4),
                InformationAffichage.Creer<Voyage>(x=>x.PrixUnitaire, "Prix/pers.", 5)
            };

        
        public VoyagesMenu(Application application, string nomModule)
            : base(application, nomModule)
        {
            //this.liste = new DestinationData().GetList();
        }

        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Liste des Destinations ")
            {
                FonctionAExecuter = this.AfficherDestination
            });
            menu.AjouterElement(new ElementMenu("2", "Enregistrer Nouvelle Destination")
            {
                FonctionAExecuter = this.NouveauDestination
            });

            menu.AjouterElement(new ElementMenu("3", "Liste des Voyages")
            {
                FonctionAExecuter = this.AfficherVoyage
            });
            
            menu.AjouterElement(new ElementMenu("4", "Enregistrer un Nouveau Voyage")
            {
                FonctionAExecuter = this.NouveauVoyage
            });
            menu.AjouterElement(new ElementMenu("5", "Supprimer un Voyage")
            {
                FonctionAExecuter = this.SupprimerVoyage
            });


            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void AfficherDestination()
        {
            ConsoleHelper.AfficherEntete("Afficher les Destinations");

            ConsoleHelper.AfficherListe(new DestinationData().GetList(), strategieAffichageDestination);
        }

        private void AfficherVoyage()
        {
            ConsoleHelper.AfficherEntete("Afficher les Voyages");

            ConsoleHelper.AfficherListe(new VoyageData().GetList(), strategieAffichageVoyages);
        }

        private void NouveauDestination()
        {
            ConsoleHelper.AfficherEntete("Nouvelle Destination");

            var destination = new Destination
            {
                Continent = ConsoleSaisie.SaisirChaineObligatoire("Continent ?"),
                Pays = ConsoleSaisie.SaisirChaineObligatoire("Pays ?"),
                Region = ConsoleSaisie.SaisirChaineObligatoire("Region ?"),
                Description = ConsoleSaisie.SaisirChaineOptionnelle("Description ?")
            };
            var destinationService = new DestinationService();
            destinationService.Ajout(destination);
        }

        private void NouveauVoyage()
        {
            ConsoleHelper.AfficherEntete("Nouveau Voyage");

            var voyage = new Voyage
            {
                DestinationId = ConsoleSaisie.SaisirEntierObligatoire("Id Destination ?"),
                DateAller = ConsoleSaisie.SaisirDateObligatoire("Date Aller ?"),
                DateRetour = ConsoleSaisie.SaisirDateObligatoire("Date Retour ?"),
                NombreVoygeur = ConsoleSaisie.SaisirEntierObligatoire("Nbre de VOyageurs ?"),
                PrixUnitaire = ConsoleSaisie.SaisirDecimalObligatoire("Prix/pers. ?")
            };
            var voyageService = new VoyageService();
            voyageService.Ajout(voyage);
        }

        private void SupprimerVoyage()
        {
            //ConsoleHelper.AfficherEntete("Nouveau Voyage");
            var voyageService = new VoyageService();
            var voyage = new Voyage();
            voyage.Id = ConsoleSaisie.SaisirEntierObligatoire("Id du voyage à supprimer ?");
            var succes = voyageService.Supprimer(voyage.Id);
            if (succes == true)
            {
                Console.WriteLine("Le voyage a été supprimé");
            }
            else
            {
                Console.WriteLine("Impossible de supprimer le voayge ");
            }
        }


    }
}
