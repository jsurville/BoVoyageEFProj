using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageMetier.Entities
{
    public class Voyage
    {
        public int Id { get; set; }
        
        public DateTime DateAller { get; set; }
        public DateTime DateRetour { get; set; }
        public int PlacesDisponibles { get; set; }
        public decimal PrixParPersonne { get; set; }

        public int DestinationId { get; set; }
        public int AgenceVoyageId { get; set; }


        public decimal PrixParPersonne { get; set; }

        [ForeignKey("DestinationId")]
        public virtual Destination Destination { get; set; }
        [ForeignKey("AgenceVoyageId")]
        public virtual AgenceVoyage AgenceVoyage { get; set; }
    }
}
