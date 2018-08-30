using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BoVoyageMetier.Entities
{
    public class AssuranceDossierReservation
    {
        [Key]
        public int AssuranceId { get; set; }
        [Key]
        public int DossierReservationId { get; set; }

        [ForeignKey("AssuranceId")]
        public virtual Assurance Assurance { get; set; }

        [ForeignKey("DossierReservationId")]
        public virtual DossierReservation DossierReservation { get; set; }

    }
}
