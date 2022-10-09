using GestaoDeDiretorios.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeDiretorios.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("gestorDiretoriosDb")
        {

        }

        //Entidades
        public DbSet<Diretorio> Diretorios { get; set; }

    }
}
