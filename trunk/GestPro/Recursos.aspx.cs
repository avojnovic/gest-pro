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
using GestPro.DataAccessObjects.DataAccessObjects;

namespace GestPro
{
    public partial class Recursos : System.Web.UI.Page
    {
        private Dictionary<long, Recurso> _dicRecursos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BtnBorrar.Attributes.Add("OnClick", "javascript:if(confirm('Esta seguro que desea borrar el Recurso')== false) return false;");

                cargarGrilla();
            }
        }


        private void cargarGrilla()
        {
            _dicRecursos = RecursoDAO.Instancia.obtenerTodos();

            GridView1.DataSource = _dicRecursos.Values.ToList();
            GridView1.DataBind();

        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                long id = long.Parse(row.Cells[1].Text);

                Response.Redirect("Edit_Recurso.aspx?id="+id.ToString());

                
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit_Recurso.aspx");
        }

    }
}
