using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EscuelaAL.Alumnos
{
    //CODE BEHIND DE LA PANTALLA
    public partial class alumno_s : System.Web.UI.Page
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grd_alumnos.DataSource = cargarAlumnos();
                grd_alumnos.DataBind();
            }

        }

        protected void grd_alumnos_RowCommand(object sender, GridViewCommandEventArgs e) //Como se activa el RowCommand???
        {
            {
                if (e.CommandName == "Editar")
                {
                    Response.Redirect("~/Alumnos/alumno_u.aspx?pMatricula=" + e.CommandArgument);
                }
                else
                {
                    Response.Redirect("~/Alumnos/alumno_d.aspx?pMatricula=" + e.CommandArgument); //Completar link que aparecera en URL
                }
            }

        }
        #endregion

        public DataTable cargarAlumnos()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=KARTOFFEL;Database=EscuelaAL;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarAlumnos";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtAlumnos = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtAlumnos);

            connection.Close();

            return dtAlumnos;

        }
    }
}