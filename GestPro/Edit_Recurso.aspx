<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Edit_Recurso.aspx.cs" Inherits="GestPro.Edit_Recurso" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 157px;
        }
        .style2
        {
            width: 31px;
        }
        .style3
        {
            width: 341px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" 
          Text="Recurso"></asp:Label>
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
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LblApellido" runat="server" Text="Apellido:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:TextBox ID="TxtApellido" runat="server" Width="100%" ></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:TextBox ID="TxtEmail" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LblUsuario" runat="server" Text="Usuario:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:TextBox ID="TxtUsuario" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LblPassword" runat="server" Text="Contraseña:"></asp:Label>
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    <asp:TextBox ID="TxtPassword" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="style1">
                    
                    <asp:Label ID="LblCargo" runat="server" Text="Cargo:"></asp:Label>
                    
                </td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                   
                    <asp:DropDownList ID="CmbCargo" runat="server" Width="100%" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                   
                </td>
                <td>
                   
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="style1">
                    
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                   
                    &nbsp;</td>
                <td>
                   
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="style1">
                    
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                   
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" 
                        onclick="BtnGuardar_Click" />
                   
                </td>
                <td>
                   
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" 
                        onclick="BtnCancelar_Click" />
                   
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>