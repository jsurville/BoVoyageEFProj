using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoVoyageMetier.Entities
{
    public class AgenceVoyage
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual ICollection<Voyage> Voyages { get; set; }
    }
}
