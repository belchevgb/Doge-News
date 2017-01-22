﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="DogeNews.Web.User.Admin.AddNews" MasterPageFile="~/Site.Master" %>

<%@ Register TagPrefix="UserControl" Src="~/UserControls/News/CreateNewsArticle.ascx" TagName="NewsArticleEditor" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" type="text/css" href="../../Content/User/Admin/AddNews/css/add-news.css" />
    <script>$(document).ready(() => $('select').material_select());</script>

    <!-- TITLE -->
    <asp:RequiredFieldValidator
        ErrorMessage="Title is required."
        runat="server"
        Display="Dynamic"
        ControlToValidate="TitleInput">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator
        runat="server"
        Display="Dynamic"
        ErrorMessage="The title must be between 5 and 30 characters."
        ControlToValidate="TitleInput"
        ValidationExpression=".{5,30}">
    </asp:RegularExpressionValidator>
    <div class="input-field col s12">
        <input id="TitleInput" runat="server">
        <label for="TitleInput" class="">Title</label>
    </div>


    <!-- IMAGE UPLOAD -->
    <asp:RequiredFieldValidator
        ErrorMessage="Uploading image is required."
        runat="server"
        Display="Dynamic"
        ControlToValidate="ImageFileUpload">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator
        runat="server"
        Display="Dynamic"
        ErrorMessage="The file must have.jpeg/.png extension."
        ControlToValidate="ImageFileUpload"
        ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$">
    </asp:RegularExpressionValidator>


    <!-- IMAGE UPLOAD -->
    <div class="file-field input-field" id="file-upload-container">
        <div class="btn">
            <span>Image</span>
            <asp:FileUpload runat="server" ID="ImageFileUpload" />
        </div>
        <div class="file-path-wrapper">
            <input class="file-path" type="text">
        </div>
    </div>


    <!-- TINYMCE EDITOR -->
    <UserControl:NewsArticleEditor runat="server" ID="AddNewsControl" />


    <!-- CATEGORY -->
    <asp:RequiredFieldValidator
        ErrorMessage="Category is required."
        runat="server"
        Display="Dynamic"
        ControlToValidate="CategorySelect">
    </asp:RequiredFieldValidator>
    <div class="input-field col s12 m6" id="select-container">
        <div class="select-wrapper icons">
            <select class="icons initialized" id="CategorySelect" runat="server">
                <option value="" disabled selected>Category</option>
                <option value="0" data-icon="http://gallery.nickchill.com/img/s/v-3/p1369326252-3.jpg" class="left circle">Breaking</option>
                <option value="1" data-icon="https://s-media-cache-ak0.pinimg.com/originals/3d/9e/2f/3d9e2fd7da4d52c4983cfb4a4fcb3d17.jpg" class="left circle">Sports</option>
                <option value="2" data-icon="https://www.nickrains.com/wp-content/uploads/2014/07/Tasmania_20111210-1041.jpg" class="left circle">Weather</option>
                <option value="3" data-icon="http://www.dianamarahenry.com/images/VVAWholdingupgun_001.jpg" class="left circle">Political</option>
                <option value="4" data-icon="http://www.alessandropuccinelli.com/wp-content/uploads/2013/06/MTA-022.jpg" class="left circle">Business</option>
            </select>
        </div>
    </div>


    <a class="waves-effect waves-light btn" onserverclick="AddNewsClick" runat="server">
        <i class="material-icons left">done</i>button
    </a>
</asp:Content>

