<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="SharePicture.aspx.cs" Inherits="SharePicture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <div class="box-header">
                            <h3 class="box-title">Share Picture</h3>
                        </div>
                        <div class="box-body">
                            <ul class="list-group">
                                <li class="list-group-item">
                                    <asp:Label ID="Label1" runat="server" Width="100" Text="Picture"></asp:Label>
                                    <asp:FileUpload ID="fuPicture" runat="server" />
                                </li>
                                <li class="list-group-item">
                                    <asp:Label ID="Label2" runat="server" Width="100px" Text="AltText"></asp:Label>
                                    <asp:TextBox ID="txtAltText" runat="server"></asp:TextBox>
                                </li>
                                <li class="list-group-item">
                                    <asp:Label ID="Label3" Width="100px" runat="server" Text=""></asp:Label>
                                    <asp:Button ID="btnShare" runat="server" Text="Share" OnClick="btnShare_Click" />
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

