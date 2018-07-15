using System.ComponentModel.DataAnnotations;

namespace Generic.Database.Poco
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
    }
}
