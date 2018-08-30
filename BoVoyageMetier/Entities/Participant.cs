using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BoVoyage.ModelObjet
{
	class Accompagnant
	{
		public int Id { get; set; }
		public int ClientId { get; set; }
		public int DossierVoyageId { get; set; }

		[ForeignKey("ClientId")]
		public virtual Client Client { get; set; }


		[ForeignKey("DossierVoyageId")]
		public virtual DossierVoyage DossierVoyage { get; set; }
	}
}
