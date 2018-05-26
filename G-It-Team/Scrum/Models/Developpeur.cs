using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scrum.Models
{
    public class Developpeur
    {
        public Developpeur()
        {
            this.devToequipe = new HashSet<DeveloppeurToEquipe>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeveloppeurID{ get; set; }
        public string Nom { get ; set; }
        public string Prenom { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<DeveloppeurToEquipe> devToequipe { get; set; }
    }
}