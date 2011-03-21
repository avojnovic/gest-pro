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
using GestPro.ControlObjects.ControlObjects;
using GestPro.BussinesObjects.BussinesObjects;

namespace GestPro
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminSesion.Instancia.Inicializar();

        }

        protected void BtnIniciar_Click(object sender, EventArgs e)
        {
            Recurso r=AdminRecurso.Instancia.verificarUsuario(TxtUsuario.Text, TxtPassword.Text);

            if (r != null)
            {

                FormsAuthentication.RedirectFromLoginPage(TxtUsuario.Text, false);
                AdminSesion.Instancia.UsuarioLogueado = r;
            }
            else
            {

                TxtAviso.Text = "Usuario o Contraseña incorrecto";
            }
        }
    }
}
