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
using GestPro.BussinesObjects;
using GestPro.BussinesObjects.BussinesObjects;
using System.Collections.Generic;
using GestPro.DataAccessObjects.DataAccessObjects;


namespace GestPro
{
    public partial class Principal : System.Web.UI.Page
    {
        
        private Dictionary<long, Caso> _dicCasos;
        private Recurso UsuarioLogueado;

        protected void Page_Load(object sender, EventArgs e)
        {

            UsuarioLogueado = (Recurso)Session["user"];

            if (!IsPostBack)
            {

                this.Title = "Gestión de Proyectos";

                if (!IsPostBack)
                {

                    cargarGrilla();
                }


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
    }
}
