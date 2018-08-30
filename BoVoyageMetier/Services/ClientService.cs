using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;
using BoVoyageMetier.DAL;

namespace BoVoyageMetier.Services
{
	public class ClientService
	{
		public Client Ajout(Client client)
		{
			var cli = new ClientData();
			cli.Ajout(client);
			return client;
		}

	}
}
