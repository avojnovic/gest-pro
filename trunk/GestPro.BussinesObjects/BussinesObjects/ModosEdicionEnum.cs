using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace GestPro.BussinesObjects.BussinesObjects
{
    public enum ModosEdicionEnum
    {
        Nuevo = 1,
        Modificar = 2,
        Eliminar = 3,
        Consultar = 4,
        NoGuardar = 5,
        SoloCotizacion = 6
    }
}
