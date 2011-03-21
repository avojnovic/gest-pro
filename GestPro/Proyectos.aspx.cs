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
using System.Collections.Generic;
using GestPro.BussinesObjects.BussinesObjects;
using GestPro.ControlObjects.ControlObjects;

namespace GestPro
{
    public partial class Proyectos : System.Web.UI.Page
    {
        private Dictionary<long, Proyecto> _dicProyectos;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BtnBorrar.Attributes.Add("OnClick", "javascript:if(confirm('Esta seguro que desea borrar el proyecto')== false) return false;");

                cargarGrilla();
            }
        }


        private void cargarGrilla()
        {
            _dicProyectos = AdminProyecto.Instancia.obtenerTodos();

            GridView1.DataSource = _dicProyectos.Values.ToList();
            GridView1.DataBind();
            
        }

        protected void GrillaProyectos_Load(object sender, EventArgs e)
        {
             
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                long id = long.Parse(row.Cells[1].Text);

                Proyecto p = AdminProyecto.Instancia.obtenerRecursoPorId(id);

                if (p != null)
                {
                    AdminProyecto.Instancia._proyectoEdit = p;
                    Response.Redirect("Edit_Proyecto.aspx");
                }
            }
 
        }



        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            AdminProyecto.Instancia._proyectoEdit = null;
            Response.Redirect("Edit_Proyecto.aspx");
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                long id = long.Parse(row.Cells[1].Text);

                Proyecto p = AdminProyecto.Instancia.obtenerRecursoPorId(id);

                if (p != null)
                {

                    p.Borrado = true;
                    AdminProyecto.Instancia.actualizar(p);
                    Response.Redirect("Proyectos.aspx");
                }
            }
            else
            {

            }
        }
    }
}
