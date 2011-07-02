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
    public partial class CasosPendientes : System.Web.UI.Page
    {
        private Dictionary<long, Caso> _dicCasos;
        private Recurso UsuarioLogueado;
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogueado = (Recurso)Session["user"];

            if (!IsPostBack)
            {
               
                cargarGrilla();
            }

            if (UsuarioLogueado.Cargo.Perfil == Cargo.PerfilesEnum.Developer)
            {
              
                BtnNuevo.Visible = false;
            }

            if (UsuarioLogueado.Cargo.Perfil == Cargo.PerfilesEnum.Tester)
            {

            }


        }

        private void cargarGrilla()
        {

           Dictionary<long, Caso> _dicCasosTemp=new Dictionary<long,Caso>();
            
            _dicCasos=new Dictionary<long,Caso>();

            if (UsuarioLogueado.Cargo.Perfil == Cargo.PerfilesEnum.Tester)
           {
               _dicCasosTemp = CasoDAO.Instancia.obtenerTodos();
               foreach (Caso c in _dicCasosTemp.Values.ToList())
               {
                   if ((c.EtapaCaso.Id == 3 && c.ResponsablePruebas.Id == UsuarioLogueado.Id) || c.Responsable.Id == UsuarioLogueado.Id)//Prueba
                   {
                       _dicCasos.Add(c.Id, c);
                   }
               }
           }
           else
           {
               if (UsuarioLogueado.Cargo.Perfil == Cargo.PerfilesEnum.Developer)
               {
                   _dicCasosTemp = CasoDAO.Instancia.obtenerTodos();
                   foreach (Caso c in _dicCasosTemp.Values.ToList())
                   {
                       if ((c.EtapaCaso.Id == 2 && c.ResponsableDesarrollo.Id == UsuarioLogueado.Id) || c.Responsable.Id == UsuarioLogueado.Id)//Implementación
                       {
                           _dicCasos.Add(c.Id, c);
                       }
                   }
               }
               else
               {

                   _dicCasos = CasoDAO.Instancia.obtenerTodosPorResponsable(UsuarioLogueado);
               }
           }

            GridView1.DataSource = _dicCasos.Values.ToList();
            GridView1.DataBind();

        }



        protected void BtnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Edit_Caso.aspx");
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                long id = long.Parse(row.Cells[1].Text);

                Caso c = CasoDAO.Instancia.obtenerPorId(id);

                if (c != null)
                {

                    c.Borrado = true;
                    CasoDAO.Instancia.Actualizar(c);
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

               
                    Response.Redirect("Edit_Caso.aspx?id=" + id.ToString());

                
            }
        }
    }
}
