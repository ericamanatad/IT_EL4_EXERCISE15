using System;
using System.Collections.Generic;
using IT_EL4_EXERCISE15.DTO;
using IT_EL4_EXERCISE15.Models;
using MySql.Data.MySqlClient;
namespace IT_EL4_EXERCISE15.DBConnections
{
    public partial class DBConnect
    {
        private static string connectionString;
        private static MySqlConnection conn;

        public DBConnect()
        {

        }

        public DBConnect(string dbServer, int portNo, string userID, string password, string db)
        {
            //setup connection string
            //server=localhost;port=3306;userid=root;password=xxxx;database=yyyyyyy
            connectionString = "server=" + dbServer + ";port=" + portNo + ";userid=" + userID + ";password=" + password + ";database=" + db;
        }

        public bool ConnectDB()
        {
            //create MySQL connection
            conn = new MySqlConnection(connectionString);
            try
            {
                //open MySQL connection
                conn.Open();
                return (conn != null);
            }
            catch (MySqlException ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
        }

        public List<College> GetCollegeRecords()
        {
            List<College> collegeList = new List<College>();
            try
            {
                //establish DB connectivity
                if (ConnectDB())
                {
                    string query = "SELECT * FROM College WHERE IsActive=1";
                    //create a MySQL command with the corresponding query and connection
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //create MySQL data reader
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //check if there are any records
                    if (reader.HasRows)
                    {
                        //get the records
                        while (reader.Read())
                        {
                            //get College ID
                            int collegeID = reader.GetInt32(0);
                            //get College Name
                            string collegeName = reader.GetString(1);
                            //get College Code
                            string collegeCode = reader.GetString(2);
                            //get IsActive
                            bool isActive = reader.GetBoolean(3);
                            //create College model
                            College college = new College(collegeID, collegeName, collegeCode, isActive);
                            //add college record to the college list
                            collegeList.Add(college);
                        }
                    }
                    //dispose DB objects
                    reader.Close();
                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }

            return collegeList;
        }

        public bool AddCollegeRecord(CollegeDTO college)
        {
            bool status = false;
            try
            {
                //establish DB connectivity
                if (ConnectDB())
                {
                    //INSERT INTO College(CollegeName,CollegeCode) VALUES('xxxx','yyyyy');
                    string query = "INSERT INTO College(CollegeName, CollegeCode) VALUES('" + college.CollegeName + "','" + college.CollegeCode + "');";
                    //create a MySQL command with the corresponding query and connetion
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //create a MySQL data reader
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //check if a new record has been added
                    if (reader.RecordsAffected > 0)
                        status = true;
                    //dispose DB objects
                    reader.Close();
                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }

            return status;
        }

        public bool UpdateCollegeRecord(College college)
        {
            bool status = false;
            try
            {
                //establish DB server connection
                if (ConnectDB())
                {
                    //UPDATE College SET CollegeName='School of Nursing and Healtcare',CollegeCode='SONH' WHERE CollegeID=4;
                    string query = "UPDATE College SET CollegeName='" + college.CollegeName + "',CollegeCode='" + college.CollegeCode + "' WHERE CollegeID=" + college.CollegeID + ";";
                    //create MySQL command with the corresponding query string and connection
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //create MySQL data reader
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //check if a new record has been updated
                    if (reader.RecordsAffected > 0)
                        status = true;
                    //close DB objects
                    reader.Close();
                    cmd.Dispose();
                    conn.Close();
                }

                return status;
            }
            catch (MySqlException ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
        }

        //collegeID parameter contains the record to deactivate
        public bool DeactivateCollegeRecord(int collegeID)
        {
            bool status = false;
            try
            {
                //establish DB server connection
                if (ConnectDB())
                {
                    //UPDATE College SET IsActive=0 WHERE CollegeID=4;
                    string query = "UPDATE College SET IsActive=0 WHERE CollegeID=" + collegeID + ";";
                    //create MySQL command with the corresponding query string and connection
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //create MySQL data reader
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //check if a new record has been updated
                    if (reader.RecordsAffected > 0)
                        status = true;
                    //close DB objects
                    reader.Close();
                    cmd.Dispose();
                    conn.Close();
                }

                return status;
            }
            catch (MySqlException ex)
            { 
                //throw the exception
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
        }

        //////////////////////////////////////////// DEPARTMENTTT////////////////////////////////////////////////////////////////////////////
        //LAST
      
        public List<Department> GetDepartmentRecords()
        {
            //create college list
            List<Department> departmentList = new List<Department>();
            try
            {
                //establish DB server connection
                if (ConnectDB())
                {
                    string query = "SELECT * FROM `department` WHERE IsActive = 1 ;";
                    //create MySQL command with the corresponding query string and connection
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //create MySQL data reader
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //check if there any records
                    if (reader.HasRows)
                    {
                        //get the records
                        while (reader.Read())
                        {

                            int departmentID = reader.GetInt32(0);

                            string departmentName = reader.GetString(1);

                            string departmentCode = reader.GetString(2);

                            bool isActive = reader.GetBoolean(3);


                            Department department = new Department(departmentID, departmentName, departmentCode, isActive);
                            departmentList.Add(department);


                        }
                    }


                    reader.Close();
                    cmd.Dispose();
                    conn.Close();
                }

                return departmentList;
            }
            catch (MySqlException ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
        }

        public List<Department> ViewDepartments(int collegeID)
        {
            //create college list
            List<Department> departmentRecords = new List<Department>();
            try
            {
                //establish DB server connection
                if (ConnectDB())
                {
                    string query = "SELECT * FROM `department` WHERE IsActive = 1 AND CollegeID = " + collegeID + ";";
                    //create MySQL command with the corresponding query string and connection
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //create MySQL data reader
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //check if there any records
                    if (reader.HasRows)
                    {
                        //get the records
                        while (reader.Read())
                        {

                            int departmentID = reader.GetInt32(0);

                            string departmentName = reader.GetString(1);

                            string departmnentCode = reader.GetString(2);

                            bool isActive = reader.GetBoolean(3);


                            Department department = new Department(departmentID, departmentName, departmnentCode, isActive);
                            departmentRecords.Add(department);


                        }
                    }


                    reader.Close();
                    cmd.Dispose();
                    conn.Close();
                }

                return departmentRecords;
            }
            catch (MySqlException ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
        }

        public bool AddDepartmentRecord(DepartmentDTO departmentData)
        {
            bool status = false;
            try
            {
                //establish DB server connection
                if (ConnectDB())
                {

                    string query = "INSERT INTO department(DepartmentName,DepartmentCode) VALUES('" + departmentData.DepartmentName + "','" + departmentData.DepartmentCode + "');";
                    //create MySQL command with the corresponding query string and connection
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //create MySQL data reader
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //check if a new record has been added
                    if (reader.RecordsAffected > 0)
                        status = true;
                    //close DB objects
                    reader.Close();
                    cmd.Dispose();
                    conn.Close();
                }

                return status;
            }
            catch (MySqlException ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
        }

        //college parameter contains the record to update
        public bool UpdateDepartmentRecords(Department department)
        {
            bool status = false;
            try
            {
                //establish DB server connection
                if (ConnectDB())
                {

                    string query = "UPDATE department SET DepartmentName='" + department.DepartmentName + "',depCode='" + department.DepartmentCode + "' WHERE DepartmentID=" + department.DepartmentID+ ";";
                    //create MySQL command with the corresponding query string and connection
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //create MySQL data reader
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //check if a new record has been updated
                    if (reader.RecordsAffected > 0)
                        status = true;
                    //close DB objects
                    reader.Close();
                    cmd.Dispose();
                    conn.Close();
                }

                return status;
            }
            catch (MySqlException ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
        }


        public bool DeleteDepartmentRecords(int departmentID)
        {
            bool status = false;
            try
            {
                //establish DB server connection
                if (ConnectDB())
                {

                    string query = "UPDATE department SET IsActive=0 WHERE DepartmentID=" + departmentID + ";";
                    //create MySQL command with the corresponding query string and connection
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //create MySQL data reader
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //check if a new record has been updated
                    if (reader.RecordsAffected > 0)
                        status = true;
                    //close DB objects
                    reader.Close();
                    cmd.Dispose();
                    conn.Close();
                }

                return status;
            }
            catch (MySqlException ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                //throw the exception
                throw new Exception(ex.Message);
            }
        }


    }
}