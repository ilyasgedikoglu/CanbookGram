<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="MessageDetail.aspx.cs" Inherits="MessageDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                                    <asp:DataList ID="dlMessageDetail" Width="100%" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Both">
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <ItemStyle BackColor="White" />
                                        <ItemTemplate>
                                            <asp:Label Width="650px" ID="lblMessageDetail" Font-Size="Medium" ForeColor="Black" runat="server" Text='<%# Eval("MessageDetail") %>'></asp:Label><asp:Label ID="lblSenderId" runat="server" Font-Size="Small" ForeColor="#ff6666" Width="150px" Text='<%# FindSenderId(Eval("SenderId")) %>'></asp:Label><asp:Label Font-Size="Smaller" ForeColor="#ff3300" Width="150px" ID="lblTime" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                                        </ItemTemplate>
                                        <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    </asp:DataList>
                                <br />
                                <hr />
                                <br />
                                <li class="list-group-item">
                                    <asp:TextBox ID="txtMessage" Width="100%" TextMode="MultiLine" placeholder="Message" runat="server"></asp:TextBox>
                                    <br />
                                    <asp:Button BackColor="#993399" ForeColor="White" ID="btnSend" runat="server" Text="Send Message" Width="100%" OnClick="btnSend_Click" />
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

