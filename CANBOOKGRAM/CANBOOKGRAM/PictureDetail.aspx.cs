using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PictureDetail : System.Web.UI.Page
{
    CANBOOKGRAMEntities _db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["detail"] != null)
            {
                int id = Convert.ToInt32(Request["detail"]);

                using (_db = new CANBOOKGRAMEntities())
                {
                    var rsm = (from x in _db.Photo where (x.Id == id) select x).SingleOrDefault();

                    imgPicture.ImageUrl = "~/images/" + rsm.PhotoPath;
                    imgPicture.AlternateText = rsm.AltText;

                    Session["photoId"] = id;


                    var comments = (from x in _db.Comment where (x.PhotoId == id && x.isActive == true) select x).ToList();

                    dlComment.DataSource = comments.OrderByDescending(i => i.CreatedDate);
                    dlComment.DataBind();


                    int idUser = Convert.ToInt32(Session["MyId"]);
                    var likeFind = (from x in _db.Like where (x.PhotoId == id && x.UserId == idUser && x.isActive == true && x.isLike==true) select x).SingleOrDefault();
                    if (likeFind != null)
                    {
                        btnLike.Visible = false;
                        btnDislike.Visible = true;
                    }
                    var DislikeFind = (from x in _db.Like where (x.PhotoId == id && x.UserId == idUser && x.isActive == true && x.isLike == false) select x).SingleOrDefault();
                    if (DislikeFind!=null)
                    {
                        btnLike.Visible = true;
                        btnDislike.Visible = false;
                    }
                    var Find = (from x in _db.Like where (x.PhotoId == id && x.UserId == idUser && x.isActive == true && x.isLike == null) select x).SingleOrDefault();
                    if (Find!=null)
                    {
                        btnLike.Visible = true;
                        btnDislike.Visible = true;
                    }
                }
            }
        }
    }

    protected void btnInsertComment_Click(object sender, EventArgs e)
    {
        using (_db = new CANBOOKGRAMEntities())
        {
            int id = Convert.ToInt32(Session["MyId"]);
            var user = (from x in _db.User where (x.Id == id && x.isActive == true) select x).SingleOrDefault();

            Comment c = new Comment();
            c.Detail = txtDetail.Text;
            c.isActive = true;
            c.PhotoId = Convert.ToInt32(Session["photoId"]);
            c.UserId = id;
            c.Name = user.FirstName;
            c.SurName = user.LastName;
            c.CreatedDate = DateTime.Now;

            _db.Comment.Add(c);
            _db.SaveChanges();

            Response.Redirect("PictureDetail.aspx" + "?detail=" + Convert.ToInt32(Request["detail"]));
        }
    }

    protected void btnLike_Click(object sender, EventArgs e)
    {
        using (_db = new CANBOOKGRAMEntities())
        {
            int id = Convert.ToInt32(Request["detail"]);
            int idUser = Convert.ToInt32(Session["MyId"]);

            var likeFind = (from x in _db.Like where (x.PhotoId == id && x.UserId == idUser && x.isActive == true && x.isLike==false) select x).SingleOrDefault();

            if (likeFind != null)
            {
                var like = (from x in _db.Like where (x.PhotoId == id && x.UserId == idUser && x.isActive == true) select x).SingleOrDefault();
                if (like!=null)
                {
                    like.isLike = true;

                    var photo = (from x in _db.Photo where (x.isActive == true && x.Id == id) select x).SingleOrDefault();

                    photo.TrendPostCount = photo.TrendPostCount + 1;

                    _db.SaveChanges();
                    Response.Redirect("PictureDetail.aspx" + "?detail=" + Convert.ToInt32(Request["detail"]));
                }
            }
            else
            {
                var user = (from x in _db.User where (x.Id == idUser && x.isActive == true) select x).SingleOrDefault();

                Like l = new Like();
                l.isActive = true;
                l.PhotoId = id;
                l.UserId = idUser;
                l.CreatedDate = DateTime.Now;
                l.Name = user.FirstName;
                l.SurName = user.LastName;
                l.isLike = true;
                _db.Like.Add(l);

                var photo = (from x in _db.Photo where (x.isActive == true && x.Id == id) select x).SingleOrDefault();

                photo.TrendPostCount = photo.TrendPostCount + 1;

                _db.SaveChanges();
                Response.Redirect("PictureDetail.aspx" + "?detail=" + Convert.ToInt32(Request["detail"]));
            }
        }
    }

    protected void btnDislike_Click(object sender, EventArgs e)
    {
        using (_db = new CANBOOKGRAMEntities())
        {
            int id = Convert.ToInt32(Request["detail"]);
            int idUser = Convert.ToInt32(Session["MyId"]);

            var likeFind = (from x in _db.Like where (x.PhotoId == id && x.UserId == idUser && x.isActive == true && x.isLike == true) select x).SingleOrDefault();

            if (likeFind != null)
            {
                var disLike = (from x in _db.Like where (x.PhotoId == id && x.UserId == idUser && x.isActive == true) select x).SingleOrDefault();
                if (disLike != null)
                {
                    disLike.isLike = false;

                    var photo = (from x in _db.Photo where (x.isActive == true && x.Id == id) select x).SingleOrDefault();

                    photo.TrendPostCount = photo.TrendPostCount - 1;

                    _db.SaveChanges();
                    Response.Redirect("PictureDetail.aspx" + "?detail=" + Convert.ToInt32(Request["detail"]));
                }
            }
            else
            {
                var user = (from x in _db.User where (x.Id == idUser && x.isActive == true) select x).SingleOrDefault();

                Like l = new Like();
                l.isActive = true;
                l.PhotoId = id;
                l.UserId = idUser;
                l.CreatedDate = DateTime.Now;
                l.Name = user.FirstName;
                l.SurName = user.LastName;
                l.isLike = false;
                _db.Like.Add(l);

                var photo = (from x in _db.Photo where (x.isActive == true && x.Id == id) select x).SingleOrDefault();

                photo.TrendPostCount = photo.TrendPostCount - 1;

                _db.SaveChanges();
                Response.Redirect("PictureDetail.aspx" + "?detail=" + Convert.ToInt32(Request["detail"]));
            }
        }
    }
}