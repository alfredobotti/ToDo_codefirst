using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codefirst1.Migrations.models
{
    class E_Task
    {
        public E_Task()
        {
            Listasottotask = new HashSet<E_Task>();
            Listarisorseassegnate = new HashSet<E_Risorsa>();
        }

        [Key]
        public int ID_Task { get; set; }
        [Required]
        [StringLength(200)]
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public Nullable<int> ID_ParentTask { get; set; }
        public System.DateTime DataInserimento { get; set; }
        public System.DateTime DataUltimoAggiornamento { get; set; }


        public virtual ICollection<E_Task> Listasottotask { get; set; }
        public virtual E_Task Parenttask { get; set; }

        public virtual ICollection<E_Risorsa> Listarisorseassegnate { get; set; }
    }
}
