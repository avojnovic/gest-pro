<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Proyectos.aspx.cs" Inherits="GestPro.Proyectos" %>


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
        <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large"   Text="Proyectos"></asp:Label>
  </h1>
    
          <br />

 
   <asp:ImageButton ID="BtnNuevo" Width="32px" Height="32px" ImageUrl="~/Images/new_project.png" runat="server" onclick="BtnNuevo_Click" ToolTip="Nuevo" />


   
    <asp:GridView ID="GridView1" runat="server"
        AutoGenerateColumns="False"
        GridLines="None"
        AllowPaging="true"
        HorizontalAlign="Center" Width="100%" 
        PageSize="20"
          CssClass="mGrid"  PagerStyle-CssClass="pgr"  AlternatingRowStyle-CssClass="alt"  OnPageIndexChanging="grid_OnPageIndexChanging"  >
        <PagerSettings PageButtonCount="5" />
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" SortExpression="nombre" />
            <asp:BoundField DataField="Release" HeaderText="Release" SortExpression="release" />
            <asp:BoundField DataField="EtapaNombre" HeaderText="Etapa" SortExpression="etapa" />
            <asp:BoundField DataField="ClienteNombre" HeaderText="Cliente" SortExpression="cliente" />
            <asp:BoundField DataField="LeaderNombre" HeaderText="Leader" SortExpression="leader" />
            <asp:TemplateField  ItemStyle-Width="25px">
                 <ItemTemplate>  
                    <a href="Edit_Proyecto.aspx?id=<%# Eval("id") %>" >
                        <img alt="Abrir" src="../images/File-Open-icon.png" border="0"  width="16px" height="16px"/>
                      </a>
                  </ItemTemplate>
             </asp:TemplateField>
        </Columns>
       
        <SelectedRowStyle BackColor="Silver" />
       
    </asp:GridView>
    
</asp:Content>
