using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestPro.BussinesObjects.Exceptions
{
    public class ExcepcionConexionBDNoEstablecida : Exception
    {
        public ExcepcionConexionBDNoEstablecida(Exception innerException)
            : base("", innerException)
        {

        }
    }
}
