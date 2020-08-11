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
    public partial class alumno_i : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarFacultades();
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno agregado exitosamente')", true);
        }
        #endregion

        public void agregarAlumno()
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=KARTOFFEL;Database=EscuelaAL;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_agregarAlumno";
            command.Connection = connection;

            //seccion para agregar parametros, command es una funcion insert into
            command.Parameters.AddWithValue("pMatricula", int.Parse(txtMatricula.Text));
            command.Parameters.AddWithValue("pNombre", txtNombre.Text );
            command.Parameters.AddWithValue("pFecha", Convert.ToDateTime(txtNacimiento.Text));
            command.Parameters.AddWithValue("pSemestre", int.Parse(txtSemestre.Text));
            command.Parameters.AddWithValue("pFacultad", int.Parse(ddlFacultad.SelectedValue));


            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void cargarFacultades()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=KARTOFFEL;Database=EscuelaAL;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarFacultades";
            command.Connection = connection;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtFacultades = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtFacultades);

            connection.Close();

            ddlFacultad.DataSource = dtFacultades;
            ddlFacultad.DataTextField = "nombre";
            ddlFacultad.DataValueField = "ID_Facultad";
            ddlFacultad.DataBind();

            ddlFacultad.Items.Insert(0, new ListItem("---- Seleccione Facultad ----", "0"));

        }

    }
}