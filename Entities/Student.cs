using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_test.Entities
{
    public class Student
    {
        private string _name;
        private string _subject;

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name must have more than 2 characters");
                }

                _name = value;
            }
        }

        public string Subject
        {
            get => _subject;
            set
            {
                if (value.Length != 2)
                {
                    throw new ArgumentException("Subject must have 2 characters");
                }

                _subject = value.ToUpper();
            }
        }

        public Student() { }

        private Student(string name, string subject)
        {
            Name = name;
            Subject = subject;
        }

        public static Student Create(string name, string subject)
        {
            Student student = new(name, subject);

            return student;
        }
    }
}