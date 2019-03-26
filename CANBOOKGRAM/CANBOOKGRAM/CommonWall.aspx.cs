using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CommonWall : System.Web.UI.Page
{
    CANBOOKGRAMEntities _db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MyId"] != null)
        {
            if (Request["user"] != null)
            {
                using (_db=new CANBOOKGRAMEntities())
                {
                    int commonWallUserId = Convert.ToInt32(Request["user"]);
                    var followedUsers = (from x in _db.Followed where (x.UserId == commonWallUserId && x.isActive == true) select x).ToList();

                    List<Photo> photo = new List<Photo>();
                    foreach (var item in followedUsers)
                    {
                        var userIdPictures = (from x in _db.Photo where (x.isActive == true && x.UserId == item.FollowedUserId) select x).ToList();

                        foreach (var item2 in userIdPictures)
                        {
                            photo.Add(item2);
                        }
                    }
                    dlFollowedPicture.DataSource = photo.OrderByDescending(x => x.CreatedDate);
                    dlFollowedPicture.DataBind();
                }             
            }
        }
       
    }

    public string FindNameSurname(object id)
    {
        string NameSurname = "";
        int nid = Convert.ToInt32(id);
        CANBOOKGRAMEntities _db = new CANBOOKGRAMEntities();
        var u = (from x in _db.User where (x.Id == nid && x.isActive == true) select x).SingleOrDefault();

        if (u != null)
        {
            NameSurname = u.FirstName + " " + u.LastName;
        }
        return NameSurname;
    }

    public int FindLikeCount(object id)
    {
        int LikeCount = 0;
        int lid = Convert.ToInt32(id);
        CANBOOKGRAMEntities _db = new CANBOOKGRAMEntities();
        var l = (from x in _db.Like where (x.PhotoId == lid && x.isActive == true && x.isLike==true) select x).ToList();

        if (l != null)
        {
            LikeCount = l.Count();
        }
        return LikeCount;
    }

    public int FindCommentCount(object id)
    {
        int CommentCount = 0;
        int cid = Convert.ToInt32(id);
        CANBOOKGRAMEntities _db = new CANBOOKGRAMEntities();
        var l = (from x in _db.Comment where (x.PhotoId == cid && x.isActive == true) select x).ToList();

        if (l != null)
        {
            CommentCount = l.Count();
        }
        return CommentCount;
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
}