using System;

namespace Lesson_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "data.txt";
            Repository rep = new Repository(path);
            rep.Load();
            while (true)
            {
                Console.WriteLine("Выбирайте действие и нажмите соответствующую кнопку:");
                Console.WriteLine("1 - Просмотр записи");
                Console.WriteLine("2 - Создать запись");
                Console.WriteLine("3 - Удалить запись");
                Console.WriteLine("4 - Редактировать запись");
                Console.WriteLine("5 - Загрузить записи в диапозоне дат");
                Console.WriteLine("6 - Сортировка по возрастанию даты");
                Console.WriteLine("7 - Сортировка по убыванию даты");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        rep.PrintToConsole();
                        Console.WriteLine("Всего сотрудников: " + rep.Count);
                        break;
                    case 2:
                        Console.WriteLine("Введите ID:");
                        int id = rep.IdCount();
                        DateTime timenow = DateTime.Now;
                        Console.WriteLine($"Введите Дату и время добавления записи:\n{timenow}");
                        Console.WriteLine("Введите Ф.И.О:");
                        string fullName = Console.ReadLine();
                        Console.WriteLine("Введите возраст:");
                        string age = Console.ReadLine();
                        Console.WriteLine("Введите рост:");
                        string growth = Console.ReadLine();
                        Console.WriteLine("Введите дату рождения:");
                        string dateBirth = Console.ReadLine();
                        Console.WriteLine("Введите место рождения:");
                        string placeBirth = Console.ReadLine();
                        rep.Add(new Worker(Convert.ToInt32(id), timenow, fullName, age, growth, dateBirth, placeBirth));
                        rep.Save();
                        rep.Load();
                        break;
                    case 3:
                        Console.WriteLine("Введите ID что бы удалить запись: ");
                        var removeId = Convert.ToInt32(Console.ReadLine());
                        rep.Remove(removeId);
                        rep.Save();
                        rep.Load();
                        Console.WriteLine("Сотрудник успешно удалён");
                        break;
                    case 4:
                        Console.WriteLine("Введите ID что бы редактировать запись: ");
                        var editId = Convert.ToInt32(Console.ReadLine());
                        var staff = rep.GetId(editId);

                        Console.WriteLine($"ID: {editId}");
                        int newId = editId;
                        staff.Id = newId;

                        DateTime newTimenow = DateTime.Now;
                        Console.WriteLine($"Дата и время редактирования:\n{newTimenow}");
                        staff.TimeDate = newTimenow;

                        Console.WriteLine("Введите новые Ф.И.О:");
                        string newFullName = Console.ReadLine();
                        staff.FullName = newFullName;

                        Console.WriteLine("Введите новый возраст:");
                        string newAge = Console.ReadLine();
                        staff.Age = newAge;

                        Console.WriteLine("Введите новый рост:");
                        string newGrowth = Console.ReadLine();
                        staff.Growth = newGrowth;

                        Console.WriteLine("Введите новую дату рождения:");
                        string newDateBirth = Console.ReadLine();
                        staff.DateOfBirth = newDateBirth;

                        Console.WriteLine("Введите новое место рождения:");
                        string newPlaceBirth = Console.ReadLine();
                        staff.PlaceOfBirth = newPlaceBirth;
                        rep.Edit(staff, editId);
                        rep.Save();
                        Console.WriteLine("Данные успешно изменены");
                        break;
                    case 5:
                        Console.WriteLine("Введите дату от которой будет поиск:");
                        string a = Console.ReadLine();
                        Console.WriteLine("Введите дату до которой будет поиск:");
                        string b = Console.ReadLine();
                        rep.DateSearch(a, b);
                        break;
                    case 6:
                        rep.SortMinMax();
                        break;
                    case 7:
                        rep.SortMaxMin();
                        break;
                    default:
                        continue;
                }
                Console.ReadKey();
            }
        }
    }
}
