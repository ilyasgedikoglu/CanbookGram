<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="PictureDetail.aspx.cs" Inherits="PictureDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <div class="single-product">
                            <div class="product-f-image">
                                <center><asp:Image ID="imgPicture" runat="server"></asp:Image></center>
                                <br />
                                <asp:Label ID="Label2" runat="server" Width="400px" Text=""></asp:Label><asp:Button Height="40px" BackColor="Green" ForeColor="White" Width="100px" ID="btnLike" runat="server" Text="Like" OnClick="btnLike_Click"></asp:Button>&nbsp;<asp:Button Height="40px" BackColor="Red" ForeColor="White" Width="100px" ID="btnDislike" runat="server" Text="Dislike" OnClick="btnDislike_Click"></asp:Button>
                            </div>
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-offset-1 col-md-8 col-md-offset-1">
                                        <!-- form start -->
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtDetail" placeholder="Write Comment" CssClass="form-control" TextMode="MultiLine" Width="100%" runat="server"></asp:TextBox>
                                                </div>
                                                <center><asp:Button ID="btnInsertComment" runat="server" Text="Send Comment" CssClass="btn btn-info" OnClick="btnInsertComment_Click" /></center>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <asp:DataList ID="dlComment" Width="100%" runat="server">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDetail" ForeColor="Black" runat="server" Text='<%# Eval("Detail") %>' Width="100%"></asp:Label>
                                        <hr />
                                        <asp:Label ID="Label1" runat="server" Width="70%" Text=""></asp:Label><asp:Label ID="lblName" ForeColor="Red" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        <asp:Label ID="lblSurname" ForeColor="Red" runat="server" Text='<%# Eval("SurName") %>'></asp:Label>
                                        |
                                        <asp:Label ID="lblCreatedDate" ForeColor="YellowGreen" runat="server" Text='<%# Eval("CreatedDate") %>'></asp:Label>
                                        <br />
                                        <hr />
                                        <br />
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

