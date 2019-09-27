using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1Сompletion
{
    class Program
    {
        public static string menu;

        static void Startmenu()
        {
            Console.WriteLine();
            Console.WriteLine("Для просмотра нажмите - 0");
            Console.WriteLine("Для добавления учеников в список нажмите - 1");
            Console.WriteLine("Для добавления групп нажмите - 2");
            Console.WriteLine("Для выхода введите - exit");
            menu  = Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Консольное приложение TTHK:");
            List<Students> students = new List<Students>
            {
                new Students("Vlad", "Voloshko", "12525865882", "IsStuding"),
                new Students("Nikita", "Harkov", "12356841233", "IsStuding"),
                new Students("Robert", "Tamm", "12368454567", "IsStuding")
            };

            List<Group> group = new List<Group>
            {
                new Group("TARgv18")
            };

            while (menu != "exit")
            {
                Startmenu();
                if (menu == "1")
                {
                    Console.WriteLine("Список учеников: ");
                    for (int i = 0; i < students.Count(); i++)
                    {
                        Console.WriteLine(students[i].FirstName + " " + students[i].LastName + " " + students[i].PersonalCode + " " + students[i].Status);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Введите имя ученика");
                    string fname = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Введите фамилию ученика");
                    string lname = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Введите персональный код ученика");
                    string code = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Введите статус ученика");
                    string status = Console.ReadLine();

                    students.Add(new Students(fname, lname, code, status));
                    Console.WriteLine();
                    Console.WriteLine("Список учеников: ");
                    for (int i = 0; i < students.Count(); i++)
                    {
                        Console.WriteLine(students[i].FirstName + " " + students[i].LastName + " " + students[i].PersonalCode + " " + students[i].Status);
                    }
                }
                else if (menu == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("Группы в списке: ");
                    for (int i = 0; i < group.Count(); i++)
                    {
                        Console.WriteLine(group[i].GroupName);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Введите новую группу в список");
                    string newgroup = Console.ReadLine();
                    group.Add(new Group(newgroup));
                    Console.WriteLine();
                    Console.WriteLine("Группы в списке: ");
                    for (int i = 0; i < group.Count(); i++)
                    {
                        Console.WriteLine(group[i].GroupName);
                    }
                }
                else if (menu == "0")
                {
                    Console.WriteLine();
                    int o = 0;
                    while (o != 1)
                    {
                        Console.WriteLine("Введите название группы!");
                        string findgroup = Console.ReadLine();
                        Group chosengroup = group.FirstOrDefault(x => x.GroupName == findgroup);

                        if (chosengroup == null)
                        {
                            Console.WriteLine("Извините, группы " + findgroup + " в списке нет!");
                            Console.WriteLine();
                            o = 0;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Группа " + findgroup + ":");
                            o = 1;
                        }
                    }
                    if (o == 1)
                    {
                        List<Students> findgroup = new List<Students>(); //Дублирование списка students
                        findgroup.AddRange(students.ToArray());
                        for (int i = 0; i < findgroup.Count(); i++)
                        {
                            Console.WriteLine(findgroup[i].FirstName + " " + findgroup[i].LastName);
                        }
                        while ( o != 2)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Удалить ученика из группы - remove");
                            Console.WriteLine("Добавить ученика в группу - add");
                            Console.WriteLine("Выйти - exit");
                            string choice = Console.ReadLine();
                            if (choice == "remove")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Введите имя ученика, которого хотите удалить из группы");
                                string removeName = Console.ReadLine();
                                int index = findgroup.FindIndex(x => x.FirstName == removeName); //поиск индекса
                                findgroup.RemoveAt(index);//удаление по индексу

                                Console.WriteLine();
                                Console.WriteLine("Введите причину удаления");
                                string reason = Console.ReadLine();
                                Console.WriteLine("Ученик "+ students[index].FirstName + " " + students[index].LastName + " " + students[index].PersonalCode + " удалён по причине " + reason);


                                Console.WriteLine();
                                for (int i = 0; i < findgroup.Count(); i++)
                                {
                                    Console.WriteLine(findgroup[i].FirstName + " " + findgroup[i].LastName);
                                }
                            }
                            else if (choice == "add")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Введите имя ученика, которого хотите добавить в группу");
                                string addName = Console.ReadLine();
                                int index = students.FindIndex(x => x.FirstName == addName);
                                findgroup.Add(students[index]);
                                Console.WriteLine();
                                for (int i = 0; i < findgroup.Count(); i++)
                                {
                                    Console.WriteLine(findgroup[i].FirstName + " " + findgroup[i].LastName);
                                }
                            }
                            else if (choice == "exit")
                            {
                                o = 2;
                            }
                        }
                    }
                }
            }

        }
    }
}
