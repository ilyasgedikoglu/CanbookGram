<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="SendMessage" %>

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
                            <h3 class="box-title">Send Message</h3>
                        </div>
                        <div class="box-body">
                            <ul class="list-group">
                                <li class="list-group-item">
                                    <asp:Label ID="Label1" runat="server" Width="100" Text="Receiver"></asp:Label>
                                    <asp:DropDownList ID="ddlUsers" Width="100%" runat="server"></asp:DropDownList>
                                </li>
                                <li class="list-group-item">
                                    <asp:Label ID="Label2" runat="server" Width="100px" Text="Message"></asp:Label>
                                    <asp:TextBox ID="txtMessage" Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </li>
                                <li class="list-group-item">
                                    <asp:Label ID="Label3" Width="100px" runat="server" Text=""></asp:Label>
                                    <asp:Button BackColor="#993399" ForeColor="White" ID="btnSend" runat="server" Text="Send Message" Width="100%" OnClick="btnSend_Click" />
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div class="content-wrapper">
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <div class="box-header">
                            <h3 class="box-title">Message Box</h3>
                        </div>
                        <div class="box-body">
                            <ul class="list-group">
                                <li class="list-group-item">
                                    <asp:DataList Width="100%" ID="dlMessageBox" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <ItemTemplate>

                                            <asp:Label ID="lblSender" Width="100px" ForeColor="Orange" runat="server" Text='<%# FindSenderId(Eval("SenderId")) %>'></asp:Label>
                                            <span style="color:crimson">-</span>
                                            <asp:Label ID="lblReceiver" Width="100px" runat="server" ForeColor="Orange" Text='<%# FindReceiverId(Eval("ReceiverId")) %>'></asp:Label>
                                            <asp:HyperLink ID="hypMessageDetail" ForeColor="Green" Width="500px" NavigateUrl='<%# "~/MessageDetail.aspx?detail="+Eval("Id") %>' Text="See More" runat="server"></asp:HyperLink>
                                            <asp:HyperLink ID="hypDelete" ForeColor="Red" Text="Delete Message" NavigateUrl='<%# "~/SendMessage.aspx?delete="+Eval("Id") %>' runat="server"></asp:HyperLink>
                                           
                                        </ItemTemplate>
                                        <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    </asp:DataList>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

