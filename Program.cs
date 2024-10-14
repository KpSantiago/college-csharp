using System;
using projeto_test.Entities;

namespace projeto_test.NET6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;

            College college = new();
            while (!stop)
            {
                Console.Clear();
                Console.WriteLine("1 - Adicionar aluno \n2 - Adicionar turma \n3 - Listar alunos \n4 - Listar turmas");
                Console.WriteLine("5 - Listar alunos de uma turma \n6 - Deletar aluno \n7 - Deletar turma \n8 - Encerrar");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Digite o nome do aluno:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Digite o nome da turma:");
                        string subject = Console.ReadLine();

                        college.AttachStudent(Student.Create(name, subject));
                        break;
                    case "2":
                        Console.WriteLine("Digite o nome da turma:");
                        college.AttachSubject(Subject.Create(Console.ReadLine()));
                        break;
                    case "3":
                        college.ListStudents();
                        break;
                    case "4":
                        college.ListSubjects();
                        break;
                    case "5":
                        Console.WriteLine("Digite o nome da turma:");
                        college.ListSubjectStudents(Console.ReadLine());
                        break;
                    case "6":
                        Console.WriteLine("Digite o nome do aluno:");
                        college.RemoveStudent(Console.ReadLine());
                        break;
                    case "7":
                        Console.WriteLine("Digite o nome da turma:");
                        college.RemoveSubject(Console.ReadLine().ToUpper());
                        break;
                    case "8":
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Valor inválido");
                        break;
                }

                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();
            }
            
            Console.WriteLine("O programa encerrou.");
        }
    }
}