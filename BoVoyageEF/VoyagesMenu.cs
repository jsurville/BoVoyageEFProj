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
                InformationAffichage.Creer<Destination>(x=>x.Region, "Région", 15),
                InformationAffichage.Creer<Destination>(x=>x.Description, "Description", 25),                
            };

        internal static readonly List<InformationAffichage> strategieAffichageVoyages =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Voyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Voyage>(x=>x.Destination.Region, "Destination", 15),
                InformationAffichage.Creer<Voyage>(x=>x.DateAller, "Date Aller", 10),
                InformationAffichage.Creer<Voyage>(x=>x.DateRetour, "Date Retour", 10),
                InformationAffichage.Creer<Voyage>(x=>x.PlacesDisponibles, "Nb Places", 15),
                InformationAffichage.Creer<Voyage>(x=>x.PrixParPersonne, "Prix/pers.", 10)
            };

        
        public VoyagesMenu(Application application, string nomModule)
            : base(application, nomModule)
        {
            
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

        internal void AfficherVoyage()
        {
            ConsoleHelper.AfficherEntete("Afficher les Voyages");
			OutilsConsole.Commentaire("Le Prix/Pers est le Prix Agence indicatif\n ");
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

			ConsoleHelper.AfficherListe(new DestinationData().GetList(), strategieAffichageDestination);

			var voyage = new Voyage
            {

                DestinationId = ConsoleSaisie.SaisirEntierObligatoire("Id Destination ?"),
                DateAller = ConsoleSaisie.SaisirDateObligatoire("Date Aller ?"),
                DateRetour = ConsoleSaisie.SaisirDateObligatoire("Date Retour ?"),
                PlacesDisponibles = ConsoleSaisie.SaisirEntierObligatoire("Places max disponibles ?"),
                PrixParPersonne = ConsoleSaisie.SaisirDecimalObligatoire("Prix/pers. ?"),
				AgenceVoyageId = ConsoleSaisie.SaisirEntierObligatoire("Id de l'Agence de Voyage (par défaut 1) ?")
			};
            var voyageService = new VoyageService();
            voyageService.Ajout(voyage);
			if (voyage.Id!=0)
			{
				Console.WriteLine("Le Voyage a été enregistré avec succès");
			}
			else
			{
				Console.WriteLine("Le Voyage n'a pas pu être créé (Erreur de date ou de destination ...)");
			}
        }

        private void SupprimerVoyage()
        {
            ConsoleHelper.AfficherEntete("Suppression d'un Voyage");
			Console.WriteLine("LISTE DES VOYAGES\n");
			ConsoleHelper.AfficherListe(new VoyageData().GetList(), strategieAffichageVoyages);
			var voyageService = new VoyageService();
            
            var voyageId = ConsoleSaisie.SaisirEntierObligatoire("Id du voyage à supprimer ?");
            var succes = voyageService.Supprimer(voyageId);
            if (succes == true)
            {
                Console.WriteLine("Le voyage a été supprimé");
            }
            else
            {
                Console.WriteLine("Suppression impossible car dossier client en cours ");
            }
        }


    }
}
