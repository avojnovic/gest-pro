using System;
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
       public GestPro.BussinesObjects.BussinesObjects.PlanDeTrabajo _plan;

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            dicC = CasoDAO.Instancia.obtenerTodosPendientesPlan();
            dicR = RecursoDAO.Instancia.obtenerTodos();

            if (id != null && id != string.Empty)
            {
                 _plan = PlanTrabajoDAO.Instancia.obtenerPorId(long.Parse(id));

                if(!dicC.ContainsKey(_plan.Caso.Id))
                {
                    dicC.Add(_plan.Caso.Id, _plan.Caso);
                }
            }

            if (!IsPostBack)
            {
                cargarGrilla();
                cargarCombos();
                if (id != null && id!=string.Empty)
                {
                    cargarPlan();
                }

              
            }



        }

        private void cargarPlan()
        {
            if (_plan != null)
            {
                //this.CmbCaso.Items.Insert(0, new ListItem(_plan.Caso.completo,_plan.Caso.Id.ToString()));

                txtcanthoras.Text = _plan.CantHoras.ToString();
                CmbCaso.SelectedValue = _plan.Caso.Id.ToString() ;
                CmbRecurso.SelectedValue = _plan.Recurso.Id.ToString();
                dtFechaFin.setDate(_plan.FechaFin);
                dtFechaInicio.setDate(_plan.FechaInicio);

            }
        }

        private void cargarCombos()
        {
            
            CmbCaso.DataSource = dicC.Values.ToList();
            CmbCaso.DataTextField = "completo";
            CmbCaso.DataValueField = "id";


            

            CmbCaso.DataBind();
            this.CmbCaso.Items.Insert(0, new ListItem("", string.Empty));



           
            CmbRecurso.DataSource = dicR.Values.ToList();
            CmbRecurso.DataTextField = "NombreCompleto";
            CmbRecurso.DataValueField = "id";

           

            CmbRecurso.DataBind();
            this.CmbRecurso.Items.Insert(0, new ListItem("", string.Empty));
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

             string id = Request.QueryString["id"];

             if (id != null && id != string.Empty)
             {
                 pt.Id =Convert.ToInt64( id);
                 PlanTrabajoDAO.Instancia.Actualizar(pt);
             }
             else
             {
                 PlanTrabajoDAO.Instancia.insertar(pt);
             }

            

            dtFechaInicio.setDate(null);
            dtFechaFin.setDate(null);
            txtcanthoras.Text="";

            Response.Redirect("PlanDeTrabajo.aspx");
        }

    }
}