<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegAvance.aspx.cs" Inherits="GestPro.RegAvance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Registrar Tiempo de Avance</title>
</head>
<body>
<script src="jquery.js"></script>
    <form id="form1" runat="server">
    <div>
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
             <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Registro de Avance"></asp:Label>
  </h1>

        <br />
        <asp:Panel ID="ModalPanel" Visible="false" runat="server" >
        <table style="width: 84%; height: 318px;">
            <tr>
                <td>
                    <asp:Label ID="LblTiempo" runat="server" Text="Tiempo:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtTiempo" runat="server" Width="100%"></asp:TextBox>
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
                    <asp:TextBox ID="TxtDescripcion" runat="server" Width="100%"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td >
                    <asp:Button ID="BtnAceptar" runat="server" onclick="BtnAceptar_Click" 
                        Text="Aceptar" />
                </td>
                <td>
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" 
                        onclick="BtnCancelar_Click" />
                </td>
            </tr>
        </table>
         </asp:Panel>
    </div>
    </form>
</body>
</html>
