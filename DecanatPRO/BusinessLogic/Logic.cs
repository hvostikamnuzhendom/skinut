using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Logic
    {
        public List<Student> Students { get; set; } = new List<Student>();

        private int _nextId = 1;

        public void AddStudent(string name, string speciality, string group)
        {
            var student = new Student
            {
                Id = _nextId++, // Присваиваем текущий ID и увеличиваем счетчик
                Name = name,
                Speciality = speciality,
                Group = group
            };
            Students.Add(student);
        }

        // Удаление теперь работает надежно — строго по уникальному ID
        public void DeleteStudent(int id)
        {
            Students.RemoveAll(s => s.Id == id);
        }
    }
}
