using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Facebook;
using Fashison_eCommerce.Models;


namespace Fashison_eCommerce.Controllers
{
    public class AccountController : Controller
    {

        public int Number; //So lan dang nhap sai cua tai khoan email
        public DateTime Firsttime;
        public DateTime Lasttime;
        public DateTime Currenttime;
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                //uriBuilder.Path = "/Account/FacebookCallback";
                uriBuilder.Path = "/Account/FacebookCallback";
                return uriBuilder.Uri;
            }
        }

        // GET: Account
        DB_A6A231_DAQLTMDTEntities db = new DB_A6A231_DAQLTMDTEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Login()
        {
            if (Request.Cookies["email"] != null && Request.Cookies["pass"] != null)
            {
                ViewBag.Email = Request.Cookies["email"].Value;
                ViewBag.Pass = Request.Cookies["pass"].Value;
                ViewBag.Check = "1";
            }
            else
            {
                ViewBag.Email = "";
                ViewBag.Pass = "";
                ViewBag.Check = "";

            }
            return View();
        }

        //[HttpPost]// thuc hien dang nhap
        //public ActionResult VerifyLogin(User user)
        //{


        //    // kiem tra du lieu nhap
        //    if (ModelState.IsValid)
        //    {

        //        string checkRemember = Request["checkMe"];
        //        // truy van csdl 
        //        using (var _context = new DB_A6A231_DAQLTMDTEntities())
        //        {
        //            // query id tu email va password de kiem tra dang nhap
        //            //var obj = (from u in _context.Users where u.Email == user.Email && u.Password == user.Password select u).FirstOrDefault();
        //            var obj = db.sp_Login(user.Email, user.Password).FirstOrDefault();
        //            if(obj != null)
        //            {
        //                if(checkRemember == "1") //(check Remember me
        //                {
        //                    Response.Cookies["email"].Value = user.Email;
        //                    Response.Cookies["pass"].Value = user.Password;
        //                    Response.Cookies["email"].Expires = DateTime.Now.AddMinutes(1);
        //                    Response.Cookies["pass"].Expires = DateTime.Now.AddMinutes(1);
        //                }
        //                else if(checkRemember == null)
        //                {
        //                    Response.Cookies["email"].Expires = DateTime.Now.AddMinutes(-1);
        //                    Response.Cookies["pass"].Expires = DateTime.Now.AddMinutes(-1);
        //                }

        //                Session["userID"] = obj.Id.ToString();
        //                Session["username"] = obj.Username.ToString();
        //                Session["roleID"] = obj.RoleID.ToString();

        //                //Lay mat khau người dùng
        //                Session["pass"] = user.Password.ToString();

        //                if (obj.Avatar != null)
        //                {
        //                    Session["Avatar"] = obj.Avatar.ToString();
        //                }
        //                else
        //                {
        //                    Session["Avatar"] = "#.png";
        //                }

        //                //Lay dia chi mac dinh cua nguoi dung de lam dia chỉ mua hang
        //                BuyerAddressClient buyerAddressClient = new BuyerAddressClient();
        //                var addressList = buyerAddressClient.find(Convert.ToInt32(Session["userID"]));
        //                int addressID= addressList.Where(x => x.default_address == 1).Select(x => x.Address_ID).FirstOrDefault();
        //                Session["Address_ID"] = addressID;
        //                if ( Convert.ToInt32(Session["Address_ID"]) == 0)
        //                {
        //                    Session["Address_ID"] = -1;
        //                }

        //                //string username = obj.Username.ToString();
        //                    return RedirectToAction("Index", "MainPage", new { Area = "Buyer" });
        //            }
        //            else
        //            {
        //                Response.Write("<script>alert('Invalid Email or Password')</script>");
        //                return View("Error");
        //            }
        //        }
        //    }
        //    return View("Error");   
        //}


        [HttpPost]// thuc hien dang nhap
        [ValidateAntiForgeryToken]
        public ActionResult VerifyLogin(User user)
        {


            // kiem tra du lieu nhap
            if (ModelState.IsValid)
            {

                string checkRemember = Request["checkMe"];
                // truy van csdl 
                using (var _context = new DB_A6A231_DAQLTMDTEntities())
                {
                    // query id tu email va password de kiem tra dang nhap
                    //var obj = (from u in _context.Users where u.Email == user.Email && u.Password == user.Password select u).FirstOrDefault();
                    
                    
                    if(KiemTraStatus(user.Email) == true) //Ton tai email va dang o trang thai hoat 
                    {
                        var obj = db.sp_Login(user.Email, user.Password).FirstOrDefault();
                        if (obj != null)
                        {
                            if (checkRemember == "1") //(check Remember me
                            {
                                Response.Cookies["email"].Value = user.Email;
                                Response.Cookies["pass"].Value = user.Password;
                                Response.Cookies["email"].Expires = DateTime.Now.AddMinutes(1);
                                Response.Cookies["pass"].Expires = DateTime.Now.AddMinutes(1);
                            }
                            else if (checkRemember == null)
                            {
                                Response.Cookies["email"].Expires = DateTime.Now.AddMinutes(-1);
                                Response.Cookies["pass"].Expires = DateTime.Now.AddMinutes(-1);
                            }

                            Session["userID"] = obj.Id.ToString();
                            Session["username"] = obj.Username.ToString();
                            Session["roleID"] = obj.RoleID.ToString();

                            //Lay mat khau người dùng
                            Session["pass"] = user.Password.ToString();

                            if (obj.Avatar != null)
                            {
                                Session["Avatar"] = obj.Avatar.ToString();
                            }
                            else
                            {
                                Session["Avatar"] = "#.png";
                            }

                            //Lay dia chi mac dinh cua nguoi dung de lam dia chỉ mua hang
                            BuyerAddressClient buyerAddressClient = new BuyerAddressClient();
                            var addressList = buyerAddressClient.find(Convert.ToInt32(Session["userID"]));
                            int addressID = addressList.Where(x => x.default_address == 1).Select(x => x.Address_ID).FirstOrDefault();
                            Session["Address_ID"] = addressID;
                            if (Convert.ToInt32(Session["Address_ID"]) == 0)
                            {
                                Session["Address_ID"] = -1;
                            }


                            //Dang nhap thanh cong reset time out 
                            PasswordTrue(user.Email);


                            //string username = obj.Username.ToString();
                            return RedirectToAction("Index", "MainPage", new { Area = "Buyer" });
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid Email or Password')</script>");

                            Response.Write("<script>alert('You have " + (2 - Number) + " time left to login')</script>");
                            if(2 - -Number == 0)
                            {
                                Response.Write("<script>alert('Your account is locked for 15 minutes!!!')</script>");
                            }
                           
                            //email chinh xac nhung mat khau khong chinh xac
                            //Cap nhat time out Number++
                            PasswordFail(user.Email);

                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Your account is blocked 15 minutes')</script>");
                    }
                   
                }
            }
            return View("Error");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "MainPage", new { Area = "Buyer" });
        }
        
        [HttpGet] // di toi trang dang ki
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost] // thuc hien dang ki
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(User user)
        {
            // kiem tra du lieu nhap
            if (ModelState.IsValid)
            {
               if(testPass(user.Password.ToString().Trim()) == true )
                {
                    using (var _context = new DB_A6A231_DAQLTMDTEntities())
                    {
                        try
                        {
                            var obj = (from u in _context.Users where u.Email == user.Email select u).FirstOrDefault();
                            if (obj == null)
                            {
                                try
                                {
                                    // goi stored proc de them user vao csdl
                                    var sqlParams = new SqlParameter[]
                                    {
                                new SqlParameter("@username", user.Username),
                                new SqlParameter("@pass", user.Password),
                                new SqlParameter("@email", user.Email),
                                new SqlParameter("@roleId", 2)
                                    };
                                    //_context.Database.ExecuteSqlCommand("dbo.sp_AccountResgister @username, @pass, @email", sqlParams);
                                    _context.Database.ExecuteSqlCommand("insert into Users(Username, Email, Password, RoleID) values (@username, @email, @pass, @roleId)", sqlParams);
                                    Response.Write("<script>alert('Registered!')</script>");
                                    return View("Login");
                                }
                                catch
                                {
                                    return View("Error");
                                }

                            }
                            else
                            {
                                Response.Write("<script>alert('Username or email existed')</script>");
                                return View("Error");
                            }
                        }
                        catch { }

                    }
                }
               else
                {
                    Response.Write("<script>alert('Password has min 8 characters, 1 uppercase, 1 lowercase, 1 number!')</script>");
                    return Content("");
                }
                
            }
            return View("Error");

        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public ActionResult VerifyByEmail()// gui email co kem ma xac nhan cho user
        {
            string user_email = Request["email"];

            using (var _context = new DB_A6A231_DAQLTMDTEntities())
            {
                // query id tu email va password de kiem tra dang nhap

                var obj = (from u in _context.Users where u.Email == user_email select u).FirstOrDefault();
                if (obj != null)
                {
                    Session["user_email"] = user_email;
                    ViewBag.email = user_email;
                    string web_email = "laptrinhwebnhom9@gmail.com";
                    // Cau hinh thong tin gmail
                    var mail = new SmtpClient("smtp.gmail.com", 25)
                    {
                        Credentials = new NetworkCredential(web_email, "123asd456qwe"),
                        EnableSsl = true
                    };
                    // tao gmail
                    var message = new MailMessage();
                    message.From = new MailAddress(web_email);
                    message.ReplyToList.Add(web_email);
                    message.To.Add(new MailAddress(user_email));

                    // Create a random 6-digits number for verification code
                    Random random = new Random();
                    int code = random.Next(100000, 999999);
                    ViewBag.code = code;

                    message.Subject = "Your verification code";
                    message.Body = code + " is your LTWeb verification code.";

                    // gui gmail    
                    mail.Send(message);

                    return View("VerificationCode");
                }
                else
                {
                    Response.Write("<script>alert('Email not found')</script>");
                    return View("ForgotPassword");
                }
            }
        }
        // can chinh sua de user ko dung url di vao truc tiep action!!!!
        [HttpPost] // di toi trang doi mat khau
        public ActionResult ChangePasswordPage()
        {
            return View("ChangePassword");
        }
        [HttpPost] // thuc hien doi mat khau nguoi dung
        public ActionResult ChangePassword()
        {
            string password = Request["password"];
            using (var _context = new DB_A6A231_DAQLTMDTEntities())
            {
                try
                {
                    // goi stored proc de doi mat khau user
                    var sqlParams = new SqlParameter[]
                    {
                        new SqlParameter("@pass", password),
                        new SqlParameter("@email", Session["user_email"]),
                    };
                    _context.Database.ExecuteSqlCommand("dbo.sp_AccountChangePassword @email, @pass", sqlParams);
                    Response.Write("<script>alert('Password changed')</script>");
                    Session.Clear();
                    return View("Login");
                }
                catch
                {
                    Response.Write("<script>alert('Password not changed')</script>");
                    return View("Error");
                }
            }
        }

        [AllowAnonymous]
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });
            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            if(!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=first_name, middle_name,last_name,id,email");
                string email = me.email;
                //string username = me.email;
                //string name = me.first_name;
                try
                {
                    db.sp_InsUserFb(email);
                    db.SaveChanges();
                    var user = db.Users.Where(x => x.Email == email).FirstOrDefault();
                    if (user != null)
                    {
                        Session["userID"] = user.Id;
                        Session["username"] = user.Email;
                        if(user.Avatar ==null)
                        {
                            Session["Avatar"] = "#.png";
                        }
                        BuyerAddressClient buyerAddressClient = new BuyerAddressClient();
                        var addressList = buyerAddressClient.find(Convert.ToInt32(Session["userID"]));
                        Session["Address_ID"] = addressList.Where(x => x.default_address == 1).Select(x => x.Address_ID).FirstOrDefault();

                        return RedirectToAction("Index", "MainPage", new { Area = "Buyer" });
                    }

                }
                catch
                {
                    Response.Write("<script>alert('Invalid Email or Password')</script>");
                    return View("Error");
                }
                
            }
            else
            {
                Response.Write("<script>alert('Invalid Email or Password')</script>");
                return View("Error");
            }

            Response.Write("<script>alert('Invalid Email or Password')</script>");
            return View("Error");
        }

        public bool testPass(string pass)
        {

            if(pass.Length < 8 && pass.Length >15)
            {
                return false;
            }
            else if(!(!pass.Equals(pass.ToLower())))
            {
                //Check for min 1 uppercase
                Console.WriteLine("Requres at least one uppercase");
                return false;
            }
            else if(!(!pass.Equals(pass.ToUpper())))
            {
                //Check for min 1 lowpercase
                Console.WriteLine("Requres at least one uppercase");
                return false;
            }
            else
            {
                for (int i = 0; i < pass.Length; i++)
                {
                    string test = pass.Substring(i, 1);
                    try
                    {
                        int number = Convert.ToInt32(test);
                        return true;
                    }
                    catch{}
                }
            }           
            return false;
            
        }


        public bool KiemTraStatus (String Email)
        {

            
            // Kiem tra trang thai hoatj dong cua tai khoan email
            var status = db.TimeOuts.Where(x => x.Email == Email).FirstOrDefault();
            

            if (status != null)
            {
                string email = status.Email.ToString();
                Firsttime = Convert.ToDateTime(status.Ftime);
                Lasttime = Convert.ToDateTime(status.Ltime);
                Currenttime = DateTime.Now;
                int a = Convert.ToInt32(status.Status);

                //Dang nhap lan dau tu khi dang di
                if (status.Ftime == null)
                {
                    
                    using (var _context = new DB_A6A231_DAQLTMDTEntities())
                    {
                        try
                        {
                            var sqlParams = new SqlParameter[]
                            {
                            new SqlParameter("@email", email),
                            new SqlParameter("@ftime", Currenttime),
                            new SqlParameter("ltime", Currenttime),
                            };
                            _context.Database.ExecuteSqlCommand("update TimeOut set Number = @number, Ftime = @ftime, Ltime = @ltime where Email = @email", sqlParams);
                        }
                        catch { }
                    }
                }

                //Reset lai TimeOut
                ResetTimeOut(email, Firsttime, Lasttime, Currenttime, a);


                try
                {
                    db = new DB_A6A231_DAQLTMDTEntities();
                    //Lay lai gia tri trong timeout
                    status = db.TimeOuts.Where(x => x.Email == Email).FirstOrDefault();

                    Number = Convert.ToInt32(status.Number);//Lay gia tri so lan dang nhaapj

                    if (Convert.ToInt32(status.Status) == 0) //Trang thai hoat dong
                        return true;
                    else
                        return false;
                }
                catch
                {

                }
              
            }
            return false;           
        }

        //Khi dang nhap sai mat khau
        public void PasswordFail(String email)
        {

            int number = Number + 1;
            //Tang so lan dang nhap sai len 1
            using (var _context = new DB_A6A231_DAQLTMDTEntities())
            {
                try
                {
                    var sqlParams = new SqlParameter[]
                    {
                        new SqlParameter("@number", number),
                        new SqlParameter("@email", email),
                    };
                    _context.Database.ExecuteSqlCommand("update TimeOut set Number = @number where Email = @email", sqlParams);
                   
                    if(number == 3)
                    {
                        NotifyEmail(email);
                    }
                }
                catch { }
                

            }
        }

        //dung password reset TimeOut
        public void PasswordTrue(String email)
        {
            //cap nhat firsttime = now
            //          lasttime = now
            //          number = 0

            using (var _context = new DB_A6A231_DAQLTMDTEntities())
            {
                try
                {
                    int number = 0;
                    var sqlParams = new SqlParameter[]
                    {
                        new SqlParameter("@number", number),
                        new SqlParameter("@email", email),
                        new SqlParameter("@ftime", Currenttime),
                        new SqlParameter("ltime", Currenttime),
                    };
                    _context.Database.ExecuteSqlCommand("update TimeOut set Number = @number, Ftime = @ftime, Ltime = @ltime where Email = @email", sqlParams);
                    Response.Write("<script>alert('Password changed')</script>");
                }
                catch { }
            }
        }

        public void ResetTimeOut(string email, DateTime ftime, DateTime ltime, DateTime curtime, int status)
        {

            TimeSpan staticTime = new TimeSpan(0, 0, 15, 0);
            // Thoi gian dang nhap ke tu lan cuoi cung dang nhap > 15phut ===> reset Timeout va active account
            TimeSpan time1 = curtime.Subtract(ltime);

            // khoang thoi gian dang nhap tro
            TimeSpan time2 = curtime.Subtract(ftime);

            using( var _context = new DB_A6A231_DAQLTMDTEntities())
            {
                if(status == 1) //Tai khoan dang bi khoa
                {
                    if (time1 > staticTime)//Thoi gian dang nhap ke tu lan cuoi cung dang nhap > 15phut ===> reset Timeout va active account
                    {
                        try
                        {
                            int number = 0;
                            var sqlParams = new SqlParameter[]
                            {
                            new SqlParameter("@number", number),
                            new SqlParameter("@email", email),
                            new SqlParameter("@ftime", curtime),
                            new SqlParameter("ltime", curtime),
                            };
                            _context.Database.ExecuteSqlCommand("update TimeOut set Number = @number, Ftime = @ftime, Ltime = @ltime where Email = @email", sqlParams);
                        }
                        catch { }
                    }
                }
                else
                {
                    if (time1 > staticTime)//Thoi gian dang nhap ke tu lan cuoi cung dang nhap > 15phut ===> reset Timeout va active account
                    {
                        try
                        {
                            int number = 0;
                            var sqlParams = new SqlParameter[]
                            {
                            new SqlParameter("@number", number),
                            new SqlParameter("@email", email),
                            new SqlParameter("@ftime", curtime),
                            new SqlParameter("ltime", curtime),
                            };
                            _context.Database.ExecuteSqlCommand("update TimeOut set Number = @number, Ftime = @ftime, Ltime = @ltime where Email = @email", sqlParams);
                        }
                        catch { }
                    }
                    else  //if(status = 0, tai khoan dang hoat dong
                    {
                        if (time2 <= staticTime)
                        {
                            //dang nhap van dang trong 15' cua 3 lan lien tiep
                            // cap nhat thoi gian dang nhap hien tai
                            try
                            {
                                var sqlParams = new SqlParameter[]
                               {
                                new SqlParameter("@email", email),
                                new SqlParameter("ltime", curtime),
                               };
                                _context.Database.ExecuteSqlCommand("update TimeOut set Ltime = @ltime where Email = @email", sqlParams);
                            }
                            catch { }

                        }
                        else
                        {
                            // Dang nhap lan nay va lan dau tien sai da ngoai 15'
                            // Reset timeOut
                            try
                            {
                                int number = 0;
                                var sqlParams = new SqlParameter[]
                                {
                            new SqlParameter("@number", number),
                            new SqlParameter("@email", email),
                            new SqlParameter("@ftime", curtime),
                            new SqlParameter("ltime", curtime),
                                };
                                _context.Database.ExecuteSqlCommand("update TimeOut set Number = @number, Ftime = @ftime, Ltime = @ltime where Email = @email", sqlParams);
                            }
                            catch { }

                        }
                    }
                }
               
            }

           
        }

        public void NotifyEmail(string email)// gui email co kem ma xac nhan cho user
        {
            string user_email = email;

            using (var _context = new DB_A6A231_DAQLTMDTEntities())
            {
                // query id tu email va password de kiem tra dang nhap

                var obj = (from u in _context.Users where u.Email == user_email select u).FirstOrDefault();
                if (obj != null)
                {
                    Session["user_email"] = user_email;
                    ViewBag.email = user_email;
                    string web_email = "laptrinhwebnhom9@gmail.com";
                    // Cau hinh thong tin gmail
                    var mail = new SmtpClient("smtp.gmail.com", 25)
                    {
                        Credentials = new NetworkCredential(web_email, "123asd456qwe"),
                        EnableSsl = true
                    };
                    // tao gmail
                    var message = new MailMessage();
                    message.From = new MailAddress(web_email);
                    message.ReplyToList.Add(web_email);
                    message.To.Add(new MailAddress(user_email));

                    // Create a random 6-digits number for verification code
                    Random random = new Random();
                    int code = random.Next(100000, 999999);
                    ViewBag.code = code;

                    message.Subject = "Security notification for \n"+ email;
                    message.Body = "There is a device trying to sign in with this account. Have you done this?  \nPlease change your password to make your account more secure!!!" +
                        "\n\n*Note: Your account has been temporarily locked for 15 minutes.";

                    // gui gmail    
                    mail.Send(message);
                    //Response.Write("<script>alert('Email not found')</script>");

                }
                else
                {
                    Response.Write("<script>alert('Email not found')</script>");

                }
            }
        }
    }
}