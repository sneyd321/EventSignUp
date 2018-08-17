using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WcfService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public Student GetStudent(int id)
        {
            Student s = new Student();
            //string conString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = c:\\users\\ryan\\Source\\Repos\\WebServiceWithAjax\\WebServiceWithAjax\\App_Data\\MySchoolDB.mdf; Integrated Security = True";
            string conString = ConfigurationManager.ConnectionStrings["SchoolDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Student where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    s.Id = Convert.ToInt32(reader["Id"]);
                    s.Name = reader["Name"].ToString();
                }
            }
            return s;
        }



    }
}
