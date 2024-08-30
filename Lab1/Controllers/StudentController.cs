using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab1.Models;

namespace Lab1.Controllers
{
    public static class Database
    {
        public static List<Student> listStudents = new List<Student>
        {
                new Student { Id = 1, Name = "Nguyen Van A", Branch = Branchs.IT, Gender = Gender.Male,
                    IsRegular = true, Address = "A1-2018", Email = "nguyenvana@gmail.com", Avatar = "/avatars/default.png"},
                new Student { Id = 2, Name = "Tran Thi B", Branch = Branchs.BE, Gender = Gender.Male,
                    IsRegular = false, Address = "A2-2018", Email = "tranthib@gmail.com", Avatar = "/avatars/default.png"},
                new Student { Id = 3, Name = "Pham Van C", Branch = Branchs.CE, Gender = Gender.Male,
                    IsRegular = true, Address = "A3-2018", Email = "tranvanc@gmail.com", Avatar = "/avatars/default.png"},
                new Student { Id = 4, Name = "Hoang Thi D", Branch = Branchs.EE, Gender = Gender.Male,
                    IsRegular = true, Address="A4-2018", Email ="hoangthid@gmail.com", Avatar = "/avatars/default.png"}
        };
    }
    public class StudentController : Controller
    {

        public IActionResult Index()
        {
            return View(Database.listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Lấy danh sách các giá trị Gender để hiển thị radio button trên form 
            ViewBag.AllGender = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            // Lấy danh sách các giá trị Branch để hiển thị dropdownlist trên form
            ViewBag.AllBranchs = new List<SelectListItem>
            {
                new SelectListItem { Text = "IT", Value = "0" },
                new SelectListItem { Text = "BE", Value = "1" },
                new SelectListItem { Text = "CE", Value = "2" },
                new SelectListItem { Text = "EE", Value = "3" }
            };
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student, IFormFile avatarFile)
        {
		if (avatarFile != null && avatarFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/avatars", avatarFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        avatarFile.CopyTo(stream);
                    }
                    student.Avatar = "/avatars/" + avatarFile.FileName;
                }
                else
                {
                    student.Avatar = "/avatars/default.png";
                }
                student.Id = Database.listStudents.Count + 1;
                Database.listStudents.Add(student);
                return View("Index", Database.listStudents);
        }
    }
}
