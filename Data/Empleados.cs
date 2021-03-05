using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzorEmpleados.Data
{
    public class Empleados
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public int EstatusId { get; set; }
        public string EstatusDescripcion { get; set; }
    }
}
