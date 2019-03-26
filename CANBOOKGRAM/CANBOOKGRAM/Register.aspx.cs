using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        RegisterService rs = new RegisterService();
        rs.userRegister(txtName.Text, txtSurName.Text, txtEmail.Text, txtPassword.Text, txtUsername.Text);
        Response.Redirect("Login.aspx");
    }
}