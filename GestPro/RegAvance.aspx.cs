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
using GestPro.ControlObjects.ControlObjects;

namespace GestPro
{
    public partial class RegAvance : System.Web.UI.Page
    {
        long idVinculacion;
        bool caso;


        protected void Page_Load(object sender, EventArgs e)
        {
            idVinculacion = AdminRegAvance.Instancia._idVinculacion;
            caso = AdminRegAvance.Instancia.caso;
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
                AdminRegAvance.Instancia.insertar(r, idVinculacion, caso);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "CloseWindowScript", "window.close();", true);
            }

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "CloseWindowScript", "window.close();", true);
        }
    }
}
