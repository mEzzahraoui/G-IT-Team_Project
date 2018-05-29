using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Scrum.Models
{
    public class ScrumContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ScrumContext() : base("name=ScrumContext")
        {
        }

        public System.Data.Entity.DbSet<Scrum.Models.Developpeur> Developpeurs { get; set; }
        public System.Data.Entity.DbSet<Scrum.Models.CreateurDeProjet> CreateurDeProjets{ get; set; }

        public System.Data.Entity.DbSet<Scrum.Models.DeveloppeurToEquipe> DeveloppeurToEquipes { get; set; }

        public System.Data.Entity.DbSet<Scrum.Models.Equipe> Equipes { get; set; }

        public System.Data.Entity.DbSet<Scrum.Models.Projet> Projets { get; set; }

        public System.Data.Entity.DbSet<Scrum.Models.Sprint> Sprints { get; set; }

        public System.Data.Entity.DbSet<Scrum.Models.Tache> Taches { get; set; }
    }
}
