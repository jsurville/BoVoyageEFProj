using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BoVoyageMetier.Entities
{

    public class Participant:Personne
    {
        public int NumeroUnique { get; set; }
        public decimal Reduction { get; set; }

        public int DossierReservationId { get; set; }
        
        [ForeignKey("DossierReservationId")]
        public virtual DossierReservation DossierReservation { get; set; }
    }
}

