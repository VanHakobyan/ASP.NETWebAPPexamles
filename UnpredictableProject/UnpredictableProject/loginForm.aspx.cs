using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnpredictableProject
{
    public partial class loginForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string login, password;
            login = Request.Form["loginParam"];
            password = Request.Form["passwordParam"];

            if (string.IsNullOrEmpty(login))
            {
                LableLogin.Text = "not parametr login";
            }
            else
            {
                LableLogin.Text = login;
            }
            if (string.IsNullOrEmpty(password))
            {
                LablePassword.Text = "not parametr password";
            }
            else
            {
                LablePassword.Text = login;
            }
        }
    }
}