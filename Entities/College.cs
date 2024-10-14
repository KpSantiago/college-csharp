using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_test.Entities
{
    public class College
    {
        public List<Subject> Subjects { get; }
        public List<Student> Students { get; }
        public College()
        {
            Subjects = new List<Subject>();
            Students = new List<Student>();
        }

        public void AttachSubject(Subject subject)
        {
            if (!Subjects.Any(s => s.Title == subject.Title))
            {
                Subjects.Add(subject);
            }
        }

        public void AttachStudent(Student student)
        {
            if (!Students.Any(s => s.Name == student.Name && s.Subject == student.Subject))
                Students.Add(student);

            if (Subjects.Any(s => s.Title == student.Subject))
            {
                Subjects.Find(s => s.Title == student.Subject).AttachStudent(student);
            }
            else
            {
                Subject subject = Subject.Create(student.Subject);
                subject.AttachStudent(student);
                AttachSubject(subject);
            }
        }

        public void ListStudents()
        {
            // .ForEach(action) => o método recebe um parametro que realizará uma ação ao ser rodado
            // Students
            // .FindAll(student => student.Subject == subjectTitle)
            // .ForEach(action: student => Console.WriteLine(student.Name));
            Console.WriteLine("Turma  |  Aluno");
            Students.ForEach(action: s => Console.WriteLine($"{s.Subject}     |  {s.Name}"));
        }

        public void ListSubjectStudents(string subjectTitle)
        {
            if (Subjects.Any(s => s.Title == subjectTitle.ToUpper()))
                Subjects.Find(s => s.Title == subjectTitle.ToUpper()).ListStudents();
        }

        public void ListSubjects()
        {
            Console.WriteLine("Turmas:");
            foreach (Subject subject in Subjects)
            {
                Console.WriteLine(subject.Title);
            }
        }

        public void RemoveStudent(string student)
        {
            if (Students.Remove(Students.Find(s => s.Name == student)))
            {
                Console.WriteLine("Aluno removido");
            }
        }

        public void RemoveSubject(string subject)
        {
            Subject sub = Subjects.Find(s => s.Title == subject);
            if (Subjects.Remove(sub))
            {
                Students.RemoveAll(s => s.Subject == sub.Title);
                Console.WriteLine("Turma removida");
            };
        }
    }
}