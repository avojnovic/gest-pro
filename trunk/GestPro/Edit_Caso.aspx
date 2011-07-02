<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Edit_Caso.aspx.cs" Inherits="GestPro.Edit_Caso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Src="~/controls/DatePicker.ascx" TagPrefix="ctrol" TagName="DatePicker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script src="jquery.js"></script>
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
  <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Caso"></asp:Label>
  </h1>
      <table style="width:900px;">
          <tr>
              <td style="width:200px;" >
                  <asp:Label ID="Label14" runat="server" Text="Nro Caso"></asp:Label>
              </td>
              <td style="width:200px; background-color:#DDDDDD">
                <center>
                  <asp:label ID="TxtNroCaso" runat="server"></asp:label>
                  </center>
              </td>
              <td style="width:50px;">
                  &nbsp;</td>
              <td style="width:200px;">
                  <asp:Label ID="Label9" runat="server" Text="Tipo:"></asp:Label>
              </td>
              <td style="width:200px;">
                  <asp:DropDownList ID="CmbTipo" runat="server" Width="100%">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td >
                  <asp:Label ID="Label8" runat="server" Text="Responsable:"></asp:Label>
              </td>
              <td >
                  <asp:TextBox ID="TxtResponsable" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
              <td>
                  <asp:Label ID="Label10" runat="server" Text="Etapa:"></asp:Label>
              </td>
              <td>
                  <asp:DropDownList ID="CmbEtapa" runat="server" Width="100%" >
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label11" runat="server" Text="Proyecto:"></asp:Label>
              </td>
              <td>
                  <asp:DropDownList ID="CbmProyecto" runat="server" Width="100%" >
                  </asp:DropDownList>
              </td>
              <td>
                  &nbsp;</td>
              <td>
                  <asp:Label ID="Label3" runat="server" Text="Prioridad:"></asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtPrioridad"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
              </td>
              <td>
                  <asp:TextBox ID="TxtPrioridad" runat="server" Width="100%"></asp:TextBox>
                  
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label1" runat="server" Text="Descripción:"></asp:Label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtDescripcion"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
              </td>
              <td >
                  <asp:TextBox ID="TxtDescripcion" runat="server" Width="100%"></asp:TextBox>
                   
              </td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
              <td>
                  &nbsp;</td>
          </tr>
          <tr>
              <td >
                  <asp:Label ID="Label12" runat="server" Text="Responsable Desarrollo:"></asp:Label>
              </td>
              <td>
                  <asp:DropDownList ID="CmbRespDesarrollo" runat="server" Width="100%">
                  </asp:DropDownList>
              </td>
              <td>
                  &nbsp;</td>
              <td>
              </td>
              <td>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label13" runat="server" Text="Responsable Pruebas:"></asp:Label>
              </td>
              <td>
                  <asp:DropDownList ID="CmbRespPruebas" runat="server" Width="100%">
                  </asp:DropDownList>
              </td>
              <td>
                  &nbsp;</td>
              <td>
                  <asp:Label ID="Label4" runat="server" Text="Tiempo estimado:"></asp:Label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtTiempoEstimado"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
              </td>
              <td>
                  <asp:TextBox ID="TxtTiempoEstimado" runat="server" Width="100%"></asp:TextBox>
                  
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label6" runat="server" Text="Descripción Implementación:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtDescImplementacion" runat="server" TextMode="MultiLine" 
                      Width="100%"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
              <td>
                  <asp:Label ID="Label5" runat="server" Text="Tiempo Restante:"></asp:Label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtTiempoRestante"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
              </td>
              <td>
                  <asp:TextBox ID="TxtTiempoRestante" runat="server" Width="100%"></asp:TextBox>
                  
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="Label7" runat="server" Text="Descripción Pruebas:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtDescripcionPruebas" runat="server" TextMode="MultiLine" 
                      Width="100%"></asp:TextBox>
              </td>
              <td>
                  &nbsp;</td>
              <td>
                  <asp:Label ID="Label2" runat="server" Text="Fecha de Entrega:"></asp:Label>
                   <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dtFechaEntrega"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />--%>
              </td>
              <td>
                   <ctrol:DatePicker runat="server" ID ="dtFechaEntrega" />
              </td>
          </tr>
        
         
      </table>
      <br />
      <center>
     <asp:Panel runat="server" ID="panel1" Visible="true"  Width="100%" style="background-color:#DDDDDD">

     <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" onclick="BtnGuardar_Click"  ValidationGroup="add"/>

      <asp:Button ID="BtnCancelar" runat="server" Text="Volver" onclick="BtnCancelar_Click" />
       <asp:Button ID="BtnRegAvance" runat="server" onclick="BtnRegAvance_Click" Text="Registrar Tiempo Avance" />
         <asp:Button ID="BtnBorrar" runat="server" Text="Borrar" onclick="BtnBorrar_Click" />
       </asp:Panel>
         <act:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="panel1"
                    Radius="8" Color="#DDDDDD" Corners="All" Enabled="true">
                </act:RoundedCornersExtender>
      </center>
      
  </div>
</asp:Content>