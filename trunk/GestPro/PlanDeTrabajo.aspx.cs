﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GestPro.BussinesObjects.BussinesObjects;
using GestPro.DataAccessObjects.DataAccessObjects;

namespace GestPro
{
    public partial class PlanDeTrabajo : System.Web.UI.Page
    {
        private Dictionary<long, GestPro.BussinesObjects.BussinesObjects.PlanDeTrabajo> _dicPlanDeTrabajo;
       public Dictionary<long, Caso> dicC;
       public Dictionary<long, Recurso> dicR;

        protected void Page_Load(object sender, EventArgs e)
        {
            dicC = CasoDAO.Instancia.obtenerTodosPendientesPlan();
            dicR = RecursoDAO.Instancia.obtenerTodos();

            cargarGrilla();
            cargarCombos();

            if (!IsPostBack)
            {

               
            }
        }

        private void cargarCombos()
        {
            
            CmbCaso.DataSource = dicC.Values.ToList();
            CmbCaso.DataTextField = "completo";
            CmbCaso.DataValueField = "id";
            CmbCaso.DataBind();

           
            CmbRecurso.DataSource = dicR.Values.ToList();

            CmbRecurso.DataTextField = "NombreCompleto";
            CmbRecurso.DataValueField = "id";
            CmbRecurso.DataBind();
        }

        protected void grid_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cargarGrilla();
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataBind();
        }

        private void cargarGrilla()
        {
            _dicPlanDeTrabajo = PlanTrabajoDAO.Instancia.obtenerTodos();

            GridView1.DataSource = _dicPlanDeTrabajo.Values.ToList();
            GridView1.DataBind();

        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            BussinesObjects.BussinesObjects.PlanDeTrabajo pt = new BussinesObjects.BussinesObjects.PlanDeTrabajo();

            pt.Caso = dicC[long.Parse(this.CmbCaso.SelectedValue)];
            pt.Recurso = dicR[long.Parse(this.CmbRecurso.SelectedValue)];

            pt.FechaInicio = (DateTime)dtFechaInicio.SelectedDate;
            pt.FechaFin = (DateTime)dtFechaFin.SelectedDate;

            pt.CantHoras = Convert.ToInt32(txtcanthoras.Text);


            PlanTrabajoDAO.Instancia.insertar(pt);

            dtFechaInicio.setDate(null);
            dtFechaFin.setDate(null);
            txtcanthoras.Text="";

        }

    }
}