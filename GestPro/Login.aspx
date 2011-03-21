<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GestPro.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 537px;
        }
        .style2
        {
            width: 208px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style2">
                <asp:Label ID="LblUsuario" runat="server" Text="Usuario:"></asp:Label>
            </td>
            <td class="style1">


    <asp:TextBox ID="TxtUsuario" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style2">
                <asp:Label ID="LblPass" runat="server" Text="Contraseña:"></asp:Label>
            </td>
            <td class="style1">
    <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style1">
    <asp:Button ID="BtnIniciar" runat="server" onclick="BtnIniciar_Click" 
        Text="Iniciar Sesión" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td align="center" class="style1">
                <asp:Label ID="TxtAviso" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />


    </asp:Content>
