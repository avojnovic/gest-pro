<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Edit_Caso.aspx.cs" Inherits="GestPro.Edit_Caso" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style5
        {
            width: 188px;
        }
        .style6
        {
            width: 566px;
        }
        .style7
        {
            width: 123px;
        }
        .style8
        {
            width: 188px;
            height: 26px;
        }
        .style9
        {
            width: 566px;
            height: 26px;
        }
        .style10
        {
            width: 123px;
            height: 26px;
        }
        .style11
        {
        	width: 10%;
            height: 26px;
        }
        .style12
        {
            width: 20px;
        }
        .style13
        {
            width: 20px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div>
       <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" 
          Text="Caso"></asp:Label>
          <br />
      
      <table style="width:100%;">
          <tr>
              <td>
                  <asp:Label ID="Label14" runat="server" Text="Nro Caso:"></asp:Label>
              </td>
              <td class="style6">
                  <asp:TextBox ID="TxtNroCaso" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
              </td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  <asp:Label ID="Label9" runat="server" Text="Tipo:"></asp:Label>
              </td>
              <td>
                  <asp:DropDownList ID="CmbTipo" runat="server" Width="100%" AutoPostBack="True">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td class="style5">
                  <asp:Label ID="Label8" runat="server" Text="Responsable:"></asp:Label>
              </td>
              <td class="style6">
                  <asp:TextBox ID="TxtResponsable" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
              </td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  <asp:Label ID="Label10" runat="server" Text="Etapa:"></asp:Label>
              </td>
              <td>
                  <asp:DropDownList ID="CmbEtapa" runat="server" Width="100%" AutoPostBack="True">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td class="style5">
                  <asp:Label ID="Label11" runat="server" Text="Proyecto:"></asp:Label>
              </td>
              <td class="style6">
                  <asp:DropDownList ID="CbmProyecto" runat="server" Width="100%" 
                      AutoPostBack="True">
                  </asp:DropDownList>
              </td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  <asp:Label ID="Label3" runat="server" Text="Prioridad:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtPrioridad" runat="server" Width="100%"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td class="style5">
                  <asp:Label ID="Label1" runat="server" Text="Descripción:"></asp:Label>
              </td>
              <td class="style6">
                  <asp:TextBox ID="TxtDescripcion" runat="server" Width="100%"></asp:TextBox>
              </td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style8">
                  <asp:Label ID="Label12" runat="server" Text="Responsable Desarrollo:"></asp:Label>
              </td>
              <td class="style9">
                  <asp:DropDownList ID="CmbRespDesarrollo" runat="server" Width="100%" 
                      AutoPostBack="True">
                  </asp:DropDownList>
              </td>
              <td class="style13">
                  &nbsp;</td>
              <td class="style10">
              </td>
              <td class="style11">
              </td>
          </tr>
          <tr>
              <td class="style5">
                  <asp:Label ID="Label13" runat="server" Text="Responsable Pruebas:"></asp:Label>
              </td>
              <td class="style6">
                  <asp:DropDownList ID="CmbRespPruebas" runat="server" Width="100%" 
                      AutoPostBack="True">
                  </asp:DropDownList>
              </td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  <asp:Label ID="Label4" runat="server" Text="Tiempo estimado:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtTiempoEstimado" runat="server" Width="100%"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td class="style5">
                  <asp:Label ID="Label6" runat="server" Text="Descripción Implementación:"></asp:Label>
              </td>
              <td class="style6">
                  <asp:TextBox ID="TxtDescImplementacion" runat="server" TextMode="MultiLine" 
                      Width="100%"></asp:TextBox>
              </td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  <asp:Label ID="Label5" runat="server" Text="Tiempo Restante:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtTiempoRestante" runat="server" Width="100%"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td class="style5">
                  &nbsp;</td>
              <td class="style6">
                  &nbsp;</td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  <asp:Label ID="Label2" runat="server" Text="Fecha de Entrega:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtFechaEntrega" runat="server" Width="100%"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td class="style5">
                  &nbsp;</td>
              <td class="style6">
                  &nbsp;</td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style5">
                  &nbsp;</td>
              <td class="style6">
                  &nbsp;</td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style5">
                  &nbsp;</td>
              <td class="style6">
                  &nbsp;</td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style5">
                  <asp:Label ID="Label7" runat="server" Text="Descripción Pruebas:"></asp:Label>
              </td>
              <td class="style6">
                  <asp:TextBox ID="TxtDescripcionPruebas" runat="server" TextMode="MultiLine" 
                      Width="100%"></asp:TextBox>
              </td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style5">
                  &nbsp;</td>
              <td class="style6">
                  &nbsp;</td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style5">
                  &nbsp;</td>
              <td class="style6">
                  &nbsp;</td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style5">
                  <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" 
                      onclick="BtnGuardar_Click" />
              </td>
              <td class="style6">
                  <asp:Button ID="BtnCancelar" runat="server" Text="Salir" 
                      onclick="BtnCancelar_Click" />
              </td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  <asp:Button ID="BtnRegAvance" runat="server" onclick="BtnRegAvance_Click" 
                      Text="Registrar Tiempo Avance" />
              </td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td class="style5">
                  &nbsp;</td>
              <td class="style6">
                  &nbsp;</td>
              <td class="style12">
                  &nbsp;</td>
              <td class="style7">
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
      </table>
      
      
  </div>
</asp:Content>