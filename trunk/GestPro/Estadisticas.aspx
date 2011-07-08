<%@ Page Language="C#" MasterPageFile="~/Master.Master"  AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="GestPro.Estadisticas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script>

            $(document).ready(function () {

                $("h1").animate({
                    'border-bottom-width': "20",
                    'font-size': '25pt'
                });

            })

 </script>
  <div>
  <h1 style="border-bottom: 1px solid #FF0000; font-size: 15pt;">
       <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large"  Text="Estadisticas"></asp:Label>
  </h1>

  <div>
      
      <br />
      <table style="width:100%;">
          <tr>
              <td style="width:200px;">
                  <asp:Label ID="LblProyecto" runat="server" Text="Proyecto:"></asp:Label>
              </td>
              <td >
                  <asp:DropDownList ID="CmbProyectos" runat="server" AutoPostBack="True" 
                      Width="200px" onselectedindexchanged="CmbProyectos_SelectedIndexChanged">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="LblCantCasos" runat="server" Text="Cantidad de Casos:" ></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtCantCasos" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="LblEnPlan" runat="server" Text="En Planificación:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtPlan" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="LblEnImp" runat="server" Text="En Implementación:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtImple" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="LblEnPru" runat="server" Text="En Prueba:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtPrueb" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="LblEnFin" runat="server" Text="Finalizados:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtFin" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
              </td>
          </tr>
      </table>
      <br />
      
      
  </div>
</asp:Content>
