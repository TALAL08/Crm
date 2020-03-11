namespace Crm.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public string ContactNo { get; set; }

        public Store Store { get; set; }

        public Designation Designation { get; set; }

        public EmployeeDetails EducationalPersonalDetails { get; set; }

        public EmployeeAccountDetails AccountDetails { get; set; }


        public int EmployeeDetailsId { get; set; }

        public int EmployeeAccountDetailsId { get; set; }
        public int StoreId { get; set; }

        public int DesignationId { get; set; }


    }
}