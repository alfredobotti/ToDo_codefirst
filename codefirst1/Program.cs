using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDocodefirst
{
    public partial class E_Risorsa
    {

        public E_Risorsa()
        {
            this.E_Task = new HashSet<E_Task>();
        }

        [Key]
        public int ID_Risorsa { get; set; }
        public string MatricolaRisorsa { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }


        public virtual ICollection<E_Task> E_Task { get; set; }
    }

    public partial class ToDocodefirstEntities : DbContext
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
        }

        public virtual DbSet<E_ProjectItem> E_ProjectItem { get; set; }
        public virtual DbSet<E_Risorsa> E_Risorsa { get; set; }
        public virtual DbSet<E_Task> E_Task { get; set; }
        public virtual DbSet<T_CategoriaProjectItem> T_CategoriaProjectItem { get; set; }


    }

    public partial class E_ProjectItem
    {
        [Key]
        public int ID_ProjectItem { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public int ID_CategoriaProjectItem { get; set; }
        public System.DateTime DataInserimento { get; set; }
        public System.DateTime DataUltimoAggiornamento { get; set; }

        public virtual T_CategoriaProjectItem T_CategoriaProjectItem { get; set; }
    }

    public partial class E_Task
    {



        [Key]
        public int ID_Task { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public Nullable<int> ID_ParentTask { get; set; }
        public System.DateTime DataInserimento { get; set; }
        public System.DateTime DataUltimoAggiornamento { get; set; }


        public virtual ICollection<E_Task> Listasottotask { get; set; }
        public virtual E_Task Parenttask { get; set; }

        public virtual ICollection<E_Risorsa> Listarisorseassegnate { get; set; }
    }

    public partial class T_CategoriaProjectItem
    {

        public T_CategoriaProjectItem()
        {
            this.E_ProjectItem = new HashSet<E_ProjectItem>();
        }
        [Key]
        public int ID_CategoriaProjectItem { get; set; }
        public byte[] Nome { get; set; }
        public string Descrizione { get; set; }
        public System.DateTime DataInserimento { get; set; }
        public System.DateTime DataUltimaModifica { get; set; }

        public virtual ICollection<E_ProjectItem> E_ProjectItem { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ToDocodefirstEntities context = new ToDocodefirstEntities();
            E_Risorsa alfredo = new E_Risorsa()
            {
                ID_Risorsa = 1,
                MatricolaRisorsa = "12345",
                Cognome = "Botti",
                Nome = "Alfredo",
                Mail = "alfredobotti1@gmail.com",
                Cellulare = "3661958952"
            };
            context.E_Risorsa.Add(alfredo);
            E_Task Task1 = new E_Task()
            {

                ID_Task = 1,
                Titolo = "revisione progetto",
                Descrizione = "revisione intero progetto",
                ID_ParentTask = null,
                DataInserimento = new DateTime(2008, 5, 1),
                DataUltimoAggiornamento = new DateTime(2008, 5, 1),
                Listasottotask = new List<E_Task>(),
                Parenttask = new E_Task(),
                Listarisorseassegnate = new List<E_Risorsa>()

            };
            E_Task Task2 = new E_Task()
            {

                ID_Task = 2,
                Titolo = "revisione codice",
                Descrizione = "revisione codice sorgente",
                ID_ParentTask = 1,
                DataInserimento = new DateTime(2008, 5, 1),
                DataUltimoAggiornamento = new DateTime(2008, 5, 1),
                Parenttask = new E_Task(),
                Listasottotask = new List<E_Task>(),
                Listarisorseassegnate = new List<E_Risorsa>()

            };



            Task1.Listasottotask.Add(Task2);
            Task1.Listarisorseassegnate.Add(alfredo);
            Task1.Parenttask = null;


            Task2.Parenttask = Task1;
            Task2.Listarisorseassegnate.Add(alfredo);

            context.E_Task.Add(Task1);
            context.E_Task.Add(Task2);

            context.SaveChanges();


            var result = context.E_Risorsa.Select(ris => new
            {
                Nome = ris.Nome,
                Cognome = ris.Cognome
            });
            foreach (var v in result)
            {
                Console.WriteLine(v.Nome + " - " + v.Cognome);
            }
            Console.ReadLine();



        }
    }

}
