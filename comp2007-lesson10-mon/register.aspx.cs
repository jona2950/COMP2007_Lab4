﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference the identity packages
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace comp2007_lesson10_mon
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnectionEF
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            try
            {
                var user = new IdentityUser() { UserName = txtUsername.Text };
                IdentityResult result = manager.Create(user, txtPassword.Text);

                if (result.Succeeded)
                {
                    //lblStatus.Text = string.Format("User {0} was created successfully!", user.UserName);
                    //lblStatus.CssClass = "label label-success";
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                    Response.Redirect("/admin/main.aspx");
                }
                else
                {
                    lblStatus.Text = result.Errors.FirstOrDefault();
                    lblStatus.CssClass = "label label-danger";
                }
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ECEE) {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch (System.Data.SqlClient.SqlException SqlE) {
                Server.Transfer("/ErrorPage.aspx", true);
            }
        }
    }
}