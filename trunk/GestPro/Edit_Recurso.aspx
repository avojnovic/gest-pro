<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Edit_Recurso.aspx.cs" Inherits="GestPro.Edit_Recurso" %>


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
        <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Recurso"></asp:Label>
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
                    <asp:Label ID="LblApellido" runat="server" Text="Apellido:"></asp:Label>
                </td>
              
                <td >
                    <asp:TextBox ID="TxtApellido" runat="server" Width="100%" ></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
                </td>
               
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server" Width="100%"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblUsuario" runat="server" Text="Usuario:"></asp:Label>
                </td>
               
                <td>
                    <asp:TextBox ID="TxtUsuario" runat="server" Width="100%"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPassword" runat="server" Text="Contraseña:"></asp:Label>
                </td>
               
                <td >
                    <asp:TextBox ID="TxtPassword" runat="server" Width="100%" ></asp:TextBox>
                </td>
               
            </tr>
             <tr>
                <td >
                    
                    <asp:Label ID="LblCargo" runat="server" Text="Cargo:"></asp:Label>
                    
                </td>
               
                <td>
                   
                    <asp:DropDownList ID="CmbCargo" runat="server" Width="100%">
                    </asp:DropDownList>
                   
                </td>
                
            </tr>
           
        </table>
        <center>
       <br />
     <asp:Panel runat="server" ID="panel1" Visible="true"  Width="100%" style="background-color:#DDDDDD">

     <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" onclick="BtnGuardar_Click" />
       <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" onclick="BtnCancelar_Click" />
       <asp:Button ID="BtnBorrar" runat="server" Text="Borrar" onclick="BtnBorrar_Click" />
       </asp:Panel>
         <act:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="panel1"
                    Radius="8" Color="#DDDDDD" Corners="All" Enabled="true">
                </act:RoundedCornersExtender>
      </center>
    </div>
</asp:Content>