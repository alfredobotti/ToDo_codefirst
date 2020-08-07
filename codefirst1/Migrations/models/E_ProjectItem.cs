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
    class E_ProjectItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ProjectItem { get; set; }
        [Required]
        [StringLength(200)]
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public int ID_CategoriaProjectItem { get; set; }
        public System.DateTime DataInserimento { get; set; }
        public System.DateTime DataUltimoAggiornamento { get; set; }

        public virtual T_CategoriaProjectItem T_CategoriaProjectItem { get; set; }
    }
}
