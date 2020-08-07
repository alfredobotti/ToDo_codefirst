using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codefirst1.Migrations.models
{
    class E_Risorsa
    {
        public E_Risorsa()
        {
            this.Taskassegnate = new HashSet<E_Task>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Risorsa { get; set; }
        [Required]
        [StringLength(10)]
        public string MatricolaRisorsa { get; set; }
        [StringLength(100)]
        public string Cognome { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string Mail { get; set; }
        [StringLength(50)]
        public string Telefono { get; set; }
        [StringLength(50)]
        public string Cellulare { get; set; }


        public virtual ICollection<E_Task> Taskassegnate { get; set; }
    }
}
