<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Proyectos.aspx.cs" Inherits="GestPro.Proyectos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" 
          Text="Proyectos"></asp:Label>
          <br />
    <asp:Button ID="BtnEditar" runat="server" onclick="BtnEditar_Click" 
        Text="Editar" />
   
   
   
    <asp:Button ID="BtnNuevo" runat="server" onclick="BtnNuevo_Click" 
        Text="Nuevo" />
    <asp:Button ID="BtnBorrar" runat="server" onclick="BtnBorrar_Click" 
        Text="Borrar" />
    <asp:Button ID="BtnMenu" runat="server" onclick="BtnMenu_Click" 
        Text="Ir a Menu" />
   
   
   
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" 
        GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
        BorderWidth="1px" HorizontalAlign="Center" Width="100%" Font-Size="Small" 
        Font-Names="Frutiger-Roman" PageSize="20" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" 
        AutoGenerateSelectButton="True">
        <PagerSettings PageButtonCount="5" />
        <Columns>
            <asp:BoundField DataField="IdString" HeaderText="Id" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="nombre" />
            <asp:BoundField DataField="Release" HeaderText="Release" SortExpression="release" />
            <asp:BoundField DataField="EtapaNombre" HeaderText="Etapa" SortExpression="etapa" />
            <asp:BoundField DataField="ClienteNombre" HeaderText="Cliente" SortExpression="cliente" />
            <asp:BoundField DataField="LeaderNombre" HeaderText="Leader" SortExpression="leader" />
        </Columns>
       
        <SelectedRowStyle BackColor="Silver" />
       
    </asp:GridView>
    
</asp:Content>
