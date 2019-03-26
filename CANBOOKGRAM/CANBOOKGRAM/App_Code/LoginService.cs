using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
public class LoginService : ILoginService
{
    public void DoWork()
    {
    }

    public User isUserFound(string email, string password)
    {
        CANBOOKGRAMEntities _db = new CANBOOKGRAMEntities();

        User u = (from x in _db.User where x.Email == email && x.isActive == true select x).SingleOrDefault();
        if (VerifyPassword(password, u.Password) == true)
        {
            return u;
        }
        return null;
    }

    public static bool VerifyPassword(string password, string savedPasswordHash)
    {
        //STEP 6 Verify the user-entered password against a stored password

        /* Extract the bytes */
        byte[] hashBytes = System.Convert.FromBase64String(savedPasswordHash);
        /* Get the salt */
        byte[] salt = new byte[16];
        System.Array.Copy(hashBytes, 0, salt, 0, 16);
        /* Compute the hash on the password the user entered */
        var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);
        /* Compare the results */
        for (int i = 0; i < 20; i++)
            if (hashBytes[i + 16] != hash[i])
                return false;
        return true;
    }
}
