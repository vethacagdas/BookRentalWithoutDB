using BookRentalWithoutDB.Models;
using System.Linq; // Where ve FirstOrDefault kullanımı için eklendi.
using System.Collections.Generic; // List için eklendi.
using System; // DateTime için eklendi.

namespace BookRentalWithoutDB.Data
{
    public class StudentRespository
    {
        static List<Student> data = new List<Student>
        {
            new Student { ID = 1, Name = "Hüseyin", Surname = "Şimşek", BirthDate = new DateTime(1990, 1, 1) },
            new Student { ID = 2, Name = "Mehmet", Surname = "Yıldız", BirthDate = new DateTime(2001, 1, 1) },
            new Student { ID = 4, Name = "Ayşe", Surname = "Kaya", BirthDate = new DateTime(2004, 1, 1) }
        };

        public List<Student> GetAllStudents()
        {
            return data; // "Select * from Students";
        }

        public Student GetStudent(int id)
        {
            Student result = data.Where(s => s.ID == id).FirstOrDefault();
            return result;
        }

        public void Delete(int id)
        {
            var student = GetStudent(id);
            data.RemoveAll(d=> d.ID==id);

        }

        public void Insert(Student student)
        {
            data.Add(student);
        }

        public void Update(Student student)
        {
            var studentInDB = data.FirstOrDefault(s => s.ID == student.ID);

            if (studentInDB != null) // Eğer öğrenci bulunursa güncelle
            {
                studentInDB.Name = student.Name;
                studentInDB.Surname = student.Surname;
                studentInDB.BirthDate = student.BirthDate;
            }
        }

    }

}