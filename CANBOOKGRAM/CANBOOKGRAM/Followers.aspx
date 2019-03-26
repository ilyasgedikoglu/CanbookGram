<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Followers.aspx.cs" Inherits="Followers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper">
        <section class="content">
            <div class="row">
                <div class="col-md-offset-2 col-md-8">
                    <div class="nav-tabs-custom">
                        <div class="single-product">
                            <asp:DataList Width="100%" ID="dlFollowers" runat="server" CellPadding="4" ForeColor="#333333">
                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Width="250px" Text=""></asp:Label>
                                    <asp:HyperLink ID="hypName" Width="100px" ForeColor="Red" Text='<%# FindName(Eval("FollowerUserId")) %>' NavigateUrl='<%# "~/UserProfile.aspx?userId="+Eval("FollowerUserId") %>' runat="server"></asp:HyperLink>
                                    <asp:HyperLink ID="hypSurname" Width="100px" ForeColor="Red" Text='<%# FindSurname(Eval("FollowerUserId")) %>' NavigateUrl='<%# "~/UserProfile.aspx?userId="+Eval("FollowerUserId") %>' runat="server">HyperLink</asp:HyperLink>
                                </ItemTemplate>
                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />

                            </asp:DataList>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

