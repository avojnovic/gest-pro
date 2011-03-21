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
using System.Collections.Generic;

namespace GestPro
{
    public partial class Edit_Proyecto : System.Web.UI.Page
    {

        Proyecto _proyecto;
        ModosEdicionEnum _modoApertura = new ModosEdicionEnum();
        Dictionary<long, Cliente> _listaCliente;
        Dictionary<long, EtapaProyecto> _listaEtapas;
        Dictionary<long, Recurso> _listaRecursos;

        protected void Page_Load(object sender, EventArgs e)
        {

           
                _proyecto = AdminProyecto.Instancia._proyectoEdit;

                if (_proyecto != null)
                {
                    _modoApertura = ModosEdicionEnum.Modificar;
                }
                else
                {
                    _modoApertura = ModosEdicionEnum.Nuevo;
                    BtnRegAvance.Visible = false;
                }

                _listaCliente = AdminCliente.Instancia.obtenerTodos();
                _listaEtapas = AdminEtapaProyecto.Instancia.obtenerTodos();
                _listaRecursos = AdminRecurso.Instancia.obtenerTodos();

                if (!IsPostBack)
                {
                CmbCliente.DataSource = _listaCliente.Values.ToList();
                CmbCliente.DataBind();
                CmbEtapa.DataSource = _listaEtapas.Values.ToList();
                CmbEtapa.DataBind();
                CmbLeader.DataSource = _listaRecursos.Values.ToList();
                CmbLeader.DataBind();


                //CmbCliente.Items.Insert(0, new ListItem("Seleccionar", string.Empty));
                //CmbCliente.SelectedIndex = 0;
                //CmbEtapa.Items.Insert(0, new ListItem("Seleccionar", string.Empty));
                //CmbEtapa.SelectedIndex = 0;
                //CmbLeader.Items.Insert(0, new ListItem("Seleccionar", string.Empty));
                //CmbLeader.SelectedIndex = 0;

                cargarProyecto();
            }

        }


        private void cargarProyecto()
        {
            if (_proyecto != null)
            {

                TxtNombre.Text = _proyecto.Nombre;
                TxtRelease.Text = _proyecto.Release;

                CmbCliente.SelectedValue = _listaCliente[_proyecto.Cliente.Id].ToString();
                CmbEtapa.SelectedValue = _listaEtapas[_proyecto.Etapa.Id].ToString();
                CmbLeader.SelectedValue = _listaRecursos[_proyecto.Leader.Id].ToString();

            }
            else
            {
                _modoApertura = ModosEdicionEnum.Nuevo;
            }

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (_modoApertura == ModosEdicionEnum.Nuevo)
            {
                setearObjeto();
               AdminProyecto.Instancia.insertar(_proyecto);
                
            }
            else
            {
                if (_modoApertura == ModosEdicionEnum.Modificar)
                {
                    setearObjeto();
                    AdminProyecto.Instancia.actualizar(_proyecto);
                }
            }
            AdminProyecto.Instancia._proyectoEdit = null;
            Response.Redirect("Proyectos.aspx");
        }

        private void setearObjeto()
        {
            if (_proyecto == null)
                _proyecto = new Proyecto();

            foreach (Recurso r in _listaRecursos.Values.ToList())
            {
                if (r.ToString() == CmbLeader.SelectedItem.Text)
                {
                    _proyecto.Leader = r;
                    break;
                }
            }
            foreach (Cliente r in _listaCliente.Values.ToList())
            {
                if (r.ToString() == CmbCliente.SelectedItem.Text)
                {
                    _proyecto.Cliente = r;
                    break;
                }
            }
            foreach (EtapaProyecto r in _listaEtapas.Values.ToList())
            {
                if (r.ToString() == CmbEtapa.SelectedItem.Text)
                {
                    _proyecto.Etapa = r;
                    break;
                }
            }


            _proyecto.Nombre = TxtNombre.Text;
            _proyecto.Release = TxtRelease.Text;
            _proyecto.Borrado = false;
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            AdminProyecto.Instancia._proyectoEdit = null;
            Response.Redirect("Proyectos.aspx");
        }

        protected void CmbEtapa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CmbLeader_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnRegAvance_Click(object sender, EventArgs e)
        {
            AdminRegAvance.Instancia.caso = false;
            AdminRegAvance.Instancia._idVinculacion = _proyecto.Id;
            string url = "RegAvance.aspx";
            ClientScript.RegisterStartupScript(this.GetType(), "newWindow", string.Format("<script>window.open('{0}');</script>",url));
        }


    }
}
