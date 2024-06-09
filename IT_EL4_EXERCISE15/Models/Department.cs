namespace IT_EL4_EXERCISE15.Models
{
    public class Department
    {
        private int departmentID;
        private string departmentName;
        private string departmentCode;
        private bool isActive;
    
        //constructors
        public Department()
        {

        }

        public Department(int departmentID, string departmentName, string departmentCode, bool isActive)
        {
            this.departmentID = departmentID;
            this.departmentName = departmentName;
            this.departmentCode = departmentCode;
            this.isActive = isActive;
        }

        public int DepartmentID { get => departmentID; set => departmentID = value; }
        public string DepartmentName { get => departmentName; set => departmentName = value; }
        public string DepartmentCode { get => departmentCode; set => departmentCode = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
    }
}
