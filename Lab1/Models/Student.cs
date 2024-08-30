using System.Diagnostics.Eventing.Reader;

namespace Lab1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Branchs Branch { get; set; }
        public Gender Gender { get; set; }
        public bool IsRegular { get; set; }
        public string? Address { get; set; }
        public DateTime DateofBirth { get; set; }

        public string? Avatar { get; set; }
    }
}
