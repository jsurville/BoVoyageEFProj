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
				InformationAffichage.Creer<DossierReservation>(x=>x.NumeroUnique, "No Unique", 5),
				InformationAffichage.Creer<DossierReservation>(x=>x.EtatDossierReservation, "Etat", 10),
				InformationAffichage.Creer<DossierReservation>(x=>x.NumeroCarteBancaire, "Num. CB", 15),
			    InformationAffichage.Creer<DossierReservation>(x=>x.PrixTotal, "Prix TTC", 10),
				InformationAffichage.Creer<DossierReservation>(x=>x.ClientId, "ID Client", 4),
				InformationAffichage.Creer<DossierReservation>(x=>x.VoyageId, "Id Voyage", 4)
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
			menu.AjouterElement(new ElementMenu("6", "Ajouter une Assurance")
			{
				FonctionAExecuter = this.AjouterAssurance
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
			Console.WriteLine("\nLISTE DES VOYAGES DISPONIBLES\n");
			ConsoleHelper.AfficherListe(new VoyageData().GetList(), VoyagesMenu.strategieAffichageVoyages);
			Console.WriteLine("\nLISTE DES CLIENTS \n");
			ConsoleHelper.AfficherListe(new ClientData().GetList(), ClientsMenu.strategieAffichageClients);

			var dossierReservation = new DossierReservation
			{
				VoyageId = ConsoleSaisie.SaisirEntierObligatoire("Entrez l' Id du Voyage :"),
				NumeroUnique = ConsoleSaisie.SaisirEntierObligatoire("Entrez le Numero Unique (10..) :"),
				ClientId = ConsoleSaisie.SaisirEntierObligatoire("Entrez l' Id Client :"),
				
				PrixParPersonne = ConsoleSaisie.SaisirDecimalObligatoire("Prix par Personne :"),
				NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Numero CB :")
				
			};
			var dossierReservationService = new DossierReservationService();
			dossierReservationService.Ajout(dossierReservation);
		   if (dossierReservation.Id!=0)
			{
				Console.WriteLine("Le Dossier a été créé avec l'Id :" + dossierReservation.Id);
			}
		   else
			{
				Console.WriteLine("Impossible de créer le dossier");
			}
		}

		private void ValiderDossier()
		{ // en attente à en cours
			ConsoleHelper.AfficherEntete("Validation d'un Dossier");

			ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);
			var dossierReservationService = new DossierReservationService();
			var dossierReservation = new DossierReservation();
			dossierReservation.Id = ConsoleSaisie.SaisirEntierObligatoire("Numero du Dossier à Valider :");
			dossierReservation=dossierReservationService.ValiderSolvabilite(dossierReservation.Id);
			if (dossierReservation.EtatDossierReservation == EtatDossierReservation.EnCours && dossierReservation !=null)
			{
				Console.WriteLine("Le Dossier numero " + dossierReservation.Id + " a bien été Validé ");
			}
			else
			{
				Console.WriteLine("Validation impossible pour le dossier numero " + dossierReservation.Id);
			}
		}

		private void AccepterDossier()
		{ // en cours à accepté
			ConsoleHelper.AfficherEntete("Acceptation d'un Dossier");
			
			ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);
			var dossierReservationService = new DossierReservationService();
			var dossierReservation = new DossierReservation();
			dossierReservation.Id = ConsoleSaisie.SaisirEntierObligatoire("Numero du Dossier à Accepter :");
			dossierReservation = dossierReservationService.Accepter(dossierReservation.Id);
			if (dossierReservation.EtatDossierReservation == EtatDossierReservation.Accepte && dossierReservation != null)
			{
				Console.WriteLine("Le Dossier numero " + dossierReservation.Id + " a bien été accepté ");
			}
			else
			{
				Console.WriteLine("Impossible d'accepter le dossier numero " + dossierReservation.Id);
			}
		}

		private void AnnulerDossier()
		{  // en attente ou en cours à refusé
			ConsoleHelper.AfficherEntete("Annulation d'un Dossier");

			ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);
			var dossierReservationService = new DossierReservationService();
			var dossierReservation = new DossierReservation();
			dossierReservation.Id = ConsoleSaisie.SaisirEntierObligatoire("Numero du Dossier à Annuler :");
			var succes = dossierReservationService.Annuler(dossierReservation.Id);
			if (succes )
			{
				Console.WriteLine("Le Dossier numero " + dossierReservation.Id + " a bien été annulé ");
			}
			else
			{
				Console.WriteLine("Impossible d'annuler le dossier numero " + dossierReservation.Id);
			}
		}

		private void AjouterAssurance()
		{
			ConsoleHelper.AfficherEntete("Ajout d'une Assurance");

			ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);

		}

		private void AfficherParticipant()
		{
			ConsoleHelper.AfficherEntete("Liste des Participants");

			ConsoleHelper.AfficherListe(new ParticipantData().GetList(), strategieAffichageParticipants);
		}

		private void EnregistrerParticipant()
		{
			ConsoleHelper.AfficherEntete("Enregistrer un Participant");

			Console.WriteLine("LISTE DES DOSSIERS");
			ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);
			var participant = new Participant
			{
				Civilite = ConsoleSaisie.SaisirChaineObligatoire("Mr/Mme ?"),
				Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom ?"),
				Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom ?"),
				DossierReservationId = ConsoleSaisie.SaisirEntierObligatoire("Id du Dossier de réservation ?"),
				Telephone = ConsoleSaisie.SaisirChaineOptionnelle("Telephone ?"),
				DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de Naissance ?"),
				Adresse = ConsoleSaisie.SaisirChaineOptionnelle("Adresse ?"),
			};

			var participantService = new ParticipantService();
			participantService.AjoutParticipant(participant);
		}


	}
}
