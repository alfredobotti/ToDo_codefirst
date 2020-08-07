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
    class ToDocodefirstEntities : DbContext
    {

        public ToDocodefirstEntities()
            : base("name=ToDocodefirstEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<E_Task>()
                 .HasMany(t => t.Listasottotask)
                 .WithOptional(t => t.Parenttask)
                 .HasForeignKey(t => t.ID_ParentTask);

            modelBuilder.Entity<E_Risorsa>()
                .HasMany(e => e.Taskassegnate)
                .WithMany(e => e.Listarisorseassegnate)
                .Map(m => m.ToTable("A_Risorsa_Task").MapLeftKey("ID_RISORSA").MapRightKey("ID_TASK"));
            
            modelBuilder.Entity<T_CategoriaProjectItem>()
                .HasMany(e => e.E_ProjectItem)
                .WithRequired(e => e.T_CategoriaProjectItem)
                .WillCascadeOnDelete(false);

        }

        public virtual DbSet<E_ProjectItem> E_ProjectItem { get; set; }
        public virtual DbSet<E_Risorsa> E_Risorsa { get; set; }
        public virtual DbSet<E_Task> E_Task { get; set; }
        public virtual DbSet<T_CategoriaProjectItem> T_CategoriaProjectItem { get; set; }

    }
}
