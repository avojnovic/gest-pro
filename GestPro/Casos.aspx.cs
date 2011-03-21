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
using GestPro.ControlObjects.ControlObjects;
using GestPro.BussinesObjects.BussinesObjects;
using System.Collections.Generic;

namespace GestPro
{
    public partial class Casos1 : System.Web.UI.Page
    {
        private Dictionary<long, Caso> _dicCasos;
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminCaso.Instancia.todos = true;

            if (!IsPostBack)
            {
                BtnBorrar.Attributes.Add("OnClick", "javascript:if(confirm('Esta seguro que desea borrar el Caso')== false) return false;");

                cargarGrilla();
            }
        }

        private void cargarGrilla()
        {
            _dicCasos = AdminCaso.Instancia.obtenerTodos();

            GridView1.DataSource = _dicCasos.Values.ToList();
            GridView1.DataBind();

        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                long id = long.Parse(row.Cells[1].Text);

                Caso c = AdminCaso.Instancia.obtenerPorId(id);

                if (c != null)
                {
                    AdminCaso.Instancia._casoEdit = c;
                    Response.Redirect("Edit_Caso.aspx");
                }
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            AdminCaso.Instancia._casoEdit = null;
            Response.Redirect("Edit_Caso.aspx");
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                long id = long.Parse(row.Cells[1].Text);

                Caso c = AdminCaso.Instancia.obtenerPorId(id);

                if (c != null)
                {

                    c.Borrado = true;
                    AdminCaso.Instancia.actualizar(c);
                    Response.Redirect("CasosPendientes.aspx");
                }
            }
            else
            {

            }
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
