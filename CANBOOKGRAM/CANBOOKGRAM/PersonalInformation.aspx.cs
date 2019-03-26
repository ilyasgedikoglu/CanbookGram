using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PersonalInformation : System.Web.UI.Page
{
    CANBOOKGRAMEntities _db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MyId"]!=null)
        {
            if (Request["myid"] !=null)
            {
                int id = Convert.ToInt32(Request["myid"]);
                using (_db=new CANBOOKGRAMEntities())
                {
                    var user = (from x in _db.User where (x.Id == id && x.isActive == true) select x).SingleOrDefault();

                    imgUser.ImageUrl = "~/images/" + user.Photo;
                    txtName.Text = user.FirstName;
                    txtSurname.Text = user.LastName;
                    txtUserName.Text = user.UserName;
                    txtEducation.Text = user.Education;
                    txtCity.Text = user.City;
                    txtAboutMe.Text = user.AboutMe;
                    txtEmail.Text = user.Email;
                }
            }
        }
    }

    protected void btnChangePicture_Click(object sender, EventArgs e)
    {
        using (_db = new CANBOOKGRAMEntities())
        {
            int id = Convert.ToInt32(Request["myid"]);
            var user = (from x in _db.User where (x.Id == id && x.isActive == true) select x).SingleOrDefault();

            if (fuUser.HasFile)
            {
                fuUser.SaveAs(Server.MapPath("~/images/" + fuUser.FileName));
                user.Photo = fuUser.FileName;
            }

            _db.SaveChanges();

            Response.Redirect("~/PersonalInformation.aspx" + "?myid=" + id);
        }
    }

    protected void btnChangeInformation_Click(object sender, EventArgs e)
    {
        using (_db = new CANBOOKGRAMEntities())
        {
            int id = Convert.ToInt32(Request["myid"]);
            var user = (from x in _db.User where (x.Id == id && x.isActive == true) select x).SingleOrDefault();

            user.FirstName = txtName.Text;
            user.LastName = txtSurname.Text;
            user.UserName = txtUserName.Text;
            user.Location = txtCity.Text;
            user.Education = txtEducation.Text;
            user.AboutMe = txtAboutMe.Text;
            user.isActive = true;
            user.Email = txtEmail.Text;
            if (txtPassword.Text.Count() > 0)
            {
                user.Password = HashPassword(txtPassword.Text);
            }

            _db.SaveChanges();

            Response.Redirect("~/PersonalInformation.aspx" + "?myid=" + id);
        }
    }

    public static string HashPassword(string password) //Takes a string and creates hash of the string
    {
        //STEP 1 Create the salt value with a cryptographic PRNG:

        byte[] salt;
        new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

        //STEP 2 Create the Rfc2898DeriveBytes and get the hash value:

        var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt, 10000);
        //Note: Depending on the performance requirements of your specific application, the value '10000' can be reduced. 
        //      A minimum value should be around 1000.
        byte[] hash = pbkdf2.GetBytes(20);

        //STEP 3 Combine the salt and password bytes for later use:

        byte[] hashBytes = new byte[36];
        System.Array.Copy(salt, 0, hashBytes, 0, 16);
        System.Array.Copy(hash, 0, hashBytes, 16, 20);

        //STEP 4 Turn the combined salt+hash into a string for storage

        string savedPasswordHash = System.Convert.ToBase64String(hashBytes);

        //STEP 5 Return hashed password (It will be 48 characters long)
        return savedPasswordHash;

    }
}