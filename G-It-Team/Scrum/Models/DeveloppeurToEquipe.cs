using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scrum.Models
{
    public class DeveloppeurToEquipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int developpeurToEqipeId { get; set; }
        public int IdDeveloppeur { get; set; }
        public int IdEquipe { get; set; }
        public virtual Equipe equipe { get; set; }
        public virtual Developpeur developpeur{ get; set; }
    }
}