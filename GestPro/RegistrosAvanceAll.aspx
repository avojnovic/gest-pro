<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master"  CodeBehind="RegistrosAvanceAll.aspx.cs" Inherits="GestPro.RegistrosAvanceAll" %>



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

  <h1 style="border-bottom: 1px solid #FF0000; font-size: 15pt;">
      <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Registros Avance"></asp:Label>
  </h1>


  <div>

   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="true" HorizontalAlign="Center" Width="100%" PageSize="20"
          CssClass="mGrid"  PagerStyle-CssClass="pgr"  AlternatingRowStyle-CssClass="alt"  OnPageIndexChanging="grid_OnPageIndexChanging"  >
        <PagerSettings PageButtonCount="5" />
        <Columns>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" ItemStyle-Width="200px" />
            <asp:BoundField DataField="Tiempo" HeaderText="Tiempo" ReadOnly="True" SortExpression="Tiempo" ItemStyle-Width="100px" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:TemplateField HeaderText="Recurso" SortExpression="Recurso">
                 <ItemTemplate>
                      <%# Eval("Recurso.NombreCompleto")%>
                 </ItemTemplate>
             </asp:TemplateField>
        </Columns>
       
        <SelectedRowStyle BackColor="Silver" />
       
    </asp:GridView>     
        
  </div>
</asp:Content>