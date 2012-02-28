<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebApplication1.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<asp:Panel ID="pnlError" runat="server" Visible="false" CssClass="alert-message error">
<p>
    <asp:Literal ID="ltlError" runat="server"></asp:Literal>
</p>
</asp:Panel>

<asp:Panel ID="pnlSuccess" runat="server" Visible="false" CssClass="alert-message success">
<p>
    <asp:Literal ID="ltlSuccess" runat="server"></asp:Literal>
</p>
</asp:Panel>

<fieldset id="fldAdd" runat="server">

    <div class="clearfix" id="divFirstName" runat="server">
        <asp:Label ID="lblFirstName" runat="server" Text="First Name" AssociatedControlID="txtFirstName"></asp:Label>
        <div class="input">
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <span ID="helpFirstName" runat="server" class="help-inline" visible="false">Please enter a first name</span>
        </div>
    </div>

    <div class="clearfix" id="divLastName" runat="server">
        <asp:Label ID="lblLastName" runat="server" Text="Last Name" AssociatedControlID="txtLastName"></asp:Label>
        <div class="input">
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <span ID="helpLastName" runat="server" class="help-inline" visible="false">Please enter a last name</span>
        </div>
    </div>

    <div class="clearfix" id="divPhoneNo" runat="server">
        <asp:Label ID="lblPhoneNo" runat="server" Text="Phone Number" AssociatedControlID="txtPhoneNo"></asp:Label>
        <div class="input">
            <asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox>
            <span ID="helpPhoneNo" runat="server" class="help-inline" visible="false">Please enter a phone number</span>
        </div>
    </div>

    <div class="actions">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn primary" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click" />
    </div>
</fieldset>
    
</asp:Content>

