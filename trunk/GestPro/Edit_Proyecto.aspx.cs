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
    public partial class Edit_Proyecto : System.Web.UI.Page
    {

        Proyecto _proyecto;
        ModosEdicionEnum _modoApertura = new ModosEdicionEnum();
        Dictionary<long, Cliente> _listaCliente;
        Dictionary<long, EtapaProyecto> _listaEtapas;
        Dictionary<long, Recurso> _listaRecursos;

        protected void Page_Load(object sender, EventArgs e)
        {


            string id = Request.QueryString["id"];
           


            if (id != null)
            {
                _proyecto = ProyectosDAO.Instancia.obtenerPorId(long.Parse(id));
            }

                if (_proyecto != null)
                {
                    _modoApertura = ModosEdicionEnum.Modificar;
                }
                else
                {
                    ModalPanel.Visible = false;
                    _modoApertura = ModosEdicionEnum.Nuevo;
                    BtnRegAvance.Visible = false;
                    BtnBorrar.Visible = false;
                    BtnRegAvanceVer.Visible = false;
                }

                _listaCliente = ClienteDAO.Instancia.obtenerTodos();
                _listaEtapas = EtapaProyectoDAO.Instancia.obtenerTodos();
                _listaRecursos = RecursoDAO.Instancia.obtenerTodos();

                if (!IsPostBack)
                {

                    string u = Request.QueryString["u"];
                    if (u != null)
                    {
                        if (u == "1")
                        {
                            lblMsg.Text = "Proyecto creado correctamente";
                        }
                        else
                        {
                            if (u == "2")
                            {
                                lblMsg.Text = "Proyecto actualizado correctamente";
                            }
                        }
                    }


                    BtnBorrar.Attributes.Add("OnClick", "javascript:if(confirm('Esta seguro que desea borrar el proyecto')== false) return false;");

                CmbCliente.DataSource = _listaCliente.Values.ToList();
                CmbCliente.DataTextField = "nombrecompleto";
                CmbCliente.DataValueField = "Id";
                CmbCliente.DataBind();
                CmbEtapa.DataSource = _listaEtapas.Values.ToList();
                CmbEtapa.DataTextField = "Nombre";
                CmbEtapa.DataValueField = "Id";
                CmbEtapa.DataBind();
                CmbLeader.DataSource = _listaRecursos.Values.ToList();
                CmbLeader.DataTextField = "NombreCompleto";
                CmbLeader.DataValueField = "Id";
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

                CmbCliente.SelectedValue = _proyecto.Cliente.Id.ToString();
                CmbEtapa.SelectedValue =_proyecto.Etapa.Id.ToString();
                CmbLeader.SelectedValue = _proyecto.Leader.Id.ToString();

            }
            else
            {
                _modoApertura = ModosEdicionEnum.Nuevo;
            }

        }

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            setearObjeto();
            _proyecto.Borrado = true;
            ProyectosDAO.Instancia.actualizar(_proyecto);
            Response.Redirect("Default.aspx");

        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            long id = 0;
            if (_modoApertura == ModosEdicionEnum.Nuevo)
            {
                setearObjeto();
                id=ProyectosDAO.Instancia.insertar(_proyecto);
               Response.Redirect("Edit_Proyecto.aspx?id=" + id.ToString()+"&u=1");
            }
            else
            {
                if (_modoApertura == ModosEdicionEnum.Modificar)
                {
                    setearObjeto();
                    ProyectosDAO.Instancia.actualizar(_proyecto);
                    Response.Redirect("Edit_Proyecto.aspx?id=" + _proyecto.Id.ToString() + "&u=2");
                }
            }

            Response.Redirect("Proyectos.aspx");
        }

        private void setearObjeto()
        {
            if (_proyecto == null)
                _proyecto = new Proyecto();

            _proyecto.Leader = _listaRecursos[long.Parse(this.CmbLeader.SelectedValue)];
            _proyecto.Cliente = _listaCliente[long.Parse(this.CmbCliente.SelectedValue)];
            _proyecto.Etapa = _listaEtapas[long.Parse(this.CmbEtapa.SelectedValue)];


            _proyecto.Nombre = TxtNombre.Text;
            _proyecto.Release = TxtRelease.Text;
            _proyecto.Borrado = false;
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
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

        protected void BtnVerAvances_Click(object sender, EventArgs e)
        {

            string url = "RegistrosAvance.aspx?id=" +_proyecto.Id.ToString() + "&u=2";
            ClientScript.RegisterStartupScript(this.GetType(), "newWindow", string.Format("<script>window.open('{0}');</script>", url));

        }

        protected void BtnRegAvance_Click(object sender, EventArgs e)
        {

            string url = "RegAvance.aspx?id=" + _proyecto.Id.ToString();
            ClientScript.RegisterStartupScript(this.GetType(), "newWindow", string.Format("<script>window.open('{0}');</script>",url));
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
 
                RegAvanceDAO.Instancia.insertar(r, Convert.ToInt64(Request.QueryString["id"]), false);

                TxtTiempoAvance.Text = "";
                txtdescripcionAvance.Text = "";
            }
        }


    }
}
