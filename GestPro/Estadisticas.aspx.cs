using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using GestPro.BussinesObjects.BussinesObjects;
using System.Collections.Generic;
using GestPro.DataAccessObjects.DataAccessObjects;
using System.Web.UI.DataVisualization.Charting;

namespace GestPro
{
    public partial class Estadisticas : System.Web.UI.Page
    {
        Dictionary<long, Proyecto> _listaProyectos;

        Proyecto _proyecto;

        protected void Page_Load(object sender, EventArgs e)
        {
            _listaProyectos = ProyectosDAO.Instancia.obtenerTodos();
            
            if (!IsPostBack)
            {
                CmbProyectos.DataSource = _listaProyectos.Values.ToList();
                CmbProyectos.DataTextField = "Nombre";
                CmbProyectos.DataValueField = "Id";
                CmbProyectos.DataBind();

                setearEstiloChart();
            }

            cargarEstadisticas();

        }


        private void cargarEstadisticas()
        {
            int cant = 0;
            int cantPla = 0;
            int cantImpl = 0;
            int cantPrue = 0;
            int cantFin = 0;

            _proyecto = _listaProyectos[long.Parse(this.CmbProyectos.SelectedValue)]; ;


            if (_proyecto != null && _proyecto.ListaCasos!=null)
            {
                foreach (Caso c in _proyecto.ListaCasos)
                {
                    cant++;
                    if (c.EtapaCaso.Id == 1)
                        cantPla++;
                    if (c.EtapaCaso.Id == 2)
                        cantImpl++;
                    if (c.EtapaCaso.Id == 3)
                        cantPrue++;
                    if (c.EtapaCaso.Id == 4)
                        cantFin++;

                }
                
            }

            TxtCantCasos.Text = cant.ToString();
            TxtFin.Text = cantFin.ToString();
            TxtImple.Text = cantImpl.ToString();
            TxtPlan.Text = cantPla.ToString();
            TxtPrueb.Text = cantPrue.ToString();

            cargarChart();
        }

        protected void CmbProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEstadisticas();
        }

        private void cargarChart()
        {

            Series s = new Series();

            if (this.ChartCasos.Series.Count == 0)
            {
                this.ChartCasos.Series.Add(s);

                this.ChartCasos.Series[0].YValueMembers = "cantidad";
                this.ChartCasos.Series[0].XValueMember = "nombre";
                this.ChartCasos.Series[0].Name = "Cantidad";
                this.ChartCasos.Series[0]["PointWidth"] = "0.5";
                this.ChartCasos.Series[0].ToolTip = "Cantidad";
                this.ChartCasos.Series[0].IsValueShownAsLabel = true;
                this.ChartCasos.Series[0].LabelFormat = "N0";
                this.ChartCasos.Series[0].ChartType = SeriesChartType.Column;

                //double totalPlataformas = (from DataRow dr in dt.AsEnumerable() select Convert.ToDouble(dr["ns"])).Sum();
                DataTable detailsCasos = new DataTable();
                detailsCasos.Columns.Add("nombre");
                detailsCasos.Columns.Add("cantidad");
                detailsCasos.Columns.Add("porcent");

                DataRow row = detailsCasos.NewRow();
                row["nombre"] = "Planificación";
                row["cantidad"] = TxtPlan.Text;
                if (long.Parse(TxtCantCasos.Text) > 0)
                    row["porcent"] = (long.Parse(TxtPlan.Text) / long.Parse(TxtCantCasos.Text) * 100).ToString() + "%";
                else
                    row["porcent"] = "0%";

                detailsCasos.Rows.Add(row);

                DataRow row2 = detailsCasos.NewRow();
                row2["nombre"] = "Implementacion";
                row2["cantidad"] = TxtImple.Text;
                if (long.Parse(TxtCantCasos.Text) > 0)
                    row2["porcent"] = (long.Parse(TxtImple.Text) / long.Parse(TxtCantCasos.Text) * 100).ToString() + "%";
                else
                    row["porcent"] = "0%";
                detailsCasos.Rows.Add(row2);

                DataRow row3 = detailsCasos.NewRow();
                row3["nombre"] = "Prueba";
                row3["cantidad"] = TxtPrueb.Text;
                 if (long.Parse(TxtCantCasos.Text) > 0)
                    row3["porcent"] = (long.Parse(TxtPrueb.Text) / long.Parse(TxtCantCasos.Text) * 100).ToString() + "%";
                  else
                    row["porcent"] = "0%";
                detailsCasos.Rows.Add(row3);

                DataRow row4 = detailsCasos.NewRow();
                row4["nombre"] = "Finalizados";
                row4["cantidad"] = TxtFin.Text;

                if (long.Parse(TxtCantCasos.Text) > 0)
                    row4["porcent"] = (long.Parse(TxtFin.Text) / long.Parse(TxtCantCasos.Text) * 100).ToString() + "%";
                  else
                    row["porcent"] = "0%";
                detailsCasos.Rows.Add(row4);



                this.ChartCasos.ChartAreas[0].Area3DStyle.Enable3D = true;
                this.ChartCasos.DataSource = detailsCasos;
                this.ChartCasos.DataBind();
            }
        }

        private void setearEstiloChart()
        {

            //this.ChartCasos.Series[0]["CollectedThreshold"] = "10";
            //this.ChartCasos.Series[0]["CollectedThresholdUsePercent"] = "true";
            //this.ChartCasos.Series[0]["CollectedLegendText"] = "Others";
            //this.ChartCasos.Series[0]["CollectedSliceExploded"] = "true";
            //this.ChartCasos.Series[0]["CollectedToolTip"] = "Others";
            
            //this.ChartCasos.ChartAreas[0].Area3DStyle.Inclination = 60;
        }
       
    }
}
