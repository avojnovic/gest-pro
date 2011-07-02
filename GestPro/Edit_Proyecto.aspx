﻿<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Edit_Proyecto.aspx.cs" Inherits="GestPro.Edit_Proyecto" %>

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
    
        <table  style="width:400px;">
            <tr>
                <td style="width:100px;">
                    <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td style="width:300px;">
                    <asp:TextBox ID="TxtNombre" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblEntregable" runat="server" Text="Entregable:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtRelease" runat="server" Width="100%" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblEtapa" runat="server" Text="Etapa:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="CmbEtapa" runat="server" Width="100%" onselectedindexchanged="CmbEtapa_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblCliente" runat="server" Text="Cliente:"></asp:Label>
                </td>

                <td>
                    <asp:DropDownList ID="CmbCliente" runat="server" Width="100%" onselectedindexchanged="CmbCliente_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblLeader" runat="server" Text="Leader:"></asp:Label>
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

         <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" onclick="BtnGuardar_Click"  ValidationGroup="add"/>

          <asp:Button ID="BtnCancelar" runat="server" Text="Volver" onclick="BtnCancelar_Click" />
           <asp:Button ID="BtnRegAvance" runat="server" Text="Registrar Tiempo Avance" />
            <asp:Button ID="BtnBorrar" runat="server" Text="Borrar" onclick="BtnBorrar_Click" />
           </asp:Panel>
             <act:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="panel1"
                        Radius="8" Color="#DDDDDD" Corners="All" Enabled="true">
                    </act:RoundedCornersExtender>
          </center>


           <act:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
       CancelControlID="BtnCancelar" DropShadow="true" 
       TargetControlID="BtnRegAvance"  PopupControlID="ModalPanel" 
       BackgroundCssClass="modal"
        >
      </act:ModalPopupExtender>

        <asp:Panel ID="ModalPanel"  BackColor="White" runat="server" >
        <center>
        <asp:Label ID="Label15" runat="server" Text="Registre su tiempo de Avance"></asp:Label>
        <table style="width: 300px; height: 100px;">
            <tr>
                <td>
                    <asp:Label ID="LblTiempo" runat="server" Text="Tiempo:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtTiempoAvance" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LblError" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="LblDesc" runat="server" Text="Descripción:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdescripcionAvance" runat="server" Width="100%"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td >
                    <asp:Button ID="BtnAceptar" runat="server" onclick="BtnGuardarRA_Click"   Text="Aceptar" />
                </td>
                <td>
                    <asp:Button ID="BtnCancelarRA" runat="server" Text="Cancelar"/>
                </td>
            </tr>
        </table>
        </center>
         </asp:Panel>


    </div>
</asp:Content>