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
using System.Collections.Generic;
using GestPro.DataAccessObjects.DataAccessObjects;


namespace GestPro
{
    public partial class Edit_Caso : System.Web.UI.Page
    {
        Caso _caso;
        ModosEdicionEnum _modoApertura = new ModosEdicionEnum();
        Dictionary<long, Proyecto> _listaProyectos;
        Dictionary<long, Recurso> _listaRecursos;
        Dictionary<long, EtapaCaso> _listaEtapas;
        Dictionary<long, TipoCaso> _listaTipos;
        static string prevPage = String.Empty;
        private Recurso UsuarioLogueado;

        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["id"];

            if (id != null)
            {
                _caso = CasoDAO.Instancia.obtenerPorId(long.Parse(id));
            }

            if (_caso != null)
            {
                _modoApertura = ModosEdicionEnum.Modificar;
            }
            else
            {
                _modoApertura = ModosEdicionEnum.Nuevo;
                BtnRegAvance.Visible = false;
                TxtResponsable.Text = UsuarioLogueado.ToString();
            }

           

             _listaProyectos =ProyectosDAO.Instancia.obtenerTodos();
             _listaRecursos = RecursoDAO.Instancia.obtenerTodos();
            _listaEtapas=CasoDAO.Instancia.obtenerEtapas();
            _listaTipos = CasoDAO.Instancia.obtenerTipos();

            UsuarioLogueado = (Recurso)Session["user"];

             if (!IsPostBack)
             {
                 prevPage = Request.UrlReferrer.ToString();
                

                 CmbEtapa.DataSource = _listaEtapas.Values.ToList();
                 CmbEtapa.DataBind();

                 CbmProyecto.DataSource = _listaProyectos.Values.ToList();
                 CbmProyecto.DataBind();

                 CmbRespDesarrollo.DataSource = _listaRecursos.Values.ToList();
                 CmbRespDesarrollo.DataBind();

                 CmbRespPruebas.DataSource = _listaRecursos.Values.ToList();
                 CmbRespPruebas.DataBind();

                 CmbTipo.DataSource =_listaTipos.Values.ToList();
                 CmbTipo.DataBind();

                  cargarCaso();
             }
        }

        private void cargarCaso()
        {
            if (_caso != null)
            {
                TxtDescImplementacion.Text = _caso.DescripcionImplementacion;
                TxtDescripcion.Text = _caso.Descripcion;
                TxtDescripcionPruebas.Text = _caso.DescripcionPruebas;
                TxtFechaEntrega.Text = _caso.FechaEntrega.ToString();
                TxtNroCaso.Text = _caso.NroCaso.ToString();
                TxtPrioridad.Text = _caso.Prioridad.ToString();
                TxtResponsable.Text = _caso.Responsable.ToString();
                TxtTiempoEstimado.Text = _caso.TiempoEstimado.ToString();
                TxtTiempoRestante.Text = _caso.TiempoRestante.ToString();

                CbmProyecto.SelectedValue = _listaProyectos[_caso.Proyecto.Id].ToString();
                CmbEtapa.SelectedValue =_listaEtapas[_caso.EtapaCaso.Id].ToString();
                CmbRespDesarrollo.SelectedValue = _listaRecursos[_caso.ResponsableDesarrollo.Id].ToString();
                CmbRespPruebas.SelectedValue = _listaRecursos[_caso.ResponsablePruebas.Id].ToString();
                CmbTipo.SelectedValue = _listaTipos[_caso.TipoCaso.Id].ToString();


            }
            else
            {
                _modoApertura = ModosEdicionEnum.Nuevo;
            }
        }

        private void setearObjeto()
        {

            if (_caso == null)
                _caso = new Caso();

           

             _caso.DescripcionImplementacion=TxtDescImplementacion.Text;
             _caso.Descripcion = TxtDescripcion.Text;
             _caso.DescripcionPruebas = TxtDescripcionPruebas.Text;
             _caso.FechaEntrega =DateTime.Parse( TxtFechaEntrega.Text);
            
             _caso.Prioridad=int.Parse(TxtPrioridad.Text);
             _caso.Responsable =UsuarioLogueado;

             _caso.TiempoEstimado = float.Parse(TxtTiempoEstimado.Text);
             _caso.TiempoRestante = float.Parse(TxtTiempoRestante.Text);


             foreach (Recurso r in _listaRecursos.Values.ToList())
             {
                 if (r.ToString() == CmbRespDesarrollo.SelectedItem.Text)
                 {
                     _caso.ResponsableDesarrollo = r;
                     
                 }

                 if (r.ToString() == CmbRespPruebas.SelectedItem.Text)
                 {
                     _caso.ResponsablePruebas = r;

                 }

             }

             foreach (Proyecto p in _listaProyectos.Values.ToList())
             {
                 if (p.ToString() == CbmProyecto.SelectedItem.Text)
                 {
                     _caso.Proyecto = p;
                     break;
                 }
             }

             foreach (EtapaCaso p in _listaEtapas.Values.ToList())
             {
                 if (p.ToString() == CmbEtapa.SelectedItem.Text)
                 {
                     _caso.EtapaCaso = p;
                     break;
                 }
             }

             foreach (TipoCaso p in _listaTipos.Values.ToList())
             {
                 if (p.ToString() == CmbTipo.SelectedItem.Text)
                 {
                     _caso.TipoCaso = p;
                     break;
                 }
             }

           
         

        }

        protected void BtnRegAvance_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("RegAvance.aspx?id=" + _caso.Id.ToString());

            string url = "RegAvance.aspx";
            ClientScript.RegisterStartupScript(this.GetType(), "newWindow", string.Format("<script>window.open('{0}');</script>", url));

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            long NroCaso = 0;
            if (_modoApertura == ModosEdicionEnum.Nuevo)
            {
                setearObjeto();
                NroCaso=CasoDAO.Instancia.insertar(_caso);
                TxtNroCaso.Text = NroCaso.ToString();
            }
            else
            {
                if (_modoApertura == ModosEdicionEnum.Modificar)
                {
                    setearObjeto();
                    CasoDAO.Instancia.Actualizar(_caso);
                }
            }

            //AdminCaso.Instancia._casoEdit = null;
            //if(AdminCaso.Instancia.todos == true)
            //    Response.Redirect("Casos.aspx");
            //else
            //    Response.Redirect("CasosPendientes.aspx");
        }

        

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {

           Response.Redirect(prevPage);
 
        }
    }
}
