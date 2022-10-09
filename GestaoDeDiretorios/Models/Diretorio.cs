using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeDiretorios.Models
{
    public class Diretorio:Entity
    {
        public string Nome { get; set; }
        public string Caminho { get; set; }
    }
}
