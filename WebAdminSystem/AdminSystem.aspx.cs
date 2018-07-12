using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAdminSystem.Modelo;

namespace WebAdminSystem
{
    public partial class AdminSystem : System.Web.UI.Page
    {
        TOdrinkGOEntities contexto = new TOdrinkGOEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Mostrar();
            }
        }


        private void Mostrar()
        {
            var list = from l in contexto.Local
                       join u in contexto.Usuario on l.id_local equals u.local
                       where u.id_roles == 1
                       //join p in contexto.Perfil on u.peril equals p.Rut
                       select new { l.id_local, l.Nombre, l.Direccion, NombreUsuario = u.nombre };
            datagrid_locales.DataSource = list.ToList();
            datagrid_locales.DataBind();


        }
        private void Limpiar()
        {
            txtNombreLocal.Text = "";
            txtDireccionLocal.Text = "";
            txtNombreUsuario.Text = "";
            txtClave.Text = "";
            lbID.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreLocal = txtNombreLocal.Text;
                string direccionLocal = txtDireccionLocal.Text;
                string nombreAdmin = txtNombreUsuario.Text;
                string clave = txtClave.Text;
                int idRol = 1;
                int estadoUs = 1;
                if (nombreLocal=="" && direccionLocal=="" && nombreAdmin=="" && clave=="" || nombreLocal ==  null && direccionLocal == null && nombreAdmin == null && clave == null)
                {
                    lbRespuesta.Text = "Complete los campos para el registro";
                    lbRespuesta.CssClass = "text-center text-danger";
                }
                else
                {
                    Local l = new Local { Nombre = nombreLocal, Direccion = direccionLocal };
                    contexto.Local.Add(l);
                    contexto.SaveChanges();
                    int idL = l.id_local;
                    Usuario u = new Usuario { nombre = nombreAdmin, clave = clave, id_roles = idRol, estado = estadoUs, local = idL };
                    contexto.Usuario.Add(u);
                    contexto.SaveChanges();
                    Mostrar();
                    Limpiar();
                    lbRespuesta.Text = "Local registrado con exito";
                    lbRespuesta.CssClass = "text-center text-success";
                }
               
                
            }
            catch (Exception)
            {

              
            }

        }

        protected void datagrid_locales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                int id_L = Convert.ToInt32(datagrid_locales.Rows[fila].Cells[0].Text);
                string NameLocal = datagrid_locales.Rows[fila].Cells[1].Text;
                string direccion = datagrid_locales.Rows[fila].Cells[1].Text;
                string admin = datagrid_locales.Rows[fila].Cells[1].Text;
                if (e.CommandName== "btnSeleccionar")
                {
                    lbID.Text = id_L.ToString();
                    txtNombreLocal.Text = NameLocal;
                    txtDireccionLocal.Text = direccion;
                }




            }
            catch (Exception)
            {

                
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(lbID.Text);
                Local original = new Local();
                original = contexto.Local.Find(id);
                original.Nombre = txtNombreLocal.Text;
                original.Direccion = txtDireccionLocal.Text;
                contexto.SaveChanges();
                Mostrar();
                Limpiar();
                lbRespuesta.CssClass = "text-success";
                lbRespuesta.Text = "Actualizado con exito.";
            }
            catch (Exception)
            {

                
            }
        }
    }
}