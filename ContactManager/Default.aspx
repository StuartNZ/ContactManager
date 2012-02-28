<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:GridView ID="grdContacts" runat="server" AutoGenerateEditButton="false" AutoGenerateColumns="false" ShowFooter="false" 
        AllowPaging="true" ShowHeaderWhenEmpty="True" ShowHeader="true" CssClass="zebra-striped" PagerSettings-Visible="false"
        PageSize="100">
        <Columns>                  
            <asp:BoundField DataField="ContactID" HeaderText="#" ReadOnly="true"/>                    
            <asp:BoundField DataField="FirstName"  HeaderText="First Name"/>
            <asp:BoundField DataField="LastName"   HeaderText="Last Name"/>  
            <asp:BoundField DataField="PhoneNo"   HeaderText="Phone Number"/>  
            <asp:HyperLinkField Text="Edit" ControlStyle-CssClass="btn small"
                      DataNavigateUrlFormatString="~/Edit.aspx?contactid={0}"
                      DataNavigateUrlFields="ContactID" />
        </Columns>
    </asp:GridView>

</asp:Content>
