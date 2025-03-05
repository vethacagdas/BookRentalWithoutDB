using BookRentalWithoutDB.Data;
using BookRentalWithoutDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalWithoutDB.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            StudentRespository repository = new StudentRespository();
            var students = repository.GetAllStudents();
            return View(students);
        }

        public IActionResult Detail(int id)
        {
            StudentRespository repository = new StudentRespository();
            var student = repository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return View(student);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            StudentRespository repository = new StudentRespository();

            // Aynı ID varsa pop-up ile uyarı göster
            if (repository.GetStudent(student.ID) != null)
            {
                TempData["ErrorMessage"] = "Bu ID daha önce kullanıldı! Lütfen yeni bir ID girin.";
                return View(student);
            }

            repository.Insert(student);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            StudentRespository repository = new StudentRespository();
            var student = repository.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            StudentRespository repository = new StudentRespository();
            var student = repository.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student updatedStudent)
        {
            StudentRespository repository = new StudentRespository();
            var student = repository.GetStudent(updatedStudent.ID);

            if (student == null)
            {
                return NotFound();
            }

            student.Name = updatedStudent.Name;
            student.Surname = updatedStudent.Surname;
            student.BirthDate = updatedStudent.BirthDate;

            repository.Update(student);

            return RedirectToAction("Index");
        }


    }
}
