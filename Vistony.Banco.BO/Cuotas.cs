using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Banco.BO
{
    public class Cuotas
    {
        public string U_CIA_CODCIA { get; set; }
        public string U_ANO_CODANO{ get; set; }
        public string U_MES_CODMES{ get; set; }
        public string U_VDE_CODVDE { get; set; }
        public string U_VAR_CODVAR { get; set; }
        public Decimal U_PROY_VENTVDE { get; set; }
        public string U_TMO_CODTMO { get; set; }
        public string U_PESO { get; set; }

        public string U_INACTIVO { get; set; }
        public string U_FECHA { get; set; }
        public string U_USUARIO { get; set; }
        public Decimal U_AVANCE_REAL { get; set; }
   


    }

    public class CuotasErrores
    {
        public string U_CIA_CODCIA { get; set; }
        public string U_ANO_CODANO { get; set; }
        public string U_MES_CODMES { get; set; }
        public string U_VDE_CODVDE { get; set; }
        public string U_VAR_CODVAR { get; set; }
        public Decimal U_PROY_VENTVDE { get; set; }
        public string U_TMO_CODTMO { get; set; }
        public string U_PESO { get; set; }

        public string U_INACTIVO { get; set; }
        public string U_FECHA { get; set; }
        public string U_USUARIO { get; set; }
        public Decimal U_AVANCE_REAL { get; set; }

        public string ERROR { get; set; }



    }
}
