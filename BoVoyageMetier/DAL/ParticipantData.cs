using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;

namespace BoVoyageMetier.DAL
{
    public class ParticipantData
    {
        public List<Participant> GetList()
        {
			using (var contexte = new BoVoyage())
			{
				return contexte.Participants.ToList();
			}
			
        }
		public Participant Ajouter(Participant participant)
		{
			using (var contexte = new BoVoyage())
			{
				contexte.Participants.Add(participant);
				contexte.SaveChanges();
			}
			return participant;

		}
	}
}
