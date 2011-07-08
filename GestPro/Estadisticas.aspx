<%@ Page Language="C#" MasterPageFile="~/Master.Master"  AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="GestPro.Estadisticas" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


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
       <asp:Label ID="LblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large"  Text="Estadisticas"></asp:Label>
  </h1>

  <div>
      
      <br />
      <table>
      <tr>
      <td>
      <table style="width:100%;">
          <tr>
              <td style="width:200px;">
                  <asp:Label ID="LblProyecto" runat="server" Text="Proyecto:"></asp:Label>
              </td>
              <td >
                  <asp:DropDownList ID="CmbProyectos" runat="server" AutoPostBack="True" 
                      Width="200px" onselectedindexchanged="CmbProyectos_SelectedIndexChanged">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="LblCantCasos" runat="server" Text="Cantidad de Casos:" ></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtCantCasos" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="LblEnPlan" runat="server" Text="En Planificación:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtPlan" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="LblEnImp" runat="server" Text="En Implementación:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtImple" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="LblEnPru" runat="server" Text="En Prueba:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtPrueb" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="LblEnFin" runat="server" Text="Finalizados:"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="TxtFin" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
              </td>
          </tr>
      </table>
     </td>
      <td>
      <table>
        <tr>
            <td> 
             
                <asp:Chart ID="ChartCasos" runat="server" Palette="BrightPastel" BackColor="#F3DFC1" BorderDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1" >
                 <titles>
				    <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Casos" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
			     </titles>
                 <legends>
				     <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="True" Name="Default"></asp:Legend>
				  </legends>
                   <borderskin SkinStyle="Emboss"></borderskin>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1"  BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
					        <area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
						    <axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
						        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
							    <MajorGrid LineColor="64, 64, 64, 64" />
					        </axisy>
						    <axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
						        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
							    <MajorGrid LineColor="64, 64, 64, 64" />
						    </axisx>
					    </asp:ChartArea>
				    </chartareas>
                </asp:Chart>
            </td>
        
        </tr>
      
      </table>
      </td>
      </tr>
      </table>
  </div>
</asp:Content>
