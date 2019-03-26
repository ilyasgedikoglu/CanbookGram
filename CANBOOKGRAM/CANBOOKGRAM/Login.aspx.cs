using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;

        LoginService ls = new LoginService();

        User u = ls.isUserFound(email, password);
        if (u != null)
        {
            Session["MyId"] = u.Id;
            Response.Redirect("~/CommonWall.aspx" + "?user=" + Session["MyId"]);

        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "User not found!!";
        }
    }
}