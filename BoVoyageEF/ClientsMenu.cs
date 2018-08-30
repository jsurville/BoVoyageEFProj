using System;
using System.Collections.Generic;
using  BoVoyageMetier.Entities;
using BoVoyage.Framework.UI;
using BoVoyageMetier.DAL;
using BoVoyageMetier.Services;

namespace BoVoyageEF
{
    public class ClientsMenu : ModuleBase<Application>
    {
        // On définit ici les propriétés qu'on veut afficher
        //  et la manière de les afficher
        private static readonly List<InformationAffichage> strategieAffichageClients =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Client>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Client>(x=>x.Civilite, "M/Mme", 4),
                InformationAffichage.Creer<Client>(x=>x.Nom, "Nom", 10),
                InformationAffichage.Creer<Client>(x=>x.Prenom, "Prenom", 10),
                InformationAffichage.Creer<Client>(x=>x.Email, "Email", 15),
                InformationAffichage.Creer<Client>(x=>x.Telephone, "Telephone", 15),
                InformationAffichage.Creer<Client>(x=>x.DateNaissance, "Date de Naissance", 10),
                InformationAffichage.Creer<Client>(x=>x.Adresse, "Adresse", 10),
            };

        //private readonly List<Client> liste = new List<Client>();

        public ClientsMenu(Application application, string nomModule)
            : base(application, nomModule)
        {
            //this.liste = new ClientData().GetList();
            
        }

        protected override void InitialiserMenu(Menu menu)
        {
            menu.AjouterElement(new ElementMenu("1", "Liste des Clients")
            {
                FonctionAExecuter = this.AfficherClient
            });
            menu.AjouterElement(new ElementMenu("2", "Enregistrer un Nouveau Client")
            {
                FonctionAExecuter = this.NouveauClient
            });
            menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal..."));
        }

        private void AfficherClient()
        {
            ConsoleHelper.AfficherEntete("Liste des Clients");
            
            ConsoleHelper.AfficherListe(new ClientData().GetList(), strategieAffichageClients);
        }

        private void NouveauClient()
        {
            ConsoleHelper.AfficherEntete("Enregistrer un Nouveau Client");

            var client = new Client
            {
                Civilite = ConsoleSaisie.SaisirChaineObligatoire("Mr/Mme ?"),
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom ?"),
                Email = ConsoleSaisie.SaisirChaineOptionnelle("Email ?"),
                Telephone = ConsoleSaisie.SaisirChaineOptionnelle("Telephone ?"),
                DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de Naissance ?"),
                Adresse = ConsoleSaisie.SaisirChaineOptionnelle("Adresse ?"),
            };

			var clientService = new ClientService();
			clientService.Ajout(client);
        }
    }
}
