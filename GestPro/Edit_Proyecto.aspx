<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Edit_Proyecto.aspx.cs" Inherits="GestPro.Edit_Proyecto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 170px;
        }
        .style2
        {
            width: 2px;
        }
        .style3
        {
            width: 341px;
        }
        .style4
        {
            width: 102px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" 
          Text="Proyecto"></asp:Label>
          <br />
    
    <div>
    
        <table style="width: 100%; height: 100%;">
            <tr>
                <td class="style1">
                    <asp:Label ID="LblNombre" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:TextBox ID="TxtNombre" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LblEntregable" runat="server" Text="Entregable:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:TextBox ID="TxtRelease" runat="server" Width="100%" ></asp:TextBox>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LblEtapa" runat="server" Text="Etapa:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:DropDownList ID="CmbEtapa" runat="server" Width="100%" AutoPostBack="True" 
                        onselectedindexchanged="CmbEtapa_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LblCliente" runat="server" Text="Cliente:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:DropDownList ID="CmbCliente" runat="server" Width="100%" 
                        AutoPostBack="True" onselectedindexchanged="CmbCliente_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LblLeader" runat="server" Text="Leader:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:DropDownList ID="CmbLeader" runat="server" Width="100%" 
                        AutoPostBack="True" onselectedindexchanged="CmbLeader_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="style1">
                    
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                   
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" 
                        onclick="BtnGuardar_Click" />
                   
                </td>
                <td class="style4">
                   
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" 
                        onclick="BtnCancelar_Click" />
                   
                </td>
                <td>
                   
                    <asp:Button ID="BtnRegAvance" runat="server" onclick="BtnRegAvance_Click" 
                        Text="Registrar Avance" />
                   
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>