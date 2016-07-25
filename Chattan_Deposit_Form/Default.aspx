<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Chattan_Deposit_Form._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <div>
        <asp:Label ID="Label1" runat="server" Text="Who is the software owner?"></asp:Label>
        <asp:TextBox ID="txtSoftware_Owner" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Who is the beneficiary contact?"></asp:Label>
        <asp:TextBox ID="txtDeposit_Beneficiary" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="What is the account number of this deposit?"></asp:Label>
        <asp:TextBox ID="txtDeposit_Account_Number" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="What is the deposit date?"></asp:Label>
        <asp:Calendar ID="cldrDeposit_Date" runat="server"></asp:Calendar>
    </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text="How will the software be deposited?"></asp:Label>
        <asp:DropDownList ID="dplDeposit_Method" runat="server">
            <asp:ListItem>Flash Drive</asp:ListItem>
            <asp:ListItem>Remote Upload</asp:ListItem>
            <asp:ListItem>Compact Disk</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="Label6" runat="server" Text="What is the software description?"></asp:Label>
        <asp:TextBox ID="txtSoftware_Description" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnAssemble" runat="server" Text="Assemble" OnClick="btnAssemble_Click" />
    </div>
    <div>
        <asp:TextBox ID="txtXML_Input" runat="server" TextMode="MultiLine" Height="163px"></asp:TextBox>
    </div>
    

</asp:Content>
