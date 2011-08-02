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
   public class PlanTrabajoDAO
    {
         #region Singleton
        private static PlanTrabajoDAO Instance = null;
        private PlanTrabajoDAO() 
        {
            
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new PlanTrabajoDAO();
            }
        }

        public static PlanTrabajoDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion

        public Dictionary<long, PlanDeTrabajo> obtenerTodos()
        {

            string sql = "";
            sql += " SELECT * FROM plan_de_trabajo where borrado=false;";

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, PlanDeTrabajo> dicPlan = new Dictionary<long, PlanDeTrabajo>();

            while (dr.Read())
            {
                PlanDeTrabajo c = new PlanDeTrabajo();
                LoadFromDataReader(dr, c);

                if (!dicPlan.ContainsKey(c.Id))
                    dicPlan.Add(c.Id, c);
            }


            return dicPlan;

        }

        public Dictionary<long, PlanDeTrabajo> obtenerTodosParaGrilla()
        {
            string sql= @"SELECT max(id) as id, min(fecha_inicio) as fecha_inicio, max(fecha_fin) as fecha_fin,id_recurso,
                        max(id_caso) as id_caso,max(cantidad_horas) as cantidad_horas
                        
                        FROM plan_de_trabajo where borrado=false group by id_recurso;";

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, PlanDeTrabajo> dicPlan = new Dictionary<long, PlanDeTrabajo>();

            while (dr.Read())
            {
                PlanDeTrabajo c = new PlanDeTrabajo();
                LoadFromDataReader(dr, c);

                if (!dicPlan.ContainsKey(c.Id))
                    dicPlan.Add(c.Id, c);
            }


            return dicPlan;
        }

        private static void LoadFromDataReader(NpgsqlDataReader dr, PlanDeTrabajo c)
        {

            if (!dr.IsDBNull(dr.GetOrdinal("id")))
                c.Id = long.Parse(dr["id"].ToString());

            if (!dr.IsDBNull(dr.GetOrdinal("id_caso")))
                c.Caso = CasoDAO.Instancia.obtenerPorId(long.Parse(dr["id_caso"].ToString()));

            if (!dr.IsDBNull(dr.GetOrdinal("id_recurso")))
                c.Recurso = RecursoDAO.Instancia.obtenerRecursoPorId(long.Parse(dr["id_recurso"].ToString()));

            if (!dr.IsDBNull(dr.GetOrdinal("cantidad_horas")))
                c.CantHoras = float.Parse(dr["cantidad_horas"].ToString());


            if (!dr.IsDBNull(dr.GetOrdinal("fecha_inicio")))
                c.FechaInicio = dr.GetDateTime(dr.GetOrdinal("fecha_inicio"));

            if (!dr.IsDBNull(dr.GetOrdinal("fecha_fin")))
                c.FechaFin = dr.GetDateTime(dr.GetOrdinal("fecha_fin"));

            c.Borrado = false;
        }

        public long insertar(PlanDeTrabajo c)
        {
            long insertID = 0;
            string queryStr;


            queryStr = @"INSERT INTO plan_de_trabajo(
            fecha_inicio, fecha_fin, cantidad_horas, borrado, id_recurso,id_caso)
            VALUES ( :fecha_inicio, :fecha_fin, :cantidad_horas, :borrado, :id_recurso,:id_caso);
            select currval('plan_de_trabajo_id_seq');";


            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            
            NpgsqlDb.Instancia.AddCommandParameter(":fecha_inicio", NpgsqlDbType.Timestamp, ParameterDirection.Input, false, c.FechaInicio);
            NpgsqlDb.Instancia.AddCommandParameter(":fecha_fin", NpgsqlDbType.Timestamp, ParameterDirection.Input, false, c.FechaFin);

            NpgsqlDb.Instancia.AddCommandParameter(":cantidad_horas", NpgsqlDbType.Numeric, ParameterDirection.Input, false, c.CantHoras);
            NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, c.Borrado);

            NpgsqlDb.Instancia.AddCommandParameter(":id_recurso", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.Recurso.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":id_caso", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.Caso.Id);
           

            try
            {

                insertID = NpgsqlDb.Instancia.ExecuteScalar();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }

            return insertID;
        }


        public void Actualizar(PlanDeTrabajo c)
        {

            string queryStr;


            queryStr = @" UPDATE plan_de_trabajo
               SET  fecha_inicio=:fecha_inicio, fecha_fin=:fecha_fin, cantidad_horas=:cantidad_horas, borrado=:borrado, 
                   id_recurso=:id_recurso, id_caso=:id_caso
            WHERE id=:id;";




            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id", NpgsqlDbType.Integer, ParameterDirection.Input, false, c.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":fecha_inicio", NpgsqlDbType.Timestamp, ParameterDirection.Input, false, c.FechaInicio);
            NpgsqlDb.Instancia.AddCommandParameter(":fecha_fin", NpgsqlDbType.Timestamp, ParameterDirection.Input, false, c.FechaFin);

            NpgsqlDb.Instancia.AddCommandParameter(":cantidad_horas", NpgsqlDbType.Numeric, ParameterDirection.Input, false, c.CantHoras);
            NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, c.Borrado);

            NpgsqlDb.Instancia.AddCommandParameter(":id_recurso", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.Recurso.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":id_caso", NpgsqlDbType.Bigint, ParameterDirection.Input, false, c.Caso.Id);
           



            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }

        }


        public PlanDeTrabajo obtenerPorId(long p)
        {
            string sql = " SELECT * FROM plan_de_trabajo where borrado=false and id='" + p.ToString() + "'";

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, PlanDeTrabajo> dicPlan = new Dictionary<long, PlanDeTrabajo>();

            PlanDeTrabajo c = new PlanDeTrabajo();

            while (dr.Read())
            {
               
                LoadFromDataReader(dr, c);

              
            }


            return c;
        }

       
    }
}
