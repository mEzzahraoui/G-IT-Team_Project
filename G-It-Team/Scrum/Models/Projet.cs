using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scrum.Models
{
    public class Projet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID{ get; set; }
        public string NomProjet { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int EquipeID { get; set; }
        public int CreateurDeProjetID { get; set; }
        public virtual CreateurDeProjet createur { get; set; }
        public virtual Equipe equipe { get; set; }


    }
}