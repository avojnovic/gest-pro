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
    public partial class RegistrosAvanceAll : System.Web.UI.Page
    {
        private List<RegistroAvance> _dicRegAv;


        protected void Page_Load(object sender, EventArgs e)
        {
           
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

            _dicRegAv = RegAvanceDAO.Instancia.obtenerTodos();

            GridView1.DataSource = _dicRegAv;
            GridView1.DataBind();

        }
    }
}