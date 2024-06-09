using IT_EL4_EXERCISE15.DBConnections;
using IT_EL4_EXERCISE15.DTO;
using IT_EL4_EXERCISE15.Models;
using IT_EL4_EXERCISE15.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;

namespace IT_EL4_EXERCISE15
{
    public partial class CollegeList : System.Web.UI.Page
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

        [WebMethod(Description = "A sample web method that get College records from the database")]
        [ScriptMethod(UseHttpGet = true)]
        public static CollegeVM GetCollegeRecords()
        {
            //create a new instance of the College View Model
            CollegeVM collegeVM = new CollegeVM();
            List<College> collegeList = new List<College>();
            try
            {
                //get college records
                collegeList = dbConnect.GetCollegeRecords();
                collegeVM.CollegeList = collegeList;
                collegeVM.Message = "Successfully retrieved College records!";
            }
            catch (Exception ex)
            {
                collegeVM.Message = "Error: " + ex.Message;
            }

            return collegeVM;
        }

        [WebMethod(Description = "A sample web method that will add new College record to the database")]
        [ScriptMethod(UseHttpGet = false)]
        public static string AddCollegeRecord(CollegeDTO collegeData)
        {
            string message = "Unable to add college record!";
            try
            {
                if (dbConnect.AddCollegeRecord(collegeData))
                    message = "College added successfully!";
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
            }

            return message;
        }
    }
}
