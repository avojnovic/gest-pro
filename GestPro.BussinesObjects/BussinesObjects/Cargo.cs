using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace GestPro.BussinesObjects.BussinesObjects
{
    public class Cargo
    {
        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private float _sueldo;

        public float Sueldo
        {
            get { return _sueldo; }
            set { _sueldo = value; }
        }

        public override string ToString()
        {
            return Nombre+" / "+Descripcion;
        }

        public PerfilesEnum Perfil
        {
            get 
            {
                switch (Id)
                {
                    case 1:
                        return PerfilesEnum.ProyectManager;
                    case 2:
                        return PerfilesEnum.TeamLeader;
                    case 3:
                        return PerfilesEnum.Tester;
                    case 4:
                        return PerfilesEnum.Suppport;
                    case 5:
                        return PerfilesEnum.Developer;
                    default:
                        return PerfilesEnum.Desconocido;
                }
                
            }
        }

        public static enum PerfilesEnum
        {
            ProyectManager = 1,
            TeamLeader = 2,
            Tester = 3,
            Suppport = 4,
            Developer = 5,
            Desconocido=6
        }
    }
}
