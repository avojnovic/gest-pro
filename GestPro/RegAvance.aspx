<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegAvance.aspx.cs" Inherits="GestPro.RegAvance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Registrar Tiempo de Avance</title>
    <style type="text/css">
        .style1
        {
            width: 177px;
        }
        .style2
        {
            width: 256px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" 
          Text="Registro de Avance"></asp:Label>
          <br />
        <table style="width: 84%; height: 318px;">
            <tr>
                <td class="style1">
                    <asp:Label ID="LblTiempo" runat="server" Text="Tiempo:"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="TxtTiempo" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LblError" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LblDesc" runat="server" Text="Descripción:"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="TxtDescripcion" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Button ID="BtnAceptar" runat="server" onclick="BtnAceptar_Click" 
                        Text="Aceptar" />
                </td>
                <td>
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" 
                        onclick="BtnCancelar_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
