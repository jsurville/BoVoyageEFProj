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
				InformationAffichage.Creer<DossierReservation>(x=>x.NumeroUnique, "No", 5),
				InformationAffichage.Creer<DossierReservation>(x=>x.EtatDossierReservation, "Etat", 8),
				InformationAffichage.Creer<DossierReservation>(x=>x.NumeroCarteBancaire, "Num. CB", 10),
			    InformationAffichage.Creer<DossierReservation>(x=>x.PrixTotal, "PrixTTC", 8),
				InformationAffichage.Creer<DossierReservation>(x=>x.ClientId, "IDClient", 4),
				InformationAffichage.Creer<DossierReservation>(x=>x.VoyageId, "IdVoyage", 4)
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
			menu.AjouterElement(new ElementMenu("1", "Liste des DOSSIERS")
			{
				FonctionAExecuter = this.AfficherDossier
			});
			menu.AjouterElement(new ElementMenu("2", "Créer un Nouveau DOSSIER")
			{
				FonctionAExecuter = this.NouveauDossier
			});
			menu.AjouterElement(new ElementMenu("3", "Valider un dossier")
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

			menu.AjouterElement(new ElementMenu("7", "Ajouter une ASSURANCE")
			{
				FonctionAExecuter = this.AjouterAssurance
			});
			menu.AjouterElement(new ElementMenu("8", "Liste des PARTICIPANTS")
			{
				FonctionAExecuter = this.AfficherParticipant
			});

			menu.AjouterElement(new ElementMenu("9", "Enregistrer des Participants")
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
			OutilsConsole.Commentaire("---------- ( Le Prix/Pers est le Prix Agence indicatif) -------\n ");
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
			else if(dossierReservation.EtatDossierReservation == EtatDossierReservation.Refuse && dossierReservation != null)
			{
				Console.WriteLine("Paiement refusé ...");
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
			else if (dossierReservation.EtatDossierReservation == EtatDossierReservation.Refuse && dossierReservation != null)
			{
				Console.WriteLine("Nombre de places disponibles insuffisant"); 
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
			
			var raisonAnnulation=ConsoleSaisie.SaisirEntierObligatoire("Raison de l'annulation" +
				"\n 1. Cause Client \n 2. Nombre de places inssufisant : ");
			if (raisonAnnulation >= 1 && raisonAnnulation <= 2)
			{ 
				dossierReservation.RaisonAnnulationDossier = (RaisonAnnulationDossier)raisonAnnulation; 
				var succes = dossierReservationService.Annuler(dossierReservation.Id, dossierReservation.RaisonAnnulationDossier);
				if (succes)
				{

					Console.WriteLine("Le Dossier numero " + dossierReservation.Id + " a bien été annulé ");
				}
				else
				{
					Console.WriteLine("Impossible d'annuler le dossier numero " + dossierReservation.Id);
				}
			}
			else
			{
				Console.WriteLine("Choix non valide...");
			}

			
		}

		private void CloturerDossier()
		{
			ConsoleHelper.AfficherEntete("Cloture d'un Dossier");
			ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);
			var dossierReservationService = new DossierReservationService();
			var dossierReservationId = ConsoleSaisie.SaisirEntierObligatoire("Numero du Dossier à Cloturer :");
			var dossierReservation = dossierReservationService.Cloturer(dossierReservationId);
			if (dossierReservation.EtatDossierReservation == EtatDossierReservation.Clos)
			{
				Console.WriteLine("Le Dossier no " + dossierReservationId + " a été cloturé. ");
			}
			else
			{
				Console.WriteLine("Le Dossier no " + dossierReservationId + " n'a pas pu être cloturé");
			}
			

		}

		private void AjouterAssurance()
		{
			ConsoleHelper.AfficherEntete("Ajout d'une Assurance");

			ConsoleHelper.AfficherListe(new DossierData().GetList(), strategieAffichageDossiers);
			
			
			var dossierReservationId = ConsoleSaisie.SaisirEntierObligatoire("Numero du Dossier à attacher :");
			var assuranceId = ConsoleSaisie.SaisirEntierObligatoire("Numero de l'Assurance à ajouter (1 par défaut):");

			var succes = new AssuranceService().Ajout(assuranceId, dossierReservationId);
			if (succes == true)
			{
				Console.WriteLine("L'Assurance annulation a été ajoutée au dossier no :" + dossierReservationId);
			}
			else
			{
				Console.WriteLine("Impossible d'ajouter une assurance annulation");
			}
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
