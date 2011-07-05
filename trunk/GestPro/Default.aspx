<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestPro.Principal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script src="jquery.js"></script>

 <script>

     $(document).ready(
        function () {
            $("#image").animate({ Height: '+=316' }, 800, function () { })
                    ;
                    }
                   )

 </script>
 <center>
  <div id="image">
   <asp:Image runat="server" ID="ImageBkg"  ImageUrl="~/Images/bkground.png"  />
   </div>

 <div id="gridDiv" >
  <asp:Panel runat="server" ID="panel1" Visible="true"   Width="735px"  style="background-color:#424242">
 <asp:Label ID="lblPendientes" Text="Casos Pendientes" runat="server" ForeColor="White"  Font-Bold="True" Font-Size="Large"  ></asp:Label>
  </asp:Panel>
         <act:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="panel1"
                    Radius="8" Color="#424242" Corners="All" Enabled="true">
                </act:RoundedCornersExtender>


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="true"
        HorizontalAlign="Center" Width="735px" 
        PageSize="5"
          CssClass="mGrid"  PagerStyle-CssClass="pgr"  AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="grid_OnPageIndexChanging" >
        <PagerSettings PageButtonCount="5" />
        <Columns>
            <asp:BoundField DataField="NroCasoString" HeaderText="Número Caso" ReadOnly="True" SortExpression="numero caso" />
            <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" SortExpression="proyecto" />
            <asp:BoundField DataField="PrioridadString" HeaderText="Prioridad" SortExpression="prioridad" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="descripcion" />
            <asp:TemplateField  ItemStyle-Width="25px">
                 <ItemTemplate>  
                    <a href="Edit_Caso.aspx?id=<%# Eval("id") %>" >
                        <img alt="Abrir" src="../images/File-Open-icon.png" border="0"  width="16px" height="16px"/>
                      </a>
                  </ItemTemplate>
             </asp:TemplateField>
        </Columns>
       
        <SelectedRowStyle BackColor="Silver" />
       
    </asp:GridView>   
    </div>
    </center>
</asp:Content>
