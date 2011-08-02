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
    public partial class RegistrosAvance : System.Web.UI.Page
    {
        private List<RegistroAvance> _dicRegAv;
        private Recurso UsuarioLogueado;

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogueado = (Recurso)Session["user"];

          

            if (!IsPostBack)
            {

                cargarGrilla();
            }
        }

        protected void grid_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cargarGrilla();
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataBind();
        }


        private void cargarGrilla()
        {
            string id = Request.QueryString["id"];
            string u = Request.QueryString["u"];


            if (id != null)
            {
                if (u != null)
                {
                    if (u == "1")
                    {
                        _dicRegAv = RegAvanceDAO.Instancia.obtenerRegAvanceCaso(Convert.ToInt64(id));
                    }
                    else
                    {
                        _dicRegAv = RegAvanceDAO.Instancia.obtenerRegAvanceProyecto(Convert.ToInt64(id));
                    }

                }
            }
            else
            {
                _dicRegAv = RegAvanceDAO.Instancia.obtenerTodosPorUsuario(UsuarioLogueado.Id);
            }

            GridView1.DataSource = _dicRegAv;
            GridView1.DataBind();

        }

    }
}