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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtNombre"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
                </td>
                 <td style="width:300px;">
                    <asp:TextBox ID="TxtNombre" runat="server" Width="100%"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblApellido" runat="server" Text="Apellido:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtApellido"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
                </td>
              
                <td >
                    <asp:TextBox ID="TxtApellido" runat="server" Width="100%" ></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtEmail"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
                </td>
               
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server" Width="100%"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblUsuario" runat="server" Text="Usuario:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtUsuario"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
                </td>
               
                <td>
                    <asp:TextBox ID="TxtUsuario" runat="server" Width="100%"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPassword" runat="server" Text="Contraseña:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtPassword"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
                </td>
               
                <td >
                    <asp:TextBox ID="TxtPassword" runat="server" Width="100%" ></asp:TextBox>
                </td>
               
            </tr>
             <tr>
                <td >
                    
                    <asp:Label ID="LblCargo" runat="server" Text="Cargo:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="CmbCargo"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
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

         <asp:ImageButton ID="BtnGuardar" Width="32px" Height="32px" ImageUrl="~/Images/save.png" ValidationGroup="add" runat="server" onclick="BtnGuardar_Click" ToolTip="Guardar" />

            <asp:ImageButton ID="BtnCancelar" Width="32px" Height="32px" ImageUrl="~/Images/return.png" runat="server" onclick="BtnCancelar_Click" ToolTip="Volver" />

            <asp:ImageButton ID="BtnBorrar" Width="32px" Height="32px" ImageUrl="~/Images/trash.png" runat="server" onclick="BtnBorrar_Click" ToolTip="Borrar" />


       </asp:Panel>
         <act:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="panel1"
                    Radius="8" Color="#DDDDDD" Corners="All" Enabled="true">
                </act:RoundedCornersExtender>
      </center>
    </div>
</asp:Content>