<%@ Page Language="C#" MasterPageFile="~/Master.Master"  AutoEventWireup="true" CodeBehind="PlanDeTrabajo.aspx.cs" Inherits="GestPro.PlanDeTrabajo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Charting" Assembly="Telerik.Web.UI" %>


<%@ Register Src="~/controls/DatePicker.ascx" TagPrefix="ctrol" TagName="DatePicker" %>
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
      <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Plan de Trabajo"></asp:Label>
  </h1>
  <div>

   
    <center>
     <asp:Panel runat="server" ID="panel1" Visible="true"  Width="600px" style="background-color:#DDDDDD">
     <table border="0" cellpadding="0" cellspacing="0">
            <tr>
             <td colspan="2"  align="center">
                  <asp:Label ID="Label6" runat="server" CssClass="titulosPaneles" Text="Asignación de trabajo"></asp:Label>
              </td>
            </tr>
             <tr  style=" height:20px;">
             <td colspan="2"  align="center">
             </td>
          </tr>
          <tr>
              <td style="width:134px;" >
                  <asp:Label ID="Label14" runat="server" Text="Caso"></asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CmbCaso"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
              </td>
               <td style="width:400px;">
                  <asp:DropDownList ID="CmbCaso" runat="server" Width="100%">
                  </asp:DropDownList>
              </td>
          </tr>
           <tr>
              <td  >
                  <asp:Label ID="Label1" runat="server" Text="Recurso"></asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CmbRecurso"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
              </td>
               <td style="width:400px;">
                  <asp:DropDownList ID="CmbRecurso" runat="server" Width="100%">
                  </asp:DropDownList>
              </td>
          </tr>
           <tr>
              <td>
                  <asp:Label ID="Label2" runat="server" Text="Fecha Inicio"></asp:Label>

              </td>
               <td style="width:200px;">
                  <ctrol:DatePicker runat="server" ID ="dtFechaInicio" />
              </td>
          </tr>
           <tr>
              <td >
                  <asp:Label ID="Label3" runat="server" Text="Fecha Fin"></asp:Label>

              </td>
               <td style="width:200px;">
                  <ctrol:DatePicker runat="server" ID ="dtFechaFin" />
              </td>
          </tr>
           <tr>
              <td >
                  <asp:Label ID="Label4" runat="server" Text="Cantidad de Horas"></asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcanthoras"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="add" />
              </td>
               <td style="width:200px;">
                   <asp:TextBox runat="server" ID="txtcanthoras" Width="20px" />
                   <act:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99" MaskType="Number" TargetControlID="txtcanthoras">
                   </act:MaskedEditExtender>
              </td>
          </tr>
          <tr  style=" height:20px;">
             <td colspan="2"  align="center">
             </td>
          </tr>
          <tr valign="middle">
                <td colspan="2"  align="center" valign="middle">
                    <asp:ImageButton ImageUrl="~/Images/save.png" ID="btnSave" runat="server" OnClick="btnSave_OnClick" ValidationGroup="add" Width="32px" Height="32px" />
                  

              </td>
          </tr>
           <tr valign="middle">
                <td colspan="2"  align="center" valign="middle">
                      <asp:Label ID="Label5" runat="server" Text="Grabar" AssociatedControlID="btnSave" />
              </td>
          </tr>
    </table>
      </asp:Panel>
         <act:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" TargetControlID="panel1"
                    Radius="8" Color="#DDDDDD" Corners="All" Enabled="true">
                </act:RoundedCornersExtender>

    </center>
    <br />


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" AllowPaging="true" HorizontalAlign="Center" Width="100%" PageSize="20"
          CssClass="mGrid"  PagerStyle-CssClass="pgr"  AlternatingRowStyle-CssClass="alt"  OnPageIndexChanging="grid_OnPageIndexChanging"  >
        <PagerSettings PageButtonCount="5" />
        <Columns>
          

              <asp:TemplateField HeaderText="Nro Caso" SortExpression="Caso">
                 <ItemTemplate>
                      <%# Eval("Caso.NroCaso")%>
                 </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Descripción Caso" SortExpression="Caso">
                 <ItemTemplate>
                      <%# Eval("Caso.Descripcion")%>
                 </ItemTemplate>
             </asp:TemplateField>

               <asp:TemplateField HeaderText="Etapa Caso" SortExpression="Caso">
                 <ItemTemplate>
                      <%# Eval("Caso.EtapaCaso.Nombre")%>
                 </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Recurso" SortExpression="Recurso">
                 <ItemTemplate>
                      <%# Eval("Recurso.NombreCompleto")%>
                 </ItemTemplate>
             </asp:TemplateField>

             <asp:BoundField DataField="FechaInicio" HeaderText="Fecha de Inicio" ReadOnly="True" SortExpression="FechaInicio" />
            <asp:BoundField DataField="FechaFin" HeaderText="Fecha de Fin" SortExpression="FechaFin" />
            <asp:BoundField DataField="CantHoras" HeaderText="Cantidad Horas" SortExpression="CantHoras" />
             <asp:TemplateField  ItemStyle-Width="25px">
                 <ItemTemplate>  
                    <a href="PlanDeTrabajo.aspx?id=<%# Eval("id") %>" >
                        <img alt="Editar" src="../images/File-Open-icon.png" border="0"  width="16px" height="16px"/>
                      </a>
                  </ItemTemplate>
             </asp:TemplateField>
             
           
        </Columns>
       
        <SelectedRowStyle BackColor="Silver" />
       
    </asp:GridView>   
    <br />

    <center>
      <telerik:RadChart ID="RadChartCasos" SkinsOverrideStyles="true" runat="server"  ChartTitle-TextBlock-Text="Distribucion de Trabajo"
         Width="800px" Height="300px" >
       </telerik:RadChart>
      </center> 

  </div>
</asp:Content>
