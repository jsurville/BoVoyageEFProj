using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageMetier.Entities
{
    public class DossierReservation
    {
        public int Id { get; set; }
        public int NumeroUnique { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixParPersonne { get; set; }
        public EtatDossierReservation EtatDossier { get; set; }
        public RaisonAnnulationDossier RaisonAnnulationDossier { get; set; }
        public int AssuranceId { get; set; }
        public int VoyageId { get; set; }
        public int ClientId { get; set; }


        [ForeignKey("VoyageId")]
        public virtual Voyage Voyage { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [ForeignKey("AssuranceId")]
        public virtual Assurance Assurance { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }


    public enum EtatDossierReservation { EnAttente, EnCours, Refuse, Accepte, Clos, Annule, InSolvable }
    public enum RaisonAnnulationDossier { Client = 1, PlacesInsuffisantes = 2 }
}
