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

namespace GestPro
{
    public partial class Master : System.Web.UI.MasterPage
    {
        private Recurso UsuarioLogueado;

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogueado = (Recurso)Session["user"];


            if (!IsPostBack)
            {

                if (!Page.Request.Url.ToString().ToLower().Contains("login.aspx") && !Page.Request.Url.ToString().ToLower().Contains("error.aspx"))
                {

                    if (UsuarioLogueado == null)
                    {
                        Response.Redirect("login.aspx");
                    }
                    else
                    {
                        this.divMenu.Visible = true;
                        generarMenu();
                    }
                }
                else
                {
                    this.divMenu.Visible = false;
                }

            }


        }



        private void generarMenu()
        {
            //PROYECTOS
            if ((UsuarioLogueado.Cargo.Perfil == GestPro.BussinesObjects.BussinesObjects.Cargo.PerfilesEnum.ProyectManager) || (UsuarioLogueado.Cargo.Perfil == GestPro.BussinesObjects.BussinesObjects.Cargo.PerfilesEnum.TeamLeader))
            {
                MenuItem it1 = new MenuItem("Proyectos");

                //it1.NavigateUrl = "Proyectos.aspx";
                MenuItem itv = new MenuItem("Ver");
                itv.Value = "Proyectos";
                itv.NavigateUrl = "Proyectos.aspx";
                it1.ChildItems.Add(itv);

                MenuItem it2 = new MenuItem("Nuevo");
                it2.Value = "ProyectosNuevo";
                it2.NavigateUrl = "Edit_Proyecto.aspx";
                it1.ChildItems.Add(it2);

                MenuItem ite = new MenuItem("Estadisticas");
                ite.Value = "Estadisticas";
                ite.NavigateUrl = "Estadisticas.aspx";
                it1.ChildItems.Add(ite);

                Menu1.Items.Add(it1);
            }

            if (UsuarioLogueado.Cargo.Perfil == GestPro.BussinesObjects.BussinesObjects.Cargo.PerfilesEnum.ProyectManager)
            {
                //RECURSOS
                MenuItem it3 = new MenuItem("Recursos");


                MenuItem itv2 = new MenuItem("ver");
                itv2.Value = "Recursos";
                itv2.NavigateUrl = "Recursos.aspx";
                it3.ChildItems.Add(itv2);

                MenuItem it4 = new MenuItem("Nuevo");
                it4.Value = "RecursosNuevo";
                it4.NavigateUrl = "Edit_Recurso.aspx";
                it3.ChildItems.Add(it4);
                Menu1.Items.Add(it3);
            }

            //CASOS
            MenuItem it5 = new MenuItem("Casos");
            it5.Value = "Casos";
            //it5.NavigateUrl = "Casos.aspx";
            if (UsuarioLogueado.Cargo.Perfil != GestPro.BussinesObjects.BussinesObjects.Cargo.PerfilesEnum.Developer)
            {
                MenuItem it6 = new MenuItem("Nuevo");
                it6.Value = "CasosNuevo";
                it6.NavigateUrl = "Edit_Caso.aspx";
                it5.ChildItems.Add(it6);
            }
            if ((UsuarioLogueado.Cargo.Perfil == GestPro.BussinesObjects.BussinesObjects.Cargo.PerfilesEnum.ProyectManager) || (UsuarioLogueado.Cargo.Perfil == GestPro.BussinesObjects.BussinesObjects.Cargo.PerfilesEnum.TeamLeader))
            {
                MenuItem it8 = new MenuItem("Todos");
                it8.Value = "Casos";
                it8.NavigateUrl = "Casos.aspx";
                it5.ChildItems.Add(it8);
            }

            MenuItem it7 = new MenuItem("Mis Pendientes");
            it7.Value = "CasosPendiente";
            it7.NavigateUrl = "CasosPendientes.aspx";

            it5.ChildItems.Add(it7);
            Menu1.Items.Add(it5);






            //CERRAR SESION
            MenuItem itc = new MenuItem("Cerrar Sesión");
            itc.Value = "Cerrar";
            itc.NavigateUrl = "Login.aspx";
            Menu1.Items.Add(itc);


            //USUARIO LOGUEADO
            string userName = UsuarioLogueado.Nombre + " " + UsuarioLogueado.Apellido;
            userName = "Usuario Logueado: " + userName + " / " + UsuarioLogueado.Cargo.Nombre;
            MenuItem user = new MenuItem(userName);
            user.Selectable = false;
            Menu1.Items.Add(user);
        }
        protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            //switch (e.Item.Value)
            //{

            //    case "Proyectos":
            //        Response.Redirect("Proyectos.aspx");
            //        break;
            //    case "ProyectosNuevo":
            //        Response.Redirect("Edit_Proyecto.aspx");
            //        break;
            //    case "Recursos":
            //        Response.Redirect("Recursos.aspx");
            //        break;
            //    case "RecursosNuevo":
            //        Response.Redirect("Edit_Recurso.aspx");
            //        break;
            //    case "Clientes":
            //        break;
            //    case "Cerrar":
            //        FormsAuthentication.SignOut();
            //        FormsAuthentication.RedirectToLoginPage();
            //        break;

            //}
        }
    }
}
