using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scrum.Models
{
    public class Tache
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TacheID { get; set; }
        public string nomTache {get; set;}
        public string statusTache { get; set; }
        public int coutTache { get; set; }
        public int DeveloppeurId { get; set; }
        public int SprintID { get; set; }
        public virtual Developpeur developpeur{ get; set; }
        public virtual Sprint sprint { get; set; }

    }
}