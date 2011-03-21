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
    public partial class CasosPendientes : System.Web.UI.Page
    {
        private Dictionary<long, Caso> _dicCasos;

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminCaso.Instancia.todos = false;

            if (!IsPostBack)
            {
                BtnBorrar.Attributes.Add("OnClick", "javascript:if(confirm('Esta seguro que desea borrar el Caso')== false) return false;");

                cargarGrilla();
            }

            if (AdminSesion.Instancia.UsuarioLogueado.Cargo.Perfil == Cargo.PerfilesEnum.Developer)
            {
                BtnBorrar.Visible = false;
                BtnNuevo.Visible = false;
            }

            if (AdminSesion.Instancia.UsuarioLogueado.Cargo.Perfil == Cargo.PerfilesEnum.Tester)
            {
                BtnBorrar.Visible = false;
            }


        }

        private void cargarGrilla()
        {

           Dictionary<long, Caso> _dicCasosTemp=new Dictionary<long,Caso>();
            
            _dicCasos=new Dictionary<long,Caso>();
          
           if (AdminSesion.Instancia.UsuarioLogueado.Cargo.Perfil == Cargo.PerfilesEnum.Tester)
           {
               _dicCasosTemp = AdminCaso.Instancia.obtenerTodos();
               foreach (Caso c in _dicCasosTemp.Values.ToList())
               {
                   if ((c.EtapaCaso.Id == 3 && c.ResponsablePruebas.Id == AdminSesion.Instancia.UsuarioLogueado.Id) || c.Responsable.Id == AdminSesion.Instancia.UsuarioLogueado.Id)//Prueba
                   {
                       _dicCasos.Add(c.Id, c);
                   }
               }
           }
           else
           {
               if (AdminSesion.Instancia.UsuarioLogueado.Cargo.Perfil == Cargo.PerfilesEnum.Developer)
               {
                   _dicCasosTemp = AdminCaso.Instancia.obtenerTodos();
                   foreach (Caso c in _dicCasosTemp.Values.ToList())
                   {
                       if ((c.EtapaCaso.Id == 2 && c.ResponsableDesarrollo.Id == AdminSesion.Instancia.UsuarioLogueado.Id)|| c.Responsable.Id == AdminSesion.Instancia.UsuarioLogueado.Id)//Implementación
                       {
                           _dicCasos.Add(c.Id, c);
                       }
                   }
               }
               else
               {

                   _dicCasos = AdminCaso.Instancia.obtenerTodosPorResponsable(AdminSesion.Instancia.UsuarioLogueado);
               }
           }

            GridView1.DataSource = _dicCasos.Values.ToList();
            GridView1.DataBind();

        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
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

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                long id = long.Parse(row.Cells[1].Text);

                Caso c =AdminCaso.Instancia.obtenerPorId(id);

                if (c != null)
                {
                    AdminCaso.Instancia._casoEdit = c;
                    Response.Redirect("Edit_Caso.aspx");
                }
            }
        }
    }
}
