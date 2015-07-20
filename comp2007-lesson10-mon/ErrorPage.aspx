<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="comp2007_lesson10_mon.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="alert alert-danger" role="alert">
            <h2><strong>Danger! </strong>Oops, Something Went horribly wrong here...</h2>
        </div>
    </div>
</asp:Content>
