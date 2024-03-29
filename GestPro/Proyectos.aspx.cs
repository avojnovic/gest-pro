﻿using System;
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
    public partial class Proyectos : System.Web.UI.Page
    {
        private Dictionary<long, Proyecto> _dicProyectos;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               

                cargarGrilla();
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
            _dicProyectos = ProyectosDAO.Instancia.obtenerTodos();

            GridView1.DataSource = _dicProyectos.Values.ToList();
            GridView1.DataBind();
            
        }

        protected void GrillaProyectos_Load(object sender, EventArgs e)
        {
             
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                long id = long.Parse(row.Cells[1].Text);

                Response.Redirect("Edit_Proyecto.aspx?id="+id.ToString());

            }
 
        }



        protected void BtnNuevo_Click(object sender, EventArgs e)
        {

            Response.Redirect("Edit_Proyecto.aspx");
        }

   

        protected void BtnBorrar_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            if (row != null)
            {
                long id = long.Parse(row.Cells[1].Text);

                Proyecto p = ProyectosDAO.Instancia.obtenerRecursoPorId(id);

                if (p != null)
                {

                    p.Borrado = true;
                    ProyectosDAO.Instancia.actualizar(p);
                    Response.Redirect("Proyectos.aspx");
                }
            }
            else
            {

            }
        }
    }
}
