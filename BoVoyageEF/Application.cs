using BoVoyage.Framework.UI;

namespace BoVoyageEF

{
    public class Application : ApplicationBase
    {
        public Application()
            : base("BoVoyage")
        {
        }

        public ClientsMenu Clients { get; private set; }

        protected override void InitialiserModules()
        {
            this.Clients = this.AjouterModule(new ClientsMenu(this, "Clients"));
        }
    }
}
