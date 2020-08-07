using codefirst1.Migrations.models;
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

    class Program
    {
        static void Main(string[] args)
        {
            codefirst1.Migrations.models.ToDocodefirstEntities context = new ToDocodefirstEntities();
            E_Risorsa alfredo = new E_Risorsa()
            {
                ID_Risorsa=1,
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
                

            };
            E_Task Task2 = new E_Task()
            {

                ID_Task = 2,
                Titolo = "revisione codice",
                Descrizione = "revisione codice sorgente",
                ID_ParentTask = 1,
                DataInserimento = new DateTime(2008, 5, 1),
                DataUltimoAggiornamento = new DateTime(2008, 5, 1),
                

            };

            T_CategoriaProjectItem categoriaprojectitem = new T_CategoriaProjectItem()
            {


                ID_CategoriaProjectItem = 1,
                Nome = new byte[] { 1, 2, 3 },
                Descrizione = "descrizione",
                DataInserimento = new DateTime(2008, 5, 1),
                DataUltimaModifica = new DateTime(2008, 5, 1),


            };

        E_ProjectItem projectitem = new E_ProjectItem()
            {


                Titolo = "Project item",
                Descrizione = "Project item",
                ID_CategoriaProjectItem = 1,
                DataInserimento = new DateTime(2008, 5, 1),
                DataUltimoAggiornamento = new DateTime(2008, 5, 1)


            };


        Task1.Listasottotask.Add(Task2);
            Task1.Listarisorseassegnate.Add(alfredo);
            Task1.Parenttask = null;


            Task2.Parenttask = Task1;
            Task2.Listarisorseassegnate.Add(alfredo);




            context.E_Task.Add(Task1);
            context.E_Task.Add(Task2);

            context.T_CategoriaProjectItem.Add(categoriaprojectitem);
            context.E_ProjectItem.Add(projectitem);

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
