<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="FriendshipRequest.aspx.cs" Inherits="FriendshipRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper">
        <section class="content">
            <div class="row">
                <div class="col-md-offset-2 col-md-8">
                    <div class="nav-tabs-custom">
                        <div class="single-product">
                             <asp:DataList Width="100%" ID="dlRequestFriendShip" runat="server" CellPadding="4" ForeColor="#333333">
                                 <AlternatingItemStyle BackColor="White" />
                                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                 <ItemStyle BackColor="#EFF3FB" />
                                 <ItemTemplate>
                                      <asp:HyperLink ID="hypName" Width="100px" ForeColor="Red"  Text='<%# FindName(Eval("FollowerUserId")) %>' NavigateUrl='<%# "~/UserProfile.aspx?userId="+Eval("FollowerUserId") %>' runat="server"></asp:HyperLink>
                                    <asp:HyperLink ID="hypSurname" Width="100px" Text='<%# FindSurname(Eval("FollowerUserId")) %>' ForeColor="Red" NavigateUrl='<%# "~/UserProfile.aspx?userId="+Eval("FollowerUserId") %>' runat="server"></asp:HyperLink>
                                     <asp:HyperLink ID="hypApproval"  NavigateUrl='<%# "~/FriendshipRequest.aspx?approval="+Eval("FollowerUserId") %>' runat="server">Approval</asp:HyperLink>
                                     <asp:HyperLink ID="hypDelete"  NavigateUrl='<%# "~/FriendshipRequest.aspx?delete="+Eval("FollowerUserId") %>' runat="server">Delete</asp:HyperLink>
                                 </ItemTemplate>
                                 <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                             </asp:DataList>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

