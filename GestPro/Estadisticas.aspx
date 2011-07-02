<%@ Page Language="C#" MasterPageFile="~/Master.Master"  AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="GestPro.Estadisticas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style type="text/css">
        .style1
        {
            width: 226px;
        }
        .style2
        {
            width: 692px;
        }
    </style>
   
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
              <td class="style1">
                  <asp:Label ID="LblProyecto" runat="server" Text="Proyecto:"></asp:Label>
              </td>
              <td class="style2">
                  <asp:DropDownList ID="CmbProyectos" runat="server" AutoPostBack="True" 
                      Width="100%" onselectedindexchanged="CmbProyectos_SelectedIndexChanged">
                  </asp:DropDownList>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style1">
                  <asp:Label ID="LblCantCasos" runat="server" Text="Cantidad de Casos:" ></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="TxtCantCasos" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style1">
                  <asp:Label ID="LblEnPlan" runat="server" Text="En Planificación:"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="TxtPlan" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style1">
                  <asp:Label ID="LblEnImp" runat="server" Text="En Implementación:"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="TxtImple" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style1">
                  <asp:Label ID="LblEnPru" runat="server" Text="En Prueba:"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="TxtPrueb" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style1">
                  <asp:Label ID="LblEnFin" runat="server" Text="Finalizados:"></asp:Label>
              </td>
              <td class="style2">
                  <asp:TextBox ID="TxtFin" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
          </tr>
      </table>
      <br />
      
      
  </div>
</asp:Content>
