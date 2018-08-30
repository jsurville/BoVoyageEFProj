using System;
using System.Collections.Generic;
using  BoVoyageMetier.Entities;
using BoVoyage.Framework.UI;
using BoVoyageMetier.DAL;
using BoVoyageMetier.Services;

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

		private static readonly List<InformationAffichage> strategieAffichageParticipants
 =
			new List<InformationAffichage>
			{
				InformationAffichage.Creer<Participant>(x=>x.Id, "Id", 3),
				InformationAffichage.Creer<Participant>(x=>x.NumeroUnique, "No Unique", 4),
				InformationAffichage.Creer<Participant>(x=>x.Civilite, "M/Mme", 6),
				InformationAffichage.Creer<Participant>(x=>x.Nom, "Nom", 12),
				InformationAffichage.Creer<Participant>(x=>x.Prenom, "Prenom", 10),										   
				InformationAffichage.Creer<Participant>(x=>x.Telephone, "Telephone", 12),
				InformationAffichage.Creer<Participant>(x=>x.DateNaissance, "Date Naissance", 12),
				InformationAffichage.Creer<Participant>(x=>x.Adresse, "Adresse", 15),
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
				FonctionAExecuter = this.AfficherDossier
			});
			menu.AjouterElement(new ElementMenu("2", "Créer un Nouveau Dossier")
			{
				FonctionAExecuter = this.NouveauDossier
			});
			menu.AjouterElement(new ElementMenu("3", "Valider un Dossier")
			{
				FonctionAExecuter = this.ValiderDossier
			});
			menu.AjouterElement(new ElementMenu("4", "Accepter un Dossier")
			{
				FonctionAExecuter = this.AccepterDossier
			});
			menu.AjouterElement(new ElementMenu("5", "Annuler un Dossier")
			{
				FonctionAExecuter = this.AnnulerDossier
			});
			menu.AjouterElement(new ElementMenu("6", "Cloturer un Dossier")
			{
				FonctionAExecuter = this.CloturerDossier
			});
			menu.AjouterElement(new ElementMenu("7", "Liste des Participants")
			{
				FonctionAExecuter = this.AfficherParticipant
			});

			menu.AjouterElement(new ElementMenu("8", "Enregistrer des Participants")
			{
				FonctionAExecuter = this.EnregistrerParticipant
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
		private void ValiderDossier()
		{
			ConsoleHelper.AfficherEntete("Validation d'un Dossier");

			//ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);
		}

		private void AccepterDossier()
		{
			ConsoleHelper.AfficherEntete("Acceptation d'un Dossier");

			//ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);
		}

		private void AnnulerDossier()
		{
			ConsoleHelper.AfficherEntete("Annulation d'un Dossier");

			//ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);
		}

		private void CloturerDossier()
		{
			ConsoleHelper.AfficherEntete("Cloture d'un Dossier");

			//ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);
		}

		private void AfficherParticipant()
		{
			ConsoleHelper.AfficherEntete("Liste des Participants");

			ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageParticipants);
		}
		private void EnregistrerParticipant()
		{
			ConsoleHelper.AfficherEntete("Enregistrer un Participant");

			var participant = new Participant
			{
				Civilite = ConsoleSaisie.SaisirChaineObligatoire("Mr/Mme ?"),
				Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
				Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom ?"),
				
				Telephone = ConsoleSaisie.SaisirChaineOptionnelle("Telephone ?"),
				DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de Naissance ?"),
				Adresse = ConsoleSaisie.SaisirChaineOptionnelle("Adresse ?"),
			};

			var dossierReservationService = new DossierReservationService();
			dossierReservationService.AjoutParticipant(participant);
		}


	}
}
