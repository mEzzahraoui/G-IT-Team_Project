using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scrum.Models
{
    public class Sprint
    {
        public Sprint()
        {
            this.taches= new HashSet<Tache>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SprintID { get; set; }
        public string SprintName { get; set; }
        public Nullable<System.DateTime> Date_debut { get; set; }
        public Nullable<System.DateTime> Date_fin { get; set; }
        public int ProjetID  { get; set; }
        public virtual Projet projet { get; set; }
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tache> taches { get; set; }
    }
}