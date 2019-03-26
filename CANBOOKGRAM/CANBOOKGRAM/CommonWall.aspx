<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="CommonWall.aspx.cs" Inherits="CommonWall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <div class="single-product">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-offset-1 col-md-8 col-md-offset-1">
                                        <div class="form-horizontal">
                                            <div class="box-body">
                                                <asp:DataList ID="dlFollowedPicture" Width="100%" runat="server">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgPicture" ImageUrl='<%# "~/images/"+Eval("PhotoPath") %>' CssClass="img-responsive" Height="100%" Width="100%" runat="server" /><asp:Label ID="lblName" ForeColor="Red" Width="150px" Text='<%# FindNameSurname(Eval("UserId")) %>' runat="server"></asp:Label><asp:HyperLink ForeColor="Brown" ID="hypCommentWrite" runat="server" NavigateUrl='<%# "~/PictureDetail.aspx?detail="+Eval("Id") %>' Text='<%# FindCommentCount(Eval("Id")) %>'></asp:HyperLink>
                                                        <asp:HyperLink ID="HyperLink3" NavigateUrl='<%# "~/PictureDetail.aspx?detail="+Eval("Id") %>' runat="server" Width="100px" Text="comment"></asp:HyperLink><asp:HyperLink ForeColor="Brown" ID="HyperLink1" runat="server" NavigateUrl='<%# "~/PictureLike.aspx?like="+Eval("Id") %>' Text='<%# FindLikeCount(Eval("Id")) %>'></asp:HyperLink>
                                                        <asp:HyperLink ID="HyperLink4" NavigateUrl='<%# "~/PictureDetail.aspx?detail="+Eval("Id") %>' runat="server" Width="100px" Text="like"></asp:HyperLink><asp:HyperLink ForeColor="Brown" ID="HyperLink2" runat="server" NavigateUrl='<%# "~/PictureLike.aspx?dislike="+Eval("Id") %>' Text='<%# FindDisLikeCount(Eval("Id")) %>'></asp:HyperLink>
                                                        <asp:HyperLink ID="HyperLink5" runat="server" Text="dislike" NavigateUrl='<%# "~/PictureDetail.aspx?detail="+Eval("Id") %>' Width="120px"></asp:HyperLink><asp:Label ID="lblCreatedDate" runat="server" ForeColor="Orange" Text='<%# Eval("CreatedDate") %>'></asp:Label>
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
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

