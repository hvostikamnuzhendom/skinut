using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            logic.AddStudent("Иванов И.И.", "Программная инженерия", "КИ23-16Б");
            logic.AddStudent("Петров П.П.", "Компьютерная безопасность", "КИ23-17Б");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("DecanatPRO Console");
                Console.WriteLine("1. Вывести список студентов");
                Console.WriteLine("2. Добавить студента");
                Console.WriteLine("3. Удалить студента");
                Console.WriteLine("4. Выйти");

                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    foreach (var s in logic.Students)
                    {
                        Console.WriteLine($"[{s.Id}] {s.Name} | {s.Group} | {s.Speciality}");
                    }
                    Console.ReadKey();
                }
                else if (choice == "2")
                {
                    Console.Write("ФИО: "); string name = Console.ReadLine();
                    Console.Write("Специальность: "); string spec = Console.ReadLine();
                    Console.Write("Группа: "); string group = Console.ReadLine();

                    logic.AddStudent(name, spec, group);
                }
                else if (choice == "3")
                {
                    Console.WriteLine("\nУдаление студента");
                    Console.Write("Введите ID студента для удаления: ");

                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        logic.DeleteStudent(id);
                        Console.WriteLine("Студент успешно удален.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ID.");
                    }
                    Console.ReadKey();
                }
                else if (choice == "4") break;
            }
        }
    }
}
