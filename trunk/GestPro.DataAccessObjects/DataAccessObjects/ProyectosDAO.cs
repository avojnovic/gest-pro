using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using GestPro.BussinesObjects;
using GestPro.BussinesObjects.BussinesObjects;
using Npgsql;
using NpgsqlTypes;

namespace GestPro.DataAccessObjects.DataAccessObjects
{
    public class ProyectosDAO
    {

         #region Singleton
        private static ProyectosDAO Instance = null;
         private ProyectosDAO() 
        {
            
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new ProyectosDAO();
            }
        }

        public static ProyectosDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion

        private Dictionary<long, Proyecto> _diccionarioProyectos;

        public Proyecto obtenerRecursoPorId(long id)
        {
            if (_diccionarioProyectos == null)
                _diccionarioProyectos = obtenerTodos();

            if (_diccionarioProyectos.ContainsKey(id))
                return _diccionarioProyectos[id];
            else
                return null;
        }

        
        public Dictionary<long,Proyecto> obtenerTodos()
        {

            string sql = "";
            sql += " SELECT proyectos.id, proyectos.nombre, proyectos.entregable, proyectos.borrado, etapa_proyecto.nombre as etapa, etapa_proyecto.id as id_etapa , id_cliente, id_leader";
            sql += " FROM proyectos";
            sql += " LEFT JOIN recursos ON proyectos.id_leader=recursos.id";
            sql += " LEFT JOIN clientes ON proyectos.id_cliente=clientes.id";
            sql += " LEFT JOIN etapa_proyecto ON proyectos.id_etapa=etapa_proyecto.id"; 
            sql += " where proyectos.borrado=false and recursos.borrado=false and clientes.borrado=false";

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Proyecto> dicProyectos = new Dictionary<long, Proyecto>();

            while (dr.Read())
            {
                Proyecto p = new Proyecto();

                if (!dr.IsDBNull(dr.GetOrdinal("id")))
                    p.Id = long.Parse(dr["id"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                    p.Nombre = dr.GetString(dr.GetOrdinal("nombre"));

                if (!dr.IsDBNull(dr.GetOrdinal("entregable")))
                    p.Release = dr.GetString(dr.GetOrdinal("entregable"));

                p.Etapa=new EtapaProyecto();

                if (!dr.IsDBNull(dr.GetOrdinal("id_etapa")))
                    p.Etapa.Id = long.Parse(dr["id_etapa"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("etapa")))
                    p.Etapa.Nombre = dr.GetString(dr.GetOrdinal("etapa"));


                p.Leader = RecursoDAO.Instancia.obtenerRecursoPorId(long.Parse(dr["id_leader"].ToString()));
                if (p.Leader == null)
                    p.Leader = new Recurso();

                p.Cliente = ClienteDAO.Instancia.obtenerClientePorId(long.Parse(dr["id_cliente"].ToString()));
                if(p.Cliente==null)
                 p.Cliente = new Cliente();


                p.ListaRegistrosAvance = RegAvanceDAO.Instancia.obtenerRegAvanceProyecto(p.Id);
                p.ListaCasos = CasoDAO.Instancia.obtenerTodosPorProyecto(p.Id);

                if (!dicProyectos.ContainsKey(p.Id))
                    dicProyectos.Add(p.Id, p);
            }

            return dicProyectos;

        }

        public Proyecto obtenerPorId(long id)
        {

            string sql = "";
            sql += " SELECT proyectos.id, proyectos.nombre, proyectos.entregable, proyectos.borrado, etapa_proyecto.nombre as etapa, etapa_proyecto.id as id_etapa , id_cliente, id_leader";
            sql += " FROM proyectos";
            sql += " LEFT JOIN recursos ON proyectos.id_leader=recursos.id";
            sql += " LEFT JOIN clientes ON proyectos.id_cliente=clientes.id";
            sql += " LEFT JOIN etapa_proyecto ON proyectos.id_etapa=etapa_proyecto.id";
            sql += " where proyectos.borrado=false and recursos.borrado=false and clientes.borrado=false and proyectos.id='"+id.ToString()+"'";

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();

            Proyecto p = new Proyecto();
            if (dr.Read())
            {
                

                if (!dr.IsDBNull(dr.GetOrdinal("id")))
                    p.Id = long.Parse(dr["id"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                    p.Nombre = dr.GetString(dr.GetOrdinal("nombre"));

                if (!dr.IsDBNull(dr.GetOrdinal("entregable")))
                    p.Release = dr.GetString(dr.GetOrdinal("entregable"));

                p.Etapa = new EtapaProyecto();

                if (!dr.IsDBNull(dr.GetOrdinal("id_etapa")))
                    p.Etapa.Id = long.Parse(dr["id_etapa"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("etapa")))
                    p.Etapa.Nombre = dr.GetString(dr.GetOrdinal("etapa"));


                p.Leader = RecursoDAO.Instancia.obtenerRecursoPorId(long.Parse(dr["id_leader"].ToString()));
                if (p.Leader == null)
                    p.Leader = new Recurso();

                p.Cliente = ClienteDAO.Instancia.obtenerClientePorId(long.Parse(dr["id_cliente"].ToString()));
                if (p.Cliente == null)
                    p.Cliente = new Cliente();

               
            }

            return p;

        }

        public void insertar(Proyecto p)
        { 
        
                string queryStr;

                queryStr = "INSERT INTO proyectos( nombre, entregable, borrado, id_etapa, id_cliente, id_leader)";
                queryStr +=" VALUES ( :nombre, :entregable, :borrado, :id_etapa, :id_cliente, :id_leader);";

                NpgsqlDb.Instancia.PrepareCommand(queryStr);
                NpgsqlDb.Instancia.AddCommandParameter(":nombre", NpgsqlDbType.Varchar, ParameterDirection.Input, false, p.Nombre);
                NpgsqlDb.Instancia.AddCommandParameter(":entregable", NpgsqlDbType.Varchar, ParameterDirection.Input, false, p.Release);
                NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, p.Borrado);
                NpgsqlDb.Instancia.AddCommandParameter(":id_etapa", NpgsqlDbType.Bigint, ParameterDirection.Input, false, p.Etapa.Id);
                NpgsqlDb.Instancia.AddCommandParameter(":id_cliente", NpgsqlDbType.Bigint, ParameterDirection.Input, false, p.Cliente.Id);
                NpgsqlDb.Instancia.AddCommandParameter(":id_leader", NpgsqlDbType.Bigint, ParameterDirection.Input, false, p.Leader.Id);


                try
                {
                    NpgsqlDb.Instancia.ExecuteNonQuery();

                }
                catch (System.OverflowException Ex)
                {
                    throw Ex;
                }

        }

        public void actualizar(Proyecto p)
        {
            string queryStr;

            queryStr = "UPDATE proyectos SET nombre=:nombre, entregable=:entregable, borrado=:borrado, id_etapa=:id_etapa, id_cliente=:id_cliente,id_leader=:id_leader";
             queryStr +=" WHERE id=:id";
            
            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id", NpgsqlDbType.Bigint, ParameterDirection.Input, false, p.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":nombre", NpgsqlDbType.Varchar, ParameterDirection.Input, false, p.Nombre);
            NpgsqlDb.Instancia.AddCommandParameter(":entregable", NpgsqlDbType.Varchar, ParameterDirection.Input, false, p.Release);
            NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, p.Borrado);
            NpgsqlDb.Instancia.AddCommandParameter(":id_etapa", NpgsqlDbType.Bigint, ParameterDirection.Input, false, p.Etapa.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":id_cliente", NpgsqlDbType.Bigint, ParameterDirection.Input, false, p.Cliente.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":id_leader", NpgsqlDbType.Bigint, ParameterDirection.Input, false, p.Leader.Id);


            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }

        }


    }
}
