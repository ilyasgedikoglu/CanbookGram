using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FriendshipRequest : System.Web.UI.Page
{
    CANBOOKGRAMEntities _db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["MyId"] != null)
            {
                using (_db=new CANBOOKGRAMEntities())
                {
                    var UserId = Convert.ToInt32(Session["MyId"]);

                    if (Request["approval"] != null)
                    {
                        var FollowerUserId = Convert.ToInt32(Request["approval"]);

                        var follower = (from x in _db.Follower where (x.isActive == true && x.isApproval == false && x.UserId == UserId && x.FollowerUserId == FollowerUserId) select x).SingleOrDefault();

                        follower.isApproval = true;

                        Followed fd = new Followed();
                        fd.FollowedUserId = UserId;
                        fd.UserId = FollowerUserId;
                        fd.isActive = true;
                        _db.Followed.Add(fd);

                        _db.SaveChanges();

                        Response.Redirect("FriendshipRequest.aspx");
                    }
                    if (Request["delete"] != null)
                    {
                        var FollowerUserId = Convert.ToInt32(Request["delete"]);

                        var follower = (from x in _db.Follower where x.isApproval == true && x.UserId == UserId && x.FollowerUserId == FollowerUserId && x.isActive == true select x).SingleOrDefault();
                        if (follower != null)
                        {
                            follower.isApproval = false;
                            follower.isActive = false;
                            _db.SaveChanges();
                        }

                        var followed = (from x in _db.Followed where x.UserId == FollowerUserId && x.FollowedUserId == UserId && x.isActive == true select x).SingleOrDefault();
                        if (followed != null)
                        {
                            followed.isActive = false;
                            _db.SaveChanges();
                        }
                    }
                    var followers = (from x in _db.Follower where (x.isActive == true && x.isApproval == false && x.UserId == UserId) select x).ToList();

                    dlRequestFriendShip.DataSource = followers;
                    dlRequestFriendShip.DataBind();
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