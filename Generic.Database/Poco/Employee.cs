using System.ComponentModel.DataAnnotations;

namespace Generic.Database.Poco
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
    }
}
