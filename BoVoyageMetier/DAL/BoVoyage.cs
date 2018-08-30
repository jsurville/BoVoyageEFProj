using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;

namespace BoVoyageMetier.DAL
{
    class BoVoyage : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<DossierReservation> DossierVoyages { get; set; }
        /*
        public DbSet<Accompagnant> Accompagnants { get; set; }
        public DbSet<CarteBancaire> CarteBancaires { get; set; }
        public DbSet<Campagne> Campagnes { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }*/
    }
}
