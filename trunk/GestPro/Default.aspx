<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestPro.Principal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="margin-right: 0px" >

                        <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" 
                            DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
                            ForeColor="#7C6F57" Orientation="Horizontal" StaticSubMenuIndent="10px">
                            <StaticSelectedStyle BackColor="#5D7B9D" />
                            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                            <DynamicMenuStyle BackColor="#F7F6F3" />
                            <DynamicSelectedStyle BackColor="#5D7B9D" />
                            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                            <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                        </asp:Menu>


    
    </div>
        
    
</asp:Content>
