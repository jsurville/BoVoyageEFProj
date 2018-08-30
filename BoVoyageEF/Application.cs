using BoVoyage.Framework.UI;

namespace BoVoyageEF

{
    public class Application : ApplicationBase
    {
        public Application()
            : base("BoVoyage")
        {
        }

        public ClientsMenu ClientsMenu { get; private set; }
		public DossiersMenu DossiersMenu { get; private set; }
		public VoyagesMenu VoyagesMenu { get; private set; }

		protected override void InitialiserModules()
        {
            this.ClientsMenu = this.AjouterModule(new ClientsMenu(this, "GESTION DES CLIENTS"));
			this.DossiersMenu = this.AjouterModule(new DossiersMenu(this, "GESTION DES DOSSIERS"));
			this.VoyagesMenu = this.AjouterModule(new VoyagesMenu(this, "GESTION DES VOYAGES"));
		}

		
	}
}
