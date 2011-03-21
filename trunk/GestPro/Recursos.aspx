<%@ Page Language="C#"  MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Recursos.aspx.cs" Inherits="GestPro.Recursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" 
          Text="Recursos"></asp:Label>
          <br />
    <asp:Button ID="BtnEditar" runat="server" Text="Editar" 
        onclick="BtnEditar_Click" />
   
   
   
    <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" 
        onclick="BtnNuevo_Click" />
    <asp:Button ID="BtnBorrar" runat="server" Text="Borrar" />
    <asp:Button ID="BtnMenu" runat="server"  Text="Ir a Menu" 
        onclick="BtnMenu_Click" />
   
   
   
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" 
        GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
        BorderWidth="1px" HorizontalAlign="Center" Width="100%" Font-Size="Small" 
        Font-Names="Frutiger-Roman" PageSize="20" 
        AutoGenerateSelectButton="True">
        <PagerSettings PageButtonCount="5" />
        <Columns>
            <asp:BoundField DataField="IdString" HeaderText="Id" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" 
                SortExpression="apellido" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="email" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="cargo" />
        </Columns>
       
        <SelectedRowStyle BackColor="Silver" />
       
    </asp:GridView>
    
</asp:Content>

