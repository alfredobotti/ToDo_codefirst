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
    class T_CategoriaProjectItem
    {
        public T_CategoriaProjectItem()
        {
            this.E_ProjectItem = new HashSet<E_ProjectItem>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_CategoriaProjectItem { get; set; }
        [MaxLength(100)]
        public byte[] Nome { get; set; }
        [StringLength(500)]
        public string Descrizione { get; set; }
        public System.DateTime DataInserimento { get; set; }
        public System.DateTime DataUltimaModifica { get; set; }

        public virtual ICollection<E_ProjectItem> E_ProjectItem { get; set; }
    }
}
