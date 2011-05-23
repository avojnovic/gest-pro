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
    public partial class Edit_Recurso : System.Web.UI.Page
    {
        Recurso _recurso;
        ModosEdicionEnum _modoApertura = new ModosEdicionEnum();
        Dictionary<long, Cargo> _listaCargos;

        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["id"];
            if (id != null)
            {
                _recurso = RecursoDAO.Instancia.obtenerRecursoPorId(long.Parse(id));
            }


    

                if (_recurso != null)
                {
                    _modoApertura = ModosEdicionEnum.Modificar;
                }
                else
                {
                    _modoApertura = ModosEdicionEnum.Nuevo;
                }

                _listaCargos = CargoDAO.Instancia.obtenerTodos();
                

                if (!IsPostBack)
                {
                    CmbCargo.DataSource = _listaCargos.Values.ToList();
                    CmbCargo.DataBind();
                


                //CmbCliente.Items.Insert(0, new ListItem("Seleccionar", string.Empty));
                //CmbCliente.SelectedIndex = 0;
                

                cargarRecurso();
                }
        }

        private void cargarRecurso()
        {
            if (_recurso != null)
            {
                TxtNombre.Text = _recurso.Nombre;
                TxtApellido.Text = _recurso.Apellido;
                TxtEmail.Text = _recurso.Email;
                TxtUsuario.Text = _recurso.Usuario;
                TxtPassword.Text = _recurso.Password;

                CmbCargo.SelectedValue = _listaCargos[_recurso.Cargo.Id].ToString();


            }
            else
            {
                _modoApertura = ModosEdicionEnum.Nuevo;
            }

        }

        private void setearObjeto()
        {
            if (_recurso == null)
                _recurso = new Recurso();

            foreach (Cargo r in _listaCargos.Values.ToList())
            {
                if (r.ToString() ==CmbCargo.SelectedItem.Text)
                {
                    _recurso.Cargo = r;
                    break;
                }
            }

            _recurso.Apellido = TxtApellido.Text;
            _recurso.Nombre = TxtNombre.Text;
            _recurso.Usuario = TxtUsuario.Text;
            _recurso.Password = TxtPassword.Text;
            _recurso.Email = TxtEmail.Text;
            _recurso.Borrado = false;


        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recursos.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (_modoApertura == ModosEdicionEnum.Nuevo)
            {
                setearObjeto();
                RecursoDAO.Instancia.insertar(_recurso);

            }
            else
            {
                if (_modoApertura == ModosEdicionEnum.Modificar)
                {
                    setearObjeto();
                    RecursoDAO.Instancia.actualizar(_recurso);
                }
            }

            Response.Redirect("Recursos.aspx");

        }
    }
}
