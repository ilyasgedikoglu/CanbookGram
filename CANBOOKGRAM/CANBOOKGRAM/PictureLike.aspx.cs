using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PictureLike : System.Web.UI.Page
{
    CANBOOKGRAMEntities _db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["like"] != null)
            {
                using (_db = new CANBOOKGRAMEntities())
                {
                    int id = Convert.ToInt32(Request["like"]);
                    var likes = (from x in _db.Like where (x.PhotoId == id && x.isActive==true && x.isLike==true) select x).OrderByDescending(x => x.CreatedDate).ToList();
                    dlLikes.DataSource = likes;
                    dlLikes.DataBind();
                }
            }
            if (Request["dislike"] != null)
            {
                using (_db = new CANBOOKGRAMEntities())
                {
                    int id = Convert.ToInt32(Request["dislike"]);
                    var likes = (from x in _db.Like where (x.PhotoId == id && x.isActive == true && x.isLike == false) select x).OrderByDescending(x => x.CreatedDate).ToList();
                    dlLikes.DataSource = likes;
                    dlLikes.DataBind();
                }
            }
        }
    }
}