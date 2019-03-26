using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SharePicture : System.Web.UI.Page
{
    CANBOOKGRAMEntities _db;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnShare_Click(object sender, EventArgs e)
    {
        using (_db=new CANBOOKGRAMEntities())
        {
            Photo p = new Photo();

            p.AltText = txtAltText.Text;
            if (fuPicture.HasFile)
            {
                fuPicture.SaveAs(Server.MapPath("~/images/" + fuPicture.FileName));
                p.PhotoPath = fuPicture.FileName;
            }
            p.isActive = true;
            p.UserId = Convert.ToInt32(Session["MyId"]);
            p.CreatedDate = DateTime.Now;

            _db.Photo.Add(p);
            _db.SaveChanges();
        }
        Response.Redirect("~/CommonWall.aspx" + "?user=" + Session["MyId"]);
    }
}