using System;

namespace BuraksRecordShopHRM.Shared
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? ExitDate { get; set; }
    }
}
