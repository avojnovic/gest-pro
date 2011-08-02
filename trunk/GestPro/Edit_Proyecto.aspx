<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Edit_Proyecto.aspx.cs" Inherits="GestPro.Edit_Proyecto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
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
         <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Proyecto"></asp:Label>
  </h1>
          <br />
    
    <div>
        <asp:label ID="lblMsg" runat="server" Text="" CssClass="mensajes"></asp:label>
        <table  style="width:400px;">
            <tr>
                <td style="width:100px;">
                    <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtNombre"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
                </td>
                <td style="width:300px;">
                    <asp:TextBox ID="TxtNombre" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblEntregable" runat="server" Text="Entregable:"></asp:Label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtRelease"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
                </td>
                <td>
                    <asp:TextBox ID="TxtRelease" runat="server" Width="100%" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblEtapa" runat="server" Text="Etapa:"></asp:Label>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CmbEtapa"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
                </td>
                <td>
                    <asp:DropDownList ID="CmbEtapa" runat="server" Width="100%" onselectedindexchanged="CmbEtapa_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblCliente" runat="server" Text="Cliente:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CmbCliente"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
                </td>

                <td>
                    <asp:DropDownList ID="CmbCliente" runat="server" Width="100%" onselectedindexchanged="CmbCliente_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblLeader" runat="server" Text="Leader:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="CmbLeader"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
                </td>
                <td >
                    <asp:DropDownList ID="CmbLeader" runat="server" Width="100%" onselectedindexchanged="CmbLeader_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            
        </table>
        <br />
          <center>
         <asp:Panel runat="server" ID="panel1" Visible="true"  Width="100%" style="background-color:#DDDDDD">

             <asp:ImageButton ID="BtnGuardar" Width="32px" Height="32px" ImageUrl="~/Images/save.png" ValidationGroup="add" runat="server" onclick="BtnGuardar_Click" ToolTip="Guardar" />

            <asp:ImageButton ID="BtnCancelar" Width="32px" Height="32px" ImageUrl="~/Images/return.png" runat="server" onclick="BtnCancelar_Click" ToolTip="Volver" />

            <asp:ImageButton ID="BtnRegAvance" Width="32px" Height="32px" ImageUrl="~/Images/time.png" runat="server" ToolTip="Registrar Tiempo Avance" />

              <asp:ImageButton ID="BtnRegAvanceVer" Width="32px" Height="32px" ImageUrl="~/Images/timeSet.png" runat="server" onclick="BtnVerAvances_Click" ToolTip="Ver Tiempos Avances Registrados"  />

            <asp:ImageButton ID="BtnBorrar" Width="32px" Height="32px" ImageUrl="~/Images/trash.png" runat="server" onclick="BtnBorrar_Click" ToolTip="Borrar" />


           </asp:Panel>
             <act:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="panel1"
                        Radius="8" Color="#DDDDDD" Corners="All" Enabled="true">
                    </act:RoundedCornersExtender>
          </center>


           <act:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
       DropShadow="true" 
       TargetControlID="BtnRegAvance"  PopupControlID="ModalPanel" 
       BackgroundCssClass="modal"
        >
      </act:ModalPopupExtender>

        <asp:Panel ID="ModalPanel"  BackColor="White" runat="server" Width="350px" Height="150px" >
        <center>
        <asp:Label ID="Label15" runat="server" Text="Registre su tiempo de Avance" CssClass="titulosPaneles"></asp:Label>
        <br />
        <table style="width: 300px; height: 100px;">
            <tr>
                <td>

                    <asp:Label ID="LblTiempo" runat="server" Text="Tiempo:"></asp:Label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorm1" runat="server" ControlToValidate="TxtTiempoAvance"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="addt" />
                </td>
                <td>

                    <asp:TextBox ID="TxtTiempoAvance" runat="server" Width="100%"></asp:TextBox>
                     <act:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99,99" MaskType="Number" TargetControlID="TxtTiempoAvance"></act:MaskedEditExtender>
                </td>
  

            </tr>
            <tr>
                <td >
                    <asp:Label ID="LblDesc" runat="server" Text="Descripción:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorm2" runat="server" ControlToValidate="txtdescripcionAvance"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="addt" />
                </td>
                <td>
                    <asp:TextBox ID="txtdescripcionAvance" runat="server" Width="100%"></asp:TextBox>

                </td>

            </tr>
            <tr>
                <td colspan="2" align="center">
                     <asp:ImageButton ID="BtnAceptar" Width="32px" Height="32px" ImageUrl="~/Images/save.png" ValidationGroup="addt" runat="server" onclick="BtnGuardarRA_Click" ToolTip="Aceptar" />
                     <asp:ImageButton ID="BtnCancelarRA" Width="32px" Height="32px" ImageUrl="~/Images/return.png" runat="server" ToolTip="Cancelar" />

                </td>
            </tr>
        </table>
        </center>
         </asp:Panel>


    </div>
</asp:Content>