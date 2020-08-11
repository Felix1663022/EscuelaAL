﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EscuelaAL.Alumnos
{
    public partial class alumno_d : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int matricula = int.Parse(Request.QueryString["pMatricula"]);
                cargarFacultades();
                cargarAlumno(matricula);
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno eliminado exitosamente')", true);
        }

        public void cargarAlumno(int matricula)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=KARTOFFEL;Database=EscuelaAL;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarAlumno";
            command.Connection = connection;

            command.Parameters.AddWithValue("pMatricula", matricula);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtAlumno = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtAlumno);

            connection.Close();

            lblMatricula.Text = dtAlumno.Rows[0]["matricula"].ToString();
            lblNombre.Text = dtAlumno.Rows[0]["nombre"].ToString();
            lblFecha.Text = dtAlumno.Rows[0]["fechaNacimiento"].ToString().Substring(0, 10);
            lblSemestre.Text = dtAlumno.Rows[0]["semestre"].ToString();
            ddlFacultad.SelectedValue = dtAlumno.Rows[0]["facultad"].ToString();

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

        public void eliminarAlumno()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=KARTOFFEL;Database=EscuelaAL;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_eliminarAlumno";
            command.Connection = connection;

            //seccion para agregar parametros, command es una funcion insert into
            command.Parameters.AddWithValue("pMatricula", int.Parse(lblMatricula.Text));


            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }
    }

}