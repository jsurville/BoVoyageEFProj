using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;

namespace BoVoyageMetier.DAL
{
    public class ClientData
    {
        public List<Client> GetList()
        {
			return new BoVoyage().Clients.ToList();
			
        }
		public Client Ajout(Client client)
		{
			using (var contexte = new BoVoyage())
			{
				contexte.Clients.Add(client);
				contexte.SaveChanges();
			}
			return client;

		}
	}
}
