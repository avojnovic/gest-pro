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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sesion.Instancia.Inicializar();

        }

        protected void BtnIniciar_Click(object sender, EventArgs e)
        {
            Recurso r = RecursoDAO.Instancia.verificarUsuario(TxtUsuario.Text, TxtPassword.Text);

            if (r != null)
            {

                Session["user"] = r;
                FormsAuthentication.RedirectFromLoginPage(TxtUsuario.Text, false);

            }
            else
            {

                TxtAviso.Text = "Usuario o Contraseña incorrecto";
            }
        }
    }
}
