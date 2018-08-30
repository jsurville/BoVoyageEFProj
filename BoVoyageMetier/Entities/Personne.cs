using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyageMetier.Entities
{
	public abstract class Personne
	{
		public int Id { get; set; }

		public string Civilite { get; set; }

		public string Nom { get; set; }

		public string Prenom { get; set; }

		public string Adresse { get; set; }

		public DateTime? DateInscription { get; set; }

		public override string ToString()
		{
			return $"{this.Nom} ({this.Id})";
		}
	}
}
