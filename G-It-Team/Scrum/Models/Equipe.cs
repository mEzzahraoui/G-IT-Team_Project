using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scrum.Models
{
    public class Equipe
    {
        public Equipe()
        {
            this.projets=new HashSet<Projet>();
            this.devToequipe= new HashSet<DeveloppeurToEquipe>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEquipe { get; set; }
        public string nomEquipe { get; set; }
        public virtual ICollection<Projet> projets { get; set; }
        public virtual ICollection<DeveloppeurToEquipe> devToequipe { get; set; }
    }
}