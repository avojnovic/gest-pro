using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using GestPro.BussinesObjects.BussinesObjects;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace GestPro.DataAccessObjects.DataAccessObjects
{
    public class CasoDAO
    {
         #region Singleton
        public Dictionary<long, EtapaCaso> _etapas;
        public Dictionary<long, TipoCaso> _tipos;

        private static CasoDAO Instance = null;
        private CasoDAO() 
        {
            
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new CasoDAO();
                
            }
        }

        public static CasoDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion

       

        public Dictionary<long, Caso> obtenerTodosPorResponsable(Recurso r)
        {
            
            string sql = "";
            sql += " SELECT casos.id, casos.nro_caso,casos.id_proyecto, casos.id_responsable_des, casos.id_responsable_pru,casos.descripcion, casos.fecha_entrega, casos.prioridad, casos.tiempo_estimado, ";
            sql += " casos.tiempo_restante, casos.desc_implementacion, casos.desc_pruebas,  ";
            sql += " recursos.id as recurso_id, tipo_caso.id as tipocaso,tipo_caso.descripcion , etapa_caso.id as etapacaso,etapa_caso.descripcion ";
            sql += " FROM casos ";
            sql += " LEFT JOIN etapa_caso on casos.id_etapa_caso=etapa_caso.id ";
            sql += " LEFT JOIN tipo_caso on casos.id_tipo_caso=tipo_caso.id";
            sql += " LEFT JOIN recursos on casos.id_responsable=recursos.id";
            sql += " where casos.borrado=false ";

            if (r.Cargo.Perfil == Cargo.PerfilesEnum.Developer)
            {
                sql += " and casos.id_responsable_des='"+r.Id.ToString()+"'";
            }

            if (r.Cargo.Perfil == Cargo.PerfilesEnum.Suppport)
            {
                sql += " and (casos.id_responsable_des='" + r.Id.ToString() + "'";
                sql += " or casos.id_responsable='" + r.Id.ToString() + "')";
            }

            if (r.Cargo.Perfil == Cargo.PerfilesEnum.Tester)
            {
                sql += " and (casos.id_responsable_pru='" + r.Id.ToString() + "'";
                sql += " or casos.id_responsable='" + r.Id.ToString() + "')";
            }
            if (r.Cargo.Perfil == Cargo.PerfilesEnum.TeamLeader || r.Cargo.Perfil == Cargo.PerfilesEnum.ProyectManager)
            {
                sql += " and casos.id_responsable='" + r.Id.ToString() + "'";
            }



            return obtenerCasos(sql);
        }

        public Caso obtenerPorId(long id)
        {

            string sql = @"
             SELECT casos.id, casos.nro_caso,casos.id_proyecto ,casos.id_responsable_des, casos.id_responsable_pru,casos.descripcion, casos.fecha_entrega, casos.prioridad, casos.tiempo_estimado,
             casos.tiempo_restante, casos.desc_implementacion, casos.desc_pruebas,  
             recursos.id as recurso_id, tipo_caso.id as tipocaso,tipo_caso.descripcion , etapa_caso.id as etapacaso,etapa_caso.descripcion 
             FROM casos 
            LEFT JOIN etapa_caso on casos.id_etapa_caso=etapa_caso.id 
             LEFT JOIN tipo_caso on casos.id_tipo_caso=tipo_caso.id
             LEFT JOIN recursos on casos.id_responsable=recursos.id
             where casos.id='"+id.ToString()+"'";
            Dictionary<long, Caso> _dic = obtenerCasos(sql);

            if (_dic.Any())
                return _dic.Values.ToList()[0];
            else
                return null;
        }


        public Dictionary<long, Caso> obtenerTodos()
        {

            string sql = @"
             SELECT casos.id, casos.nro_caso,casos.id_proyecto ,casos.id_responsable_des, casos.id_responsable_pru,casos.descripcion, casos.fecha_entrega, casos.prioridad, casos.tiempo_estimado, 
            casos.tiempo_restante, casos.desc_implementacion, casos.desc_pruebas,  
             recursos.id as recurso_id, tipo_caso.id as tipocaso,tipo_caso.descripcion , etapa_caso.id as etapacaso,etapa_caso.descripcion 
             FROM casos 
             LEFT JOIN etapa_caso on casos.id_etapa_caso=etapa_caso.id 
            LEFT JOIN tipo_caso on casos.id_tipo_caso=tipo_caso.id
            LEFT JOIN recursos on casos.id_responsable=recursos.id
            where casos.borrado=false ";

            return obtenerCasos(sql);
        }

        public Dictionary<long, Caso> obtenerTodosPendientesPlan()
        {

            string sql= @"
              SELECT casos.id, casos.nro_caso,casos.id_proyecto ,casos.id_responsable_des, casos.id_responsable_pru,casos.descripcion, casos.fecha_entrega, casos.prioridad, casos.tiempo_estimado, 
             casos.tiempo_restante, casos.desc_implementacion, casos.desc_pruebas, 
             recursos.id as recurso_id, tipo_caso.id as tipocaso,tipo_caso.descripcion , etapa_caso.id as etapacaso,etapa_caso.descripcion
              FROM casos 
                LEFT JOIN plan_de_trabajo on casos.id=plan_de_trabajo.id_caso
                LEFT JOIN etapa_caso on casos.id_etapa_caso=etapa_caso.id 
             LEFT JOIN tipo_caso on casos.id_tipo_caso=tipo_caso.id
             LEFT JOIN recursos on casos.id_responsable=recursos.id

              where casos.borrado=false and plan_de_trabajo.id_caso is null and etapa_caso.id<>4 ";

            return obtenerCasos(sql);
        }

        public List< Caso> obtenerTodosPorProyecto(long idProyecto)
        {

            string sql = @"
             SELECT casos.id, casos.nro_caso,casos.id_proyecto ,casos.id_responsable_des, casos.id_responsable_pru, casos.descripcion, casos.fecha_entrega, casos.prioridad, casos.tiempo_estimado, 
            casos.tiempo_restante, casos.desc_implementacion, casos.desc_pruebas,  
             recursos.id as recurso_id, tipo_caso.id as tipocaso,tipo_caso.descripcion , etapa_caso.id as etapacaso,etapa_caso.descripcion 
             FROM casos 
             LEFT JOIN etapa_caso on casos.id_etapa_caso=etapa_caso.id 
             LEFT JOIN tipo_caso on casos.id_tipo_caso=tipo_caso.id
            LEFT JOIN recursos on casos.id_responsable=recursos.id
             where casos.borrado=false and casos.id_proyecto='" + idProyecto.ToString() + "'";

            Dictionary<long, Caso> _dic=obtenerCasos(sql);

            return _dic.Values.ToList();

        }


        private  Dictionary<long, Caso> obtenerCasos(string sql)
        {
            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Caso> dicCasos = new Dictionary<long, Caso>();

            while (dr.Read())
            {
                Caso c = new Caso();

                if (!dr.IsDBNull(dr.GetOrdinal("id")))
                    c.Id = long.Parse(dr["id"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("nro_caso")))
                    c.NroCaso = long.Parse(dr["nro_caso"].ToString());

                c.Borrado = false;
                long idProyecto;
                if (!dr.IsDBNull(dr.GetOrdinal("id_proyecto")))
                {
                    idProyecto = long.Parse(dr["id_proyecto"].ToString());
                    c.Proyecto = ProyectosDAO.Instancia.obtenerPorId(idProyecto);
                }



                if (!dr.IsDBNull(dr.GetOrdinal("descripcion")))
                    c.Descripcion = dr.GetString(dr.GetOrdinal("descripcion"));

                if (!dr.IsDBNull(dr.GetOrdinal("fecha_entrega")))
                    c.FechaEntrega = dr.GetDateTime(dr.GetOrdinal("fecha_entrega"));

                if (!dr.IsDBNull(dr.GetOrdinal("prioridad")))
                    c.Prioridad = int.Parse(dr["prioridad"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("tiempo_estimado")))
                    c.TiempoEstimado = float.Parse(dr["tiempo_estimado"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("tiempo_restante")))
                    c.TiempoRestante = float.Parse(dr["tiempo_restante"].ToString());


                if (!dr.IsDBNull(dr.GetOrdinal("desc_implementacion")))
                    c.DescripcionImplementacion = dr.GetString(dr.GetOrdinal("desc_implementacion"));

                if (!dr.IsDBNull(dr.GetOrdinal("desc_pruebas")))
                    c.DescripcionPruebas = dr.GetString(dr.GetOrdinal("desc_pruebas"));

               
                if (!dr.IsDBNull(dr.GetOrdinal("recurso_id")))
                { long idRecurso;
                    idRecurso = long.Parse(dr["recurso_id"].ToString());
                    c.Responsable = new Recurso();
                    c.Responsable = RecursoDAO.Instancia.obtenerRecursoPorId(idRecurso);
                }

                  
                if (!dr.IsDBNull(dr.GetOrdinal("id_responsable_des")))
                {long idDesarrollador;
                    idDesarrollador = long.Parse(dr["id_responsable_des"].ToString());
                    c.ResponsableDesarrollo = new Recurso();
                    c.ResponsableDesarrollo = RecursoDAO.Instancia.obtenerRecursoPorId(idDesarrollador);
                }

                
                 if (!dr.IsDBNull(dr.GetOrdinal("id_responsable_pru")))
                { long idPruebas;
                    idPruebas = long.Parse(dr["id_responsable_pru"].ToString());
                    c.ResponsablePruebas = new Recurso();
                    c.ResponsablePruebas = RecursoDAO.Instancia.obtenerRecursoPorId(idPruebas);
                }


               
                 if (_tipos == null)
                 {
                     _tipos = obtenerTipos();
                 }

                 if (!dr.IsDBNull(dr.GetOrdinal("tipocaso")))
                 {
                     if (_tipos.ContainsKey(long.Parse(dr["tipocaso"].ToString())))
                         c.TipoCaso = _tipos[long.Parse(dr["tipocaso"].ToString())];
                 }

                 if (_etapas == null)
                 {
                     _etapas =obtenerEtapas() ;
                 }
                 if (!dr.IsDBNull(dr.GetOrdinal("etapacaso")))
                 {
                     if (_etapas.ContainsKey(long.Parse(dr["etapacaso"].ToString())))
                         c.EtapaCaso = _etapas[long.Parse(dr["etapacaso"].ToString())];
                 }

                c.ListaRegistrosAvance = RegAvanceDAO.Instancia.obtenerRegAvanceCaso(c.Id);


                if (!dicCasos.ContainsKey(c.Id))
                    dicCasos.Add(c.Id, c);
            }

            return dicCasos;
        }

        public  Dictionary<long, TipoCaso> obtenerTipos()
        {
            string sql = "SELECT id, descripcion  FROM tipo_caso;";

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, TipoCaso> dicTipos = new Dictionary<long, TipoCaso>();

            while (dr.Read())
            {
                TipoCaso c = new TipoCaso();

                if (!dr.IsDBNull(dr.GetOrdinal("id")))
                    c.Id = long.Parse(dr["id"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("descripcion")))
                    c.Nombre = dr.GetString(dr.GetOrdinal("descripcion"));

                dicTipos.Add(c.Id, c);
            }
            return dicTipos;


        }

        public Dictionary<long, EtapaCaso> obtenerEtapas()
        {
            string sql = "SELECT id, descripcion FROM etapa_caso;";

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, EtapaCaso> dicEtapas = new Dictionary<long, EtapaCaso>();

            while (dr.Read())
            {
                EtapaCaso c = new EtapaCaso();

                if (!dr.IsDBNull(dr.GetOrdinal("id")))
                    c.Id = long.Parse(dr["id"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("descripcion")))
                    c.Nombre = dr.GetString(dr.GetOrdinal("descripcion"));

                dicEtapas.Add(c.Id, c);
            }
            return dicEtapas;

        }



        public long insertar(Caso c)
        {
            long insertID=0;
            string queryStr;


            queryStr = @"INSERT INTO casos(descripcion, fecha_entrega, prioridad, tiempo_estimado,
            tiempo_restante, desc_implementacion, desc_pruebas, borrado,
             id_responsable, id_tipo_caso, id_etapa_caso, id_proyecto, id_responsable_des,id_responsable_pru)
            VALUES(:descripcion, :fecha_entrega, :prioridad, :tiempo_estimado, 
             :tiempo_restante, :desc_implementacion, :desc_pruebas, :borrado, 
             :id_responsable, :id_tipo_caso, :id_etapa_caso, :id_proyecto, :id_responsable_des,
              :id_responsable_pru);select currval('casos_id_seq');";


            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":descripcion", NpgsqlDbType.Varchar, ParameterDirection.Input, false, c.Descripcion);
            NpgsqlDb.Instancia.AddCommandParameter(":fecha_entrega", NpgsqlDbType.Timestamp, ParameterDirection.Input, false, c.FechaEntrega);
            NpgsqlDb.Instancia.AddCommandParameter(":prioridad", NpgsqlDbType.Integer, ParameterDirection.Input, false, c.Prioridad);
            NpgsqlDb.Instancia.AddCommandParameter(":tiempo_estimado", NpgsqlDbType.Numeric, ParameterDirection.Input, false, c.TiempoEstimado);
            NpgsqlDb.Instancia.AddCommandParameter(":tiempo_restante", NpgsqlDbType.Numeric, ParameterDirection.Input, false, c.TiempoRestante);
            NpgsqlDb.Instancia.AddCommandParameter(":desc_implementacion", NpgsqlDbType.Varchar, ParameterDirection.Input, false, c.DescripcionImplementacion);
            NpgsqlDb.Instancia.AddCommandParameter(":desc_pruebas", NpgsqlDbType.Varchar, ParameterDirection.Input, false, c.DescripcionPruebas);
             NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, c.Borrado);
             NpgsqlDb.Instancia.AddCommandParameter(":id_responsable", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.Responsable.Id);
             NpgsqlDb.Instancia.AddCommandParameter(":id_tipo_caso", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.TipoCaso.Id);
             NpgsqlDb.Instancia.AddCommandParameter(":id_etapa_caso", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.EtapaCaso.Id);
             NpgsqlDb.Instancia.AddCommandParameter(":id_proyecto", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.Proyecto.Id);
             NpgsqlDb.Instancia.AddCommandParameter(":id_responsable_des", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.ResponsableDesarrollo.Id);
             NpgsqlDb.Instancia.AddCommandParameter(":id_responsable_pru", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.ResponsablePruebas.Id);
            



            try
            {

                insertID = NpgsqlDb.Instancia.ExecuteScalar();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }

            //string sql = "SELECT max(id) as max  FROM casos;";
            //NpgsqlDb.Instancia.PrepareCommand(sql);
            //NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();

            //while (dr.Read())
            //{

            //    if (!dr.IsDBNull(dr.GetOrdinal("max")))
            //        insertID = long.Parse(dr["max"].ToString());
            //}

            return insertID;
        }

         public void Actualizar(Caso c)
        {

            string queryStr;
            string resp = "";

            if (c.Responsable != null)
            {
                resp = " id_responsable=:id_responsable, ";
            }

            queryStr =string.Format( @" UPDATE casos
               SET  descripcion=:descripcion, fecha_entrega=:fecha_entrega, prioridad=:prioridad, 
             tiempo_estimado=:tiempo_estimado, tiempo_restante=:tiempo_restante, desc_implementacion=:desc_implementacion,
             desc_pruebas=:desc_pruebas, borrado=:borrado, {0} id_tipo_caso=:id_tipo_caso, 
             id_etapa_caso=:id_etapa_caso, id_proyecto=:id_proyecto, id_responsable_des=:id_responsable_des, id_responsable_pru=:id_responsable_pru
            WHERE id=:id;",resp);

          


            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id", NpgsqlDbType.Integer, ParameterDirection.Input, false, c.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":descripcion", NpgsqlDbType.Varchar, ParameterDirection.Input, false, c.Descripcion);
            NpgsqlDb.Instancia.AddCommandParameter(":fecha_entrega", NpgsqlDbType.Timestamp, ParameterDirection.Input, false, c.FechaEntrega);
            NpgsqlDb.Instancia.AddCommandParameter(":prioridad", NpgsqlDbType.Integer, ParameterDirection.Input, false, c.Prioridad);
            NpgsqlDb.Instancia.AddCommandParameter(":tiempo_estimado", NpgsqlDbType.Numeric, ParameterDirection.Input, false, c.TiempoEstimado);
            NpgsqlDb.Instancia.AddCommandParameter(":tiempo_restante", NpgsqlDbType.Numeric, ParameterDirection.Input, false, c.TiempoRestante);
            NpgsqlDb.Instancia.AddCommandParameter(":desc_implementacion", NpgsqlDbType.Varchar, ParameterDirection.Input, false, c.DescripcionImplementacion);
            NpgsqlDb.Instancia.AddCommandParameter(":desc_pruebas", NpgsqlDbType.Varchar, ParameterDirection.Input, false, c.DescripcionPruebas);
             NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, c.Borrado);
             if (c.Responsable != null)
             {
                 NpgsqlDb.Instancia.AddCommandParameter(":id_responsable", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.Responsable.Id);
             }
             NpgsqlDb.Instancia.AddCommandParameter(":id_tipo_caso", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.TipoCaso.Id);
             NpgsqlDb.Instancia.AddCommandParameter(":id_etapa_caso", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.EtapaCaso.Id);
             NpgsqlDb.Instancia.AddCommandParameter(":id_proyecto", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.Proyecto.Id);
             NpgsqlDb.Instancia.AddCommandParameter(":id_responsable_des", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.ResponsableDesarrollo.Id);
             NpgsqlDb.Instancia.AddCommandParameter(":id_responsable_pru", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.ResponsablePruebas.Id);
            



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
