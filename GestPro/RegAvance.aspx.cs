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
using GestPro.DataAccessObjects.DataAccessObjects;


namespace GestPro
{
    public partial class RegAvance : System.Web.UI.Page
    {
        long idVinculacion;
        bool caso;
        static string prevPage = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                prevPage = Request.UrlReferrer.ToString();
            }

            if(prevPage.ToUpper().Contains("CASO"))
            {
                caso = true;
            }
            else
            {
                 caso= false;
            }
            idVinculacion =long.Parse( Request.QueryString["id"]);

        
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            bool error = false;

            RegistroAvance r = new RegistroAvance();
            r.Borrado = false;
            r.Descripcion = TxtDescripcion.Text;

            try
            {
                r.Tiempo = float.Parse(TxtTiempo.Text);
            }
            catch
            { 
                error= true;
                LblError.Text = "Error, ingrese un tiempo con formato numerico";
                //global::System.Windows.Forms.MessageBox.Show("Error en campo Tiempo");
            }

            if (!error)
            {
                LblError.Text = "";
                RegAvanceDAO.Instancia.insertar(r, idVinculacion, caso);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "CloseWindowScript", "window.close();", true);
            }

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "CloseWindowScript", "window.close();", true);
        }
    }
}
