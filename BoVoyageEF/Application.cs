using BoVoyage.Framework.UI;

namespace BoVoyageEF

{
    public class Application : ApplicationBase
    {
        public Application()
            : base("BoVoyage")
        {
        }

        public Clients Clients { get; private set; }

        protected override void InitialiserModules()
        {
            this.Clients = this.AjouterModule(new Clients(this, "Clients"));
        }
    }
}
