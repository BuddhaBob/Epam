using LayersDAL.EF;
using LayersDAL.Entity;
using LayersDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LayersDLL.Validation
{
    public class RegistrationCheckModel
    {
         public HttpCookie IsntExist(RegisterModel model)
        {
            User user = null;
            using (SiteContext db = new SiteContext())
            {
                user = db.Users.FirstOrDefault(u => u.Email == model.Email || u.Nickname == model.Nickname);
            }
            if (user == null)
            {

                // создаем нового пользователя
                using (SiteContext db = new SiteContext())
                {
                    db.Users.Add(new User { Email = model.Email, Password = model.Password, Nickname = model.Nickname});
                    db.SaveChanges();

                    user = db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                }
                // если пользователь удачно добавлен в бд
                if (user != null)
                {
                    var cookie = new HttpCookie("CookieKey2", user.UserId.ToString());
                    return cookie;
                }
            }
            else
            {
                return null;
            }
            return null;
        }
    }
}
