using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_test.Entities
{
    public class Subject
    {
        private string _title;
        private List<Student> Students { get; set; }
        public string Title
        {
            get => _title;
            set
            {
                if (value.Length != 2)
                {
                    throw new ArgumentException("Title must have 2 characters");
                }

                _title = value.ToUpper();
            }
        }

        public Subject()
        {

        }
        private Subject(string title)
        {
            Title = title;
            Students = new List<Student>();
        }
        private Subject(string title, List<Student> students)
        {
            Title = title;
            Students = students;
        }

        public static Subject Create(string title, List<Student> students = null)
        {
            Subject subject = students != null ? new(title, students) : new(title);

            return subject;
        }

        public void AttachStudent(Student student)
        {
            if (!Students.Any(s => s.Name == student.Name && s.Subject == student.Subject))
            {
                Students.Add(student);
                Console.WriteLine("Estudante adicionado.");
            }
        }

        public void ListStudents()
        {
            Console.WriteLine($"Alunos da turma de {Title} ({Students.Count}):");
            foreach (Student student in Students)
            {
                Console.WriteLine(student.Name);
            }
        }
    }
}