<%@ Page Title="" Language="C#" MasterPageFile="~/monday.Master" AutoEventWireup="true" CodeBehind="ErrorPage404.aspx.cs" Inherits="comp2007_lesson10_mon.ErrorPage404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <h1>
            <span class="label label-danger">Page 404</span>
        </h1>
        <br />
        <div class="alert alert-warning" role="alert">
            <h2><strong>Warning! </strong>Oops, Something Happened</h2>
            <p>This page may be temporary un-available or non-existant</p>
        </div>


    </div>
</asp:Content>
