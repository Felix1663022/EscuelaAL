<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_i.aspx.cs" Inherits="EscuelaAL.Alumnos.alumno_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>

        <tr>
            <td>Matricula: </td>
            <td>
                <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Nombre: </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Fecha de Nacimiento: </td>
            <td>
                <asp:TextBox ID="txtNacimiento" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Semestre: </td>
            <td>
                <asp:TextBox ID="txtSemestre" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Facultad: </td>
            <td>
                <asp:DropDownList ID="ddlFacultad" runat="server"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAgregar" runat="server" Text="Button" OnClick="btnAgregar_Click" />
            </td>

        </tr>

    </table>


</asp:Content>
