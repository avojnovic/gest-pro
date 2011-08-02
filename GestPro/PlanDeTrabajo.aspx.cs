using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GestPro.BussinesObjects.BussinesObjects;
using GestPro.DataAccessObjects.DataAccessObjects;
using System.Data;
using Telerik.Charting;

namespace GestPro
{
    public partial class PlanDeTrabajo : System.Web.UI.Page
    {
        private Dictionary<long, GestPro.BussinesObjects.BussinesObjects.PlanDeTrabajo> _dicPlanDeTrabajo;
       public Dictionary<long, Caso> dicC;
       public Dictionary<long, Recurso> dicR;
       public GestPro.BussinesObjects.BussinesObjects.PlanDeTrabajo _plan;
       public int value = 0;
       public string label = "";



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

            _dicPlanDeTrabajo = PlanTrabajoDAO.Instancia.obtenerTodosParaGrilla();
            cargarRadChart(_dicPlanDeTrabajo);
        }

        private void cargarRadChart(Dictionary<long, BussinesObjects.BussinesObjects.PlanDeTrabajo> _dicPlanDeTrabajo)
        {
            RadChartCasos.ItemDataBound += new EventHandler<ChartItemDataBoundEventArgs>(RadChartCasos_ItemDataBound);
            RadChartCasos.SeriesOrientation = ChartSeriesOrientation.Horizontal;


            ChartSeries series = new ChartSeries();
            series.Name = "Tiempo";
            series.Type = ChartSeriesType.Gantt;
            series.Appearance.LabelAppearance.Visible = false;
            series.DataYColumn = "EndDate";
            series.DataYColumn2 = "StartDate";
            series.DataXColumn = "MemberID";
            series.Appearance.BarWidthPercent = 20;

            series.Appearance.FillStyle.FillType = Telerik.Charting.Styles.FillType.Solid;
            //series.Appearance.FillStyle.MainColor = System.Drawing.Color.Red; 
            
            

            RadChartCasos.Series.Add(series);

            RadChartCasos.PlotArea.YAxis.IsZeroBased = false;
            RadChartCasos.PlotArea.YAxis.Appearance.LabelAppearance.RotationAngle = 90;
            RadChartCasos.PlotArea.YAxis.Appearance.ValueFormat = Telerik.Charting.Styles.ChartValueFormat.ShortDate;
            RadChartCasos.PlotArea.XAxis.AutoScale = false;

            RadChartCasos.Legend.Visible = false;

             

            //RadChartCasos.PlotArea.YAxis.Appearance.CustomFormat = "ddd, MMM dd";

            //RadChartCasos.PlotArea.YAxis.Appearance.LabelAppearance.Position.AlignedPosition = Telerik.Charting.Styles.AlignedPositions.Top;
            //RadChartCasos.Series.Clear();
            //RadChartCasos.PlotArea.XAxis.DataLabelsColumn = "Name";
           
            RadChartCasos.DataSource= CreateSource(_dicPlanDeTrabajo);
            RadChartCasos.AutoLayout = true;
            RadChartCasos.DataBind();

            //foreach (ChartSeriesItem item in RadChartCasos.Series[0].Items)
            //{
            //    item.Appearance.FillStyle.MainColor = System.Drawing.Color.Red;
           
            //}
        }


        void RadChartCasos_ItemDataBound(object sender, ChartItemDataBoundEventArgs e)
        {

            string memberName = (e.DataItem as DataRowView)["MemberName"].ToString();
            string memberID = (e.DataItem as DataRowView)["MemberID"].ToString();

            if (memberName != label)
            {
                label = memberName;
                ChartAxisItem axisItem = new ChartAxisItem(label);
                //axisItem.Value = ++value;
                axisItem.Value =Convert.ToDecimal( memberID);
                RadChartCasos.PlotArea.XAxis.Items.Add(axisItem);
            }

        }



        private DataTable CreateSource(Dictionary<long, BussinesObjects.BussinesObjects.PlanDeTrabajo> _dicPlanDeTrabajo)
        {
            DataTable dt = new DataTable();
            DataColumn col = new DataColumn("MemberID");
            col.DataType = typeof(int);
            dt.Columns.Add(col);
            col = new DataColumn("MemberName");
            col.DataType = typeof(string);
            dt.Columns.Add(col);
            col = new DataColumn("StartDate");
            col.DataType = typeof(string);
            dt.Columns.Add(col);
            col = new DataColumn("EndDate");
            col.DataType = typeof(string);
            dt.Columns.Add(col);


            foreach (BussinesObjects.BussinesObjects.PlanDeTrabajo p in _dicPlanDeTrabajo.Values.ToList())
            {

                if (p.FechaInicio.ToShortDateString() == p.FechaFin.ToShortDateString())
                {
                    dt.Rows.Add(new object[] { p.Recurso.Id, p.Recurso.NombreCompleto, p.FechaInicio.ToOADate(), p.FechaFin.AddDays(1).ToOADate() });
                    
                   
                }
                else
                {
                    dt.Rows.Add(new object[] { p.Recurso.Id, p.Recurso.NombreCompleto, p.FechaInicio.ToOADate(), p.FechaFin.ToOADate() });
                   
                }
            }

            return dt;
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
