using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrendPost : System.Web.UI.Page
{
    CANBOOKGRAMEntities _db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["myPosts"] != null)
        {
            int userId = Convert.ToInt32(Request["myPosts"]);
            using (_db=new CANBOOKGRAMEntities())
            {
                var userPhotos = (from x in _db.Photo where (x.isActive == true && x.UserId == userId) select x).OrderByDescending(x => x.TrendPostCount).ToList().Take(5);

                dlUserPicture.DataSource = userPhotos;
                dlUserPicture.DataBind();
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
        var l = (from x in _db.Like where (x.PhotoId == lid && x.isActive == true && x.isLike == true) select x).ToList();

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
        var l = (from x in _db.Like where (x.PhotoId == lid && x.isActive == true && x.isLike == false) select x).ToList();

        if (l != null)
        {
            DisLikeCount = l.Count();
        }
        return DisLikeCount;
    }
}