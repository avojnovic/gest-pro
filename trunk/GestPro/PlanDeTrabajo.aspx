<%@ Page Language="C#" MasterPageFile="~/Master.Master"  AutoEventWireup="true" CodeBehind="PlanDeTrabajo.aspx.cs" Inherits="GestPro.PlanDeTrabajo" %>

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



  </div>
</asp:Content>
