using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;
using BoVoyageMetier.DAL;

namespace BoVoyageMetier.Services
{
	public class ParticipantService
	{
		public Participant AjoutParticipant(Participant participant)
		{
			var participantData = new ParticipantData();
			if (new DestinationData().GetById(participant.DossierReservationId)!=null
                && participantData.GetList()
                .Where(x => x.DossierReservationId == participant.DossierReservationId).Count() < 9)
			{
				participantData.Ajouter(participant);
			}
			else
			{
				Console.WriteLine("Le nombre Max de place a été atteint");
			}
			return participant;
		}
	}
}
