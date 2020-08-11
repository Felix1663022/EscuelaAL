
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_s.aspx.cs" Inherits="EscuelaAL.Alumnos.alumno_s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Creamos tabla -->
    <asp:GridView ID="grd_alumnos" AutoGenerateColumns="false" runat="server" OnRowCommand="grd_alumnos_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" imageUrl="~/Imagenes/pencil_dribbble_withey-01.jpg" Height="20px" Width="20px"
                        CommandName="Editar" CommandArgument='<%#Eval("matricula") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" imageUrl="~/Imagenes/184-512.png" Height="20px" Width="20px"
                        CommandName="Eliminar" CommandArgument='<%#Eval("matricula") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Matricula" DataField="matricula" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
            <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="fechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="Semestre" DataField="semestre" />
            <asp:BoundField HeaderText="Facultad" DataField="nombrefacultad" />
        </Columns>

    </asp:GridView>

</asp:Content>
