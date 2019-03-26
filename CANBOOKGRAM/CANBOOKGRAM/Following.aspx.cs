using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Following : System.Web.UI.Page
{
    CANBOOKGRAMEntities _db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["MyId"] != null)
            {
                using (_db = new CANBOOKGRAMEntities())
                {
                    int id = Convert.ToInt32(Session["userId"]);
                    var followings = (from x in _db.Followed where (x.UserId== id && x.isActive==true)select x).OrderByDescending(x => x.Id).ToList();

                    dlFollowing.DataSource = followings;
                    dlFollowing.DataBind();
                }
            }
        }
    }

    public string FindName(object id)
    {
        string Name = "";
        int nid = Convert.ToInt32(id);
        CANBOOKGRAMEntities _db = new CANBOOKGRAMEntities();
        var u = (from x in _db.User where (x.Id == nid && x.isActive == true) select x).SingleOrDefault();

        if (u != null)
        {
            Name = u.FirstName;
        }
        return Name;
    }

    public string FindSurname(object id)
    {
        string Surname = "";
        int snid = Convert.ToInt32(id);
        CANBOOKGRAMEntities _db = new CANBOOKGRAMEntities();
        var u = (from x in _db.User where (x.Id == snid && x.isActive == true) select x).SingleOrDefault();

        if (u != null)
        {
            Surname = u.LastName;
        }
        return Surname;
    }
}