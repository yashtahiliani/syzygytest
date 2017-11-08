<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<h1>SYZYGY Test</h1>
<br />
<br />
<h2>Upload a csv file:</h2>
<br />
<asp:FileUpload ID="upfile" runat="server" />

<br />
<asp:Button ID="sub" runat="server" Text="Submit" OnClick="sub_Click" />
<br />
<br />
<asp:Literal runat="server" ID="res"></asp:Literal>

</asp:Content>
