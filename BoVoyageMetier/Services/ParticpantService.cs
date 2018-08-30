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
		public Participant Ajout(Participant participant)
		{
			var participantData = new ParticipantData();
			participantData.Ajout(participant);
			return participant;
		}

	}
}
