using System;
using System.Collections.Generic;
using  BoVoyageMetier.Entities;
using BoVoyage.Framework.UI;

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

        private readonly List<Client> liste = new List<Client>();

        public ClientsMenu(Application application, string nomModule)
            : base(application, nomModule)
        {
            this.liste = new List<Client>
            {
                new Client{Id = 1, Civilite = "Mr", Nom = "BAZAN", Prenom = "Yannick", DateNaissance = new DateTime(2010,1,1),Email = "ybazan.pro@live.fr", Telephone = "0556371195", Adresse="56 chemin vert 33000 Bordeaux" },
                new Client{Id = 2, Civilite = "Mr", Nom = "PEANT", Prenom = "Frédéric", Email = "f.peant@gtm-ingenierie.fr" },
            };
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

        private void AfficherClient()
        {
            ConsoleHelper.AfficherEntete("Afficher Clients");

            ConsoleHelper.AfficherListe(this.liste, strategieAffichageClients);
        }

        private void Nouveau()
        {
            ConsoleHelper.AfficherEntete("Nouveau");

            var client = new Client
            {
				Civilite = ConsoleSaisie.SaisirChaineObligatoire("Mr/Mme ?"),
				Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom ?"),
                Email = ConsoleSaisie.SaisirChaineOptionnelle("Email ?"),
				Telephone = ConsoleSaisie.SaisirChaineOptionnelle("Email ?"),
				DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de Naissance ?"),
				Adresse = ConsoleSaisie.SaisirChaineOptionnelle("Adresse ?"),
			};

            this.liste.Add(client);
        }
    }
}
