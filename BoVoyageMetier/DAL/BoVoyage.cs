﻿using System;
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
        public DbSet<AgenceVoyage> AgenceVoyages { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<DossierReservation> DossierReservations { get; set; }
       
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Assurance> Assurances { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<DossierReservation>()
				.HasMany(x => x.Assurances)
				.WithMany()
				.Map(x =>
				{
					x.MapRightKey("AssuranceId");
					x.MapLeftKey("DossierReservationId");
					x.ToTable("DossierReservationAssurances");
				}
				);

		}

	}
}
