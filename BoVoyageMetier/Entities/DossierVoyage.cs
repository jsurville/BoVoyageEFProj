using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageMetier.Entities
{
    public class DossierVoyage
    {
        public int Id { get; set; }
        public int NumeroUnique { get; set; }
        public EtatDossier EtatDossier { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public bool AnnulationAssurance { get; set; }
        public int VoyageId { get; set; }
        public int ClientId { get; set; }


        [ForeignKey("VoyageId")]
        public virtual Voyage Voyage { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }


    public enum EtatDossier { EnAttente, EnCours, Refuse, Accepte, Clos, Annule, InSolvable }
}
