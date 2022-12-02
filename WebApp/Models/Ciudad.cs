using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Ciudad
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Permitida { get; set; }
        public ICollection<Poliza> Polizas { get; set; }
    }
}
