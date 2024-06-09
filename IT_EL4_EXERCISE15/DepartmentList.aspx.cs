using IT_EL4_EXERCISE15.DBConnections;
using IT_EL4_EXERCISE15.DTO;
using IT_EL4_EXERCISE15.Models;
using IT_EL4_EXERCISE15.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT_EL4_EXERCISE15
{
    public partial class DepartmentList : System.Web.UI.Page
    {
        private static DBConnect dbConnect;
        protected void Page_Load(object sender, EventArgs e)
        {
            //create an instance of DB connect
            dbConnect = new DBConnect("localhost", 3306, "root", "", "exercise15");
        }

        [WebMethod(Description = "A sample web method that will check the DB connection status")]
        [ScriptMethod(UseHttpGet = true)]
        public static string ConnectDB()
        {
            string status = "Connected to DB successfully!";
            try
            {
                if (!dbConnect.ConnectDB())
                    status = "Could not connect to DB!";
            }
            catch (Exception ex)
            {
                status = "Connection error: " + ex.Message;
            }

            return status;
        }

        [WebMethod(Description = "A sample web method that get Department records from the database")]
        [ScriptMethod(UseHttpGet = true)]
        public static DepartmentVM GetDepartmentRecords()
        {
            //create a new instance of the Department View Model
            DepartmentVM departmentVM = new DepartmentVM();
            List<Department> departmentList = new List<Department>();
            try
            {
                //get department records
                departmentList = dbConnect.GetDepartmentRecords();
                departmentVM.DepartmentList = departmentList;
                departmentVM.Message = "Successfully retrieved department records!";
            }
            catch (Exception ex)
            {
                departmentVM.Message = "Error: " + ex.Message;
            }

            return departmentVM;
        }

        [WebMethod(Description = "A sample web method that will add new Department record to the database")]
        [ScriptMethod(UseHttpGet = false)]
        public static string AddDepartmentRecord(DepartmentDTO departmentData)
        {
            string message = "Unable to add department record!";
            try
            {
                if (dbConnect.AddDepartmentRecord(departmentData))
                    message = "Department added successfully!";
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
            }

            return message;
        }
    }
}