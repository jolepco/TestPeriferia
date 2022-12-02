using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{

    public class Poliza
    {
        public int Id { get; set; }
        public string Datos_tomador { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha_inicio { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha_Fin { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha_vencimiento_poliza_actual { get; set; }

        public string Placa_Automotor { get; set; }

        public Ciudad ciudad { get; set; }
    }

    public class PolizaVenta
    {
        public int Id { get; set; }
        public string Datos_tomador { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha_inicio { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha_Fin { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha_vencimiento_poliza_actual { get; set; }

        public string Placa_Automotor { get; set; }

        public int IdCiudad { get; set; }

    }
    
    public class loginvm
    {
        public string Nombre { get; set; }

        public string Clave { get; set; }
    }

}
