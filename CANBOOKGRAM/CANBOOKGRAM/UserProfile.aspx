<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <section class="content-header">
            <ol class="breadcrumb">
                <li>
                    <asp:LinkButton ID="lbTrendPost" runat="server">Trend Posts</asp:LinkButton>
                    <span id="spn1" style="color: orangered">|</span>
                    <asp:LinkButton ID="lbPersonalInformation" runat="server">Change Personal Information</asp:LinkButton>
                    <span id="spn2" style="color: orangered">|</span>
                    <asp:LinkButton ID="hypFriendshipRequest" runat="server" PostBackUrl="~/FriendshipRequest.aspx">Friendship Request</asp:LinkButton>
                    <span id="spn3" style="color: orangered">|</span>
                    <asp:LinkButton ID="lbMessage" runat="server" PostBackUrl="~/SendMessage.aspx">Send Message</asp:LinkButton>
                    <span id="spn4" style="color: orangered">|</span>
                    <asp:HyperLink ID="hypSharePicture" NavigateUrl="~/SharePicture.aspx" runat="server">Share Picture</asp:HyperLink>
                </li>
            </ol>
        </section>
        <br />
        <section class="content">
            <div class="row">
                <div class="col-md-3">
                    <!-- Profile Image -->
                    <div class="box box-primary">
                        <div class="box-body box-profile">
                            <asp:Image ID="imgProfilePicture" CssClass="profile-user-img img-responsive img-circle" AlternateText="User Profile Picture" runat="server" />
                            <asp:Label CssClass="profile-username text-center" ID="lblName" runat="server" Text=""></asp:Label>
                            <br />
                            <%-- <asp:Label ID="lblDetail" runat="server" Text="Bilgisayar Mühendisliği" CssClass="text-muted text-center"></asp:Label>--%>
                            <ul class="list-group list-group-unbordered">
                                <li class="list-group-item">
                                    <b>
                                        <asp:HyperLink ID="hypFollower" runat="server" NavigateUrl="~/Followers.aspx">Followers</asp:HyperLink></b><a class="pull-right"><asp:Label ID="lblFollower" runat="server" Text=""></asp:Label></a>
                                </li>
                                <li class="list-group-item">
                                    <b>
                                        <asp:HyperLink ID="hypFollowed" runat="server" NavigateUrl="~/Following.aspx">Following</asp:HyperLink></b><a class="pull-right"><asp:Label ID="lblFollowed" runat="server" Text=""></asp:Label></a>
                                </li>
                            </ul>
                            <asp:Button CssClass="btn btn-primary btn-block" ID="btnFollow" runat="server" Text="Follow Me" OnClick="btnFollow_Click" />
                            <br />
                            <asp:Button CssClass="btn btn-danger btn-block" ID="btnQuitFollow" runat="server" Text="Quit Follow" Visible="false" OnClick="btnQuitFollow_Click" />
                            <asp:Label ID="lblInformation" ForeColor="Red" runat="server" Text="" Visible="false"></asp:Label>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->

                    <!-- About Me Box -->
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">About Me</h3>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <strong><i class="fa fa-book margin-r-5"></i>
                                <asp:Label ID="lblEdu" runat="server" Text="Education"></asp:Label></strong>
                            <p class="text-muted">
                                <asp:Label ID="lblEducation" runat="server" Text=""></asp:Label>
                            </p>
                            <hr>
                            <strong><i class="fa fa-map-marker margin-r-5"></i>
                                <asp:Label ID="lblLoca" runat="server" Text="Location"></asp:Label></strong>
                            <p class="text-muted">
                                <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                            </p>
                            <hr>
                            <strong><i class="fa fa-pencil margin-r-5"></i>
                                <asp:Label ID="lblBir" runat="server" Text="BirthDate"></asp:Label></strong>
                            <p>
                                <asp:Label ID="lblBirthDate" runat="server" Text=""></asp:Label>
                            </p>
                            <hr>
                            <strong><i class="fa fa-file-text-o margin-r-5"></i>
                                <asp:Label ID="lblAbo" runat="server" Text="Notes"></asp:Label></strong>
                            <p>
                                <asp:Label ID="lblAboutMe" runat="server" Text=""></asp:Label>
                            </p>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>
                <!-- /.col -->
                <div class="col-md-9">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#activity" data-toggle="tab">Activity</a></li>
                            <%--                            <li><a href="#timeline" data-toggle="tab">Timeline</a></li>
                            <li><a href="#settings" data-toggle="tab">Settings</a></li>--%>
                        </ul>
                        <div class="tab-content">
                            <div class="active tab-pane" id="activity">
                                <div class="post">
                                    <div class="user-block">
                                        <asp:DataList RepeatColumns="1" ID="ddlPicture" runat="server" Width="100%">
                                            <ItemTemplate>
                                                <asp:Image Width="100%" Height="100%" ID="imgPicture" CssClass="img-responsive" runat="server" ImageUrl='<%# "~/images/"+Eval("PhotoPath") %>' ImageAlign="Middle" />
                                                <br />
                                                <br />
                                                <br />
                                                <asp:LinkButton PostBackUrl='<%# "~/PictureDetail.aspx?detail="+Eval("Id") %>' ID="lbPictureDetail" CssClass="btn btn-success" runat="server">Picture Detail</asp:LinkButton>
                                                <br />
                                                <br />
                                                <asp:HyperLink ForeColor="Red" ID="hypLike" NavigateUrl='<%# "~/PictureLike.aspx?like="+Eval("Id") %>' Text="Like :" runat="server"></asp:HyperLink>
                                                <asp:Label Text='<%# FindLikeCount(Eval("Id")) %>' ForeColor="Black" ID="lblLike" runat="server"></asp:Label>
                                                <br />
                                                <asp:HyperLink ForeColor="Red" ID="HyperLink1" NavigateUrl='<%# "~/PictureLike.aspx?dislike="+Eval("Id") %>' Text="Dislike :" runat="server"></asp:HyperLink>
                                                <asp:Label Text='<%# FindDisLikeCount(Eval("Id")) %>' ForeColor="Black" ID="Label1" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ForeColor="Red" ID="lblCommentLabel" runat="server" Text="Comment :"></asp:Label><asp:Label ForeColor="Black" ID="lblComment" runat="server" Text='<%# FindCommentCount(Eval("Id")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle BorderColor="PowderBlue" BorderStyle="Groove" BorderWidth="1px" VerticalAlign="Middle" HorizontalAlign="Center" CssClass="img-bordered img-rounded" BackColor="WhiteSmoke" />
                                        </asp:DataList>
                                    </div>
                                </div>
                            </div>
                            <!-- /.post -->
                        </div>
                    </div>
                    <!-- /.tab-content -->
                </div>
                <!-- /.nav-tabs-custom -->
            </div>
        </section>
        <!-- /.col -->
    </div>
    <!-- /.row -->
</asp:Content>

