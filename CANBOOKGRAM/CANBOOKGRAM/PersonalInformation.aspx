<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="PersonalInformation.aspx.cs" Inherits="PersonalInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <section class="content">
            <div class="row">
                <div class="col-md-offset-2 col-md-8">
                    <div class="nav-tabs-custom">
                        <div class="single-product">
                            <center><asp:Image ID="imgUser" CssClass="img-bordered img-responsive" Width="200px" Height="200px" runat="server" /></center>
                            <br />
                            <center><asp:Label ID="lblPicture" ForeColor="Red" runat="server" Text="Change your profile picture"></asp:Label></center>
                            <center><asp:FileUpload ID="fuUser" runat="server" /></center>
                            <br />
                            <asp:Button ID="btnChangePicture" Width="100%" runat="server" Text="Change Picture" OnClick="btnChangePicture_Click" />
                            <br />
                            <hr />
                            <br />
                            <div class="container">
                                <asp:Label ID="lblName" Width="10%" runat="server" ForeColor="Red" Text="Name : "></asp:Label>
                                <asp:TextBox ID="txtName" Width="40%" runat="server"></asp:TextBox>
                                <br />
                                <asp:Label ForeColor="Red" Width="10%" ID="lblSurname" runat="server" Text="Surname : "></asp:Label>
                                <asp:TextBox ID="txtSurname" Width="40%" runat="server"></asp:TextBox>
                                <br />
                                 <asp:Label ForeColor="Red" Width="10%" ID="lblPassword" runat="server" Text="Password : "></asp:Label>
                                <asp:TextBox ID="txtPassword" TextMode="Password" Width="40%" runat="server"></asp:TextBox>
                                <br />
                                 <asp:Label ID="lblEmail" ForeColor="Red" Width="10%" runat="server" Text="Email : "></asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="40%"></asp:TextBox>
                                <br />
                                <asp:Label ID="lblUserName" ForeColor="Red" Width="10%" runat="server" Text="Username : "></asp:Label>
                                <asp:TextBox ID="txtUserName" runat="server" Width="40%"></asp:TextBox>
                                <br />
                                 <asp:Label ID="lblEducation" ForeColor="Red" Width="10%" runat="server" Text="Education : "></asp:Label>
                                <asp:TextBox ID="txtEducation" runat="server" Width="40%"></asp:TextBox>
                                <br />
                                 <asp:Label ID="lblCity" ForeColor="Red" Width="10%" runat="server" Text="City : "></asp:Label>
                                <asp:TextBox ID="txtCity" runat="server" Width="40%"></asp:TextBox>
                                <br />
                                 <asp:Label ID="lblAboutMe" ForeColor="Red" Width="10%" runat="server" Text="AboutMe : "></asp:Label>
                                <asp:TextBox ID="txtAboutMe" runat="server" Width="40%"></asp:TextBox>
                                <br />
                                <br />
                                 <asp:Label ID="Label1" ForeColor="Red" Width="10%" runat="server" Text=""></asp:Label>
                                <asp:Button ID="btnChangeInformation" Width="40%" runat="server" Text="Change Information" OnClick="btnChangeInformation_Click" />
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

