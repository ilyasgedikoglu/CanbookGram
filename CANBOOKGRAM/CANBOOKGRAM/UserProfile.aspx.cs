using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile : System.Web.UI.Page
{
    CANBOOKGRAMEntities _db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["userId"] != null)
        {
            int id = Convert.ToInt32(Request["userId"]);

            using (_db = new CANBOOKGRAMEntities())
            {
                User user = (from x in _db.User where x.Id == id && x.isActive == true select x).SingleOrDefault();
                if (user != null)
                {
                    imgProfilePicture.ImageUrl = "~/images/" + user.Photo;
                    lblName.Text = user.FirstName + " " + user.LastName;

                    var followers = (from x in _db.Follower where x.isApproval==true && x.UserId == id && x.isActive == true select x).ToList();

                    var followed = (from x in _db.Followed where x.UserId == id && x.isActive == true select x).ToList();

                    lblFollower.Text = followers.Count().ToString();
                    lblFollowed.Text = followed.Count().ToString();
                    //----------
                    int id1 = Convert.ToInt32(Session["MyId"]);
                    int id2 = Convert.ToInt32(Request["userId"]);

                    //buton gizleme
                    if (id1==id2)
                    {
                        hypSharePicture.Visible = true;
                        lbMessage.Visible = true;
                        hypFriendshipRequest.Visible = true;
                        lbPersonalInformation.Visible = true;
                        lbPersonalInformation.PostBackUrl = "~/PersonalInformation.aspx" + "?myid=" + Session["MyId"];
                        lbTrendPost.Visible = true;
                        lbTrendPost.PostBackUrl = "~/TrendPost.aspx" + "?myPosts=" + Session["MyId"];
                    }
                    if(id1!=id2)
                    {
                        hypSharePicture.Visible = false;
                        lbMessage.Visible = false;
                        hypFriendshipRequest.Visible = false;
                        lbPersonalInformation.Visible = false;
                        lbTrendPost.Visible = false;
                    }
                    //----------


                    var follower = (from x in _db.Follower where x.UserId == id2 && x.FollowerUserId == id1 && x.isActive == true && x.isApproval == true select x).SingleOrDefault();
                    if (follower != null)
                    {
                        btnQuitFollow.Visible = true;
                        btnFollow.Visible = false;
                        lblInformation.Visible = false;
                    }
                    var follower2 = (from x in _db.Follower where (x.isActive == true && x.isApproval == false && x.UserId == id2 && x.FollowerUserId == id1) select x).SingleOrDefault();
                    if (follower2 != null)
                    {
                        btnFollow.Visible = true;
                        lblInformation.Visible = true;
                        lblInformation.Text = "A friend request was sent";
                    }
                    //----------
                    if (user.Education == null)
                    {
                        lblEducation.Visible = true;
                        lblEdu.Visible = true;
                    }
                    else
                    {
                        lblEducation.Text = user.Education;
                    }
                    if (user.BirthDate == null)
                    {
                        lblBirthDate.Visible = true;
                        lblBir.Visible = true;
                    }
                    else
                    {
                        lblBirthDate.Text = user.BirthDate.Value.Year.ToString();
                    }
                    if (user.AboutMe == null)
                    {
                        lblAboutMe.Visible = true;
                        lblAbo.Visible = true;
                    }
                    else
                    {
                        lblAboutMe.Text = user.AboutMe;
                    }
                    if (user.City == null)
                    {
                        lblLocation.Visible = true;
                        lblLoca.Visible = true;
                    }
                    else
                    {
                        lblLocation.Text = user.City;
                    }

                    Session["userId"] = user.Id;
                    int id3 = Convert.ToInt32(Request["userId"]);

                    var photos = (from x in _db.Photo where (x.UserId == id3 && x.isActive==true) select x).ToList();
                    ddlPicture.DataSource = photos.OrderByDescending(x=>x.CreatedDate);
                    ddlPicture.DataBind();
                }
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void btnFollow_Click(object sender, EventArgs e)
    {
        using (_db = new CANBOOKGRAMEntities())
        {
            int id2 = Convert.ToInt32(Session["userId"]);

            Follower f = new Follower();
            f.UserId = Convert.ToInt32(Session["userId"]);
            f.FollowerUserId = Convert.ToInt32(Session["MyId"]);
            f.isActive = true;
            f.isApproval = false;

            _db.Follower.Add(f);
            _db.SaveChanges();

            //btnFollow.Visible = true;
            //lblInformation.Visible = true;
            //lblInformation.Text = "A friend request was sent";
            Response.Redirect("UserProfile.aspx" + "?userId=" + Convert.ToInt32(Request["userId"]));
        }
    }

    protected void btnQuitFollow_Click(object sender, EventArgs e)
    {
        using (_db = new CANBOOKGRAMEntities())
        {
            int id1 = Convert.ToInt32(Session["MyId"]);
            int id2 = Convert.ToInt32(Session["userId"]);

            var follower = (from x in _db.Follower where x.isApproval==true && x.UserId == id2 && x.FollowerUserId == id1 && x.isActive == true select x).SingleOrDefault();
            if (follower != null)
            {
                follower.isApproval = false;
                follower.isActive = false;
                _db.SaveChanges();
            }

            var followed = (from x in _db.Followed where x.UserId == id1 && x.FollowedUserId == id2 && x.isActive == true select x).SingleOrDefault();
            if (followed != null)
            {
                followed.isActive = false;
                _db.SaveChanges();
            }

            //btnQuitFollow.Visible = false;
            //btnFollow.Visible = true;
            //lblInformation.Visible = false;

            var followers = (from x in _db.Follower where x.UserId == id2 && x.isActive == true select x).ToList();

            var following = (from x in _db.Followed where x.UserId == id2 && x.isActive == true select x).ToList();

            lblFollower.Text = followers.Count().ToString();
            lblFollowed.Text = following.Count().ToString();

            Response.Redirect("UserProfile.aspx" + "?userId=" + Convert.ToInt32(Request["userId"]));
        }
    }

    public int FindLikeCount(object id)
    {
        int LikeCount = 0;
        int lid = Convert.ToInt32(id);
        CANBOOKGRAMEntities _db = new CANBOOKGRAMEntities();
        var l = (from x in _db.Like where (x.PhotoId == lid && x.isActive==true && x.isLike==true) select x).ToList();

        if (l != null)
        {
            LikeCount = l.Count();
        }
        return LikeCount;
    }

    public int FindDisLikeCount(object id)
    {
        int DisLikeCount = 0;
        int lid = Convert.ToInt32(id);
        CANBOOKGRAMEntities _db = new CANBOOKGRAMEntities();
        var l = (from x in _db.Like where (x.PhotoId == lid && x.isActive == true && x.isLike==false) select x).ToList();

        if (l != null)
        {
            DisLikeCount = l.Count();
        }
        return DisLikeCount;
    }

    public int FindCommentCount(object id)
    {
        int CommentCount = 0;
        int cid = Convert.ToInt32(id);
        CANBOOKGRAMEntities _db = new CANBOOKGRAMEntities();
        var l = (from x in _db.Comment where (x.PhotoId == cid && x.isActive==true) select x).ToList();

        if (l != null)
        {
            CommentCount = l.Count();
        }
        return CommentCount;
    }
}
