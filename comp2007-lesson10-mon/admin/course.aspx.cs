using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2007_lesson10_mon.Models;

namespace comp2007_lesson10_mon
{
    public partial class course : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDepartments();

                //get the course if editing
                if (!String.IsNullOrEmpty(Request.QueryString["CourseID"]))
                {
                    GetCourse();
                }
            }
        }

        protected void GetCourse()
        {
            try { 
                //populate the existing course for editing
                using (DefaultConnectionEF db = new DefaultConnectionEF())
                {
                    Int32 CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);

                    Course objC = (from c in db.Courses
                                   where c.CourseID == CourseID
                                   select c).FirstOrDefault();

                    //populate the form
                    txtTitle.Text = objC.Title;
                    txtCredits.Text = objC.Credits.ToString();
                    ddlDepartment.SelectedValue = objC.DepartmentID.ToString();
                }
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ECEE)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch (System.Data.SqlClient.SqlException SqlE)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
        }

        protected void GetDepartments()
        {
            try {
                using (DefaultConnectionEF db = new DefaultConnectionEF())
                {
                    var deps = (from d in db.Departments
                                orderby d.Name
                                select d);

                    ddlDepartment.DataSource = deps.ToList();
                    ddlDepartment.DataBind();
                }
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ECEE)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch (System.Data.SqlClient.SqlException SqlE)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try { 
                //do insert or update
                using (DefaultConnectionEF db = new DefaultConnectionEF())
                {
                    Course objC = new Course();

                    if (!String.IsNullOrEmpty(Request.QueryString["CourseID"]))
                    {
                        Int32 CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
                        objC = (from c in db.Courses
                                where c.CourseID == CourseID
                                select c).FirstOrDefault();
                    }

                    //populate the course from the input form
                    objC.Title = txtTitle.Text;
                    objC.Credits = Convert.ToInt32(txtCredits.Text);
                    objC.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);

                    if (String.IsNullOrEmpty(Request.QueryString["CourseID"]))
                    {
                        //add
                        db.Courses.Add(objC);
                    }

                    //save and redirect
                    db.SaveChanges();
                    Response.Redirect("courses.aspx");
                }
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ECEE)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch (System.Data.SqlClient.SqlException SqlE)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
        }
    }
}