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

namespace GestPro
{
    public partial class Estadisticas : System.Web.UI.Page
    {
        Dictionary<long, Proyecto> _listaProyectos;
        Dictionary<long, Caso> _listaCasos;
        Proyecto _proyecto;

        protected void Page_Load(object sender, EventArgs e)
        {
            _listaProyectos = ProyectosDAO.Instancia.obtenerTodos();
            
            if (!IsPostBack)
            {
                CmbProyectos.DataSource = _listaProyectos.Values.ToList();
                CmbProyectos.DataBind();
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
            
            foreach (Proyecto p in _listaProyectos.Values.ToList())
            {
                if (p.ToString() == CmbProyectos.SelectedItem.Text)
                {
                    _proyecto = p;
                    //if (_proyecto.ListaCasos == null)
                    //{
                    //    _listaCasos = AdminCaso.Instancia.obtenerTodosPorProyecto(_proyecto.Id);
                    //}
                    //else
                    //{ 
                        
                    //}
                    //break;
                }
            }


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

        }

        protected void CmbProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEstadisticas();
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
