using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MyId"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            using (CANBOOKGRAMEntities _db = new CANBOOKGRAMEntities())
            {
                var id = Convert.ToInt32(Session["MyId"]);
                User user = (from x in _db.User where x.Id == id && x.isActive == true select x).SingleOrDefault();
                imgUserPicture.ImageUrl = "~/images/" + user.Photo;
                hypName.Text = user.FirstName + " " + user.LastName;
                hypName.NavigateUrl = "~/UserProfile.aspx" + "?userId=" + Session["MyId"];
                hypLogo.NavigateUrl= "~/CommonWall.aspx" + "?user=" + Session["MyId"];

                List<User> UserList = (from x in _db.User where(x.isActive==true)select x).ToList();
                rptUsers.DataSource = UserList.OrderByDescending(x=>x.UserName);
                rptUsers.DataBind();
            }
        }
    }
}
