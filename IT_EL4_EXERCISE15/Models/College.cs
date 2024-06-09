namespace IT_EL4_EXERCISE15.Models
{
        public class College
    {
        private int collegeID;
        private string collegeName;
        private string collegeCode;
        private bool isActive;

        //constructors
        public College()
        {

        }

        public College(int collegeID, string collegeName, string collegeCode, bool isActive)
        {
            this.collegeID = collegeID;
            this.collegeName = collegeName;
            this.collegeCode = collegeCode;
            this.isActive = isActive;
        }

        public int CollegeID { get => collegeID; set => collegeID = value; }
        public string CollegeName { get => collegeName; set => collegeName = value; }
        public string CollegeCode { get => collegeCode; set => collegeCode = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
    }
}
