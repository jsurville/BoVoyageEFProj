using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyageMetier.Entities;

namespace BoVoyageMetier.DAL
{
    public class DossierData
    {
        public List<DossierReservation> GetList()
        {
            using (var contexte = new BoVoyage())
            {
                return contexte.DossierReservations.Include("Participants").ToList();          
            }                    
        }

        public DossierReservation GetById(int dossierReservationId)
        {
            using (var contexte = new BoVoyage())
            {
                return contexte.DossierReservations.Include("Participants").Single(x=>x.Id==dossierReservationId);
            }
        }
    }

