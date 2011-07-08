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
            UsuarioLogueado = (Recurso)Session["user"];

            if (id != null)
            {
                _caso = CasoDAO.Instancia.obtenerPorId(long.Parse(id));
            }

            if (_caso != null)
            {
                _modoApertura = ModosEdicionEnum.Modificar;
                BtnBorrar.Visible = true;
            }
            else
            {
                ModalPanel.Visible = false;
                _modoApertura = ModosEdicionEnum.Nuevo;
                BtnRegAvance.Visible = false;
                TxtResponsable.Text = UsuarioLogueado.ToString();
                BtnBorrar.Visible = false;
            }

           

             _listaProyectos =ProyectosDAO.Instancia.obtenerTodos();
             _listaRecursos = RecursoDAO.Instancia.obtenerTodos();
            _listaEtapas=CasoDAO.Instancia.obtenerEtapas();
            _listaTipos = CasoDAO.Instancia.obtenerTipos();

          

             if (!IsPostBack)
             {

                BtnBorrar.Attributes.Add("OnClick", "javascript:if(confirm('Esta seguro que desea borrar el Caso')== false) return false;");

                 if (Request.UrlReferrer!=null)
                     prevPage = Request.UrlReferrer.ToString();
                 else
                     prevPage="";

                 CmbEtapa.DataSource = _listaEtapas.Values.ToList();
                 CmbEtapa.DataTextField = "Nombre";
                 CmbEtapa.DataValueField = "Id";
                 CmbEtapa.DataBind();

                 CbmProyecto.DataSource = _listaProyectos.Values.ToList();
                 CbmProyecto.DataTextField = "Nombre";
                 CbmProyecto.DataValueField = "Id";
                 CbmProyecto.DataBind();

                 CmbRespDesarrollo.DataSource = _listaRecursos.Values.ToList();
                 CmbRespDesarrollo.DataTextField = "NombreCompleto";
                 CmbRespDesarrollo.DataValueField = "Id";
                 CmbRespDesarrollo.DataBind();

                 CmbRespPruebas.DataSource = _listaRecursos.Values.ToList();
                 CmbRespPruebas.DataTextField = "NombreCompleto";
                 CmbRespPruebas.DataValueField = "Id";
                 CmbRespPruebas.DataBind();

                 CmbTipo.DataSource =_listaTipos.Values.ToList();
                 CmbTipo.DataTextField = "Nombre";
                 CmbTipo.DataValueField = "Id";
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
                dtFechaEntrega.setDate(_caso.FechaEntrega);
                TxtNroCaso.Text = _caso.NroCaso.ToString();
                TxtPrioridad.Text = _caso.Prioridad.ToString();
                TxtResponsable.Text = _caso.Responsable.ToString();
                TxtTiempoEstimado.Text = _caso.TiempoEstimado.ToString();
                TxtTiempoRestante.Text = _caso.TiempoRestante.ToString();

                CbmProyecto.SelectedValue = _caso.Proyecto.Id.ToString();
                CmbEtapa.SelectedValue =_caso.EtapaCaso.Id.ToString();
                CmbRespDesarrollo.SelectedValue =_caso.ResponsableDesarrollo.Id.ToString();
                CmbRespPruebas.SelectedValue = _caso.ResponsablePruebas.Id.ToString();
                CmbTipo.SelectedValue = _caso.TipoCaso.Id.ToString();


            }
            else
            {
                _modoApertura = ModosEdicionEnum.Nuevo;
            }
        }

        private void setearObjeto()
        {


              _caso = new Caso();

             string id = Request.QueryString["id"];

             if (id != null && id != string.Empty)
             {
                 _caso.Id = Convert.ToInt64(id);
             }

             _caso.DescripcionImplementacion=TxtDescImplementacion.Text;
             _caso.Descripcion = TxtDescripcion.Text;
             _caso.DescripcionPruebas = TxtDescripcionPruebas.Text;
             _caso.FechaEntrega =dtFechaEntrega.SelectedDate;


             _caso.Prioridad=int.Parse(TxtPrioridad.Text);
             //_caso.Responsable =UsuarioLogueado;

             _caso.TiempoEstimado = float.Parse(TxtTiempoEstimado.Text);
             _caso.TiempoRestante = float.Parse(TxtTiempoRestante.Text);

             _caso.ResponsableDesarrollo = _listaRecursos[long.Parse(this.CmbRespDesarrollo.SelectedValue)];
             _caso.ResponsablePruebas = _listaRecursos[long.Parse(this.CmbRespPruebas.SelectedValue)];
             _caso.Proyecto = _listaProyectos[long.Parse(this.CbmProyecto.SelectedValue)];
             _caso.EtapaCaso = _listaEtapas[long.Parse(this.CmbEtapa.SelectedValue)];

             _caso.TipoCaso = _listaTipos[long.Parse(this.CmbTipo.SelectedValue)];

        }

        protected void BtnRegAvance_Click(object sender, EventArgs e)
        {
           
            //Response.Redirect("RegAvance.aspx?id=" + _caso.Id.ToString());

            string url = "RegAvance.aspx?id=" + _caso.Id.ToString();
            ClientScript.RegisterStartupScript(this.GetType(), "newWindow", string.Format("<script>window.open('{0}');</script>", url));

        }

        protected void BtnGuardarRA_Click(object sender, EventArgs e)
        {
            bool error = false;

            RegistroAvance r = new RegistroAvance();
            r.Borrado = false;
            r.Descripcion = txtdescripcionAvance.Text;
            r.Fecha = DateTime.Now;

            r.Recurso = (Recurso)Session["user"];
            try
            {
                r.Tiempo = float.Parse(TxtTiempoAvance.Text);
            }
            catch
            {
                error = true;
             
                //global::System.Windows.Forms.MessageBox.Show("Error en campo Tiempo");
            }

            if (!error)
            {

                RegAvanceDAO.Instancia.insertar(r, Convert.ToInt64(Request.QueryString["id"]) ,true);

                TxtTiempoAvance.Text = "";
                txtdescripcionAvance.Text = "";
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            long id = 0;
            if (_modoApertura == ModosEdicionEnum.Nuevo)
            {
                setearObjeto();
                id = CasoDAO.Instancia.insertar(_caso);
                Response.Redirect("Edit_Caso.aspx?id=" + id.ToString());
            }
            else
            {
                if (_modoApertura == ModosEdicionEnum.Modificar)
                {
                    setearObjeto();
                    CasoDAO.Instancia.Actualizar(_caso);
                }
            }

            Response.Redirect(prevPage);
        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
                    setearObjeto();
                    _caso.Borrado = true;
                    CasoDAO.Instancia.Actualizar(_caso);
                    Response.Redirect("Default.aspx");

        }


        protected void BtnCancelar_Click(object sender, EventArgs e)
        {


           
                Response.Redirect(prevPage );

    
 
        }
    }
}
