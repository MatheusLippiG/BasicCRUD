using System;
using System.Collections.Generic;

namespace BasicCrudProject
{
    class Program
    {

        static List<string> TodoList = new List<string>();

        public static void Main(string[] args)
        {
            Menu2();
        }

        public static void Menu2()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("------ TO DO LIST ------");
                Console.WriteLine("Choose your option:");
                Console.WriteLine("1 - Create Task");
                Console.WriteLine("2 - Read Task");
                Console.WriteLine("3 - Update Task");
                Console.WriteLine("4 - Delete Task");
                Console.WriteLine("0 - Exit");

                var option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1: CreateTasks(); break;
                    case 2: ReadTasks(); break;
                    case 3: UpdateTasks(); break;
                    case 4: DeleteTasks(); break;
                    case 0: System.Environment.Exit(0); break;
                    default: Menu2(); break;
                }
            }
        }
        public static void CreateTasks()
        {
            Console.Clear();
            Console.WriteLine("Task name:");
            string taskName = Console.ReadLine();

            TodoList.Add(taskName);
            Console.WriteLine("Task added with success!");
            Msg1();
            Console.ReadKey();
        }

        public static void ReadTasks()
        {
            Console.Clear();
            Console.WriteLine("Task list:");
            for (int i = 0; i < TodoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {TodoList[i]}");
            }
            Console.WriteLine("This is the list of tasks\nPress any button");
            Console.ReadKey();
        }

        public static void UpdateTasks()
        {
            ReadTasks();
            Console.WriteLine("Choose the number of the task that you want to update/modify");
            int task = int.Parse(Console.ReadLine());
            if (task > 0 && task <= TodoList.Count)
            {
                Console.WriteLine("Choose the new name that you want");
                string newTask = Console.ReadLine();
                TodoList[task - 1] = newTask;
                Console.WriteLine("Task updated with success!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Task not found or invalid number");
            }
        }

        public static void DeleteTasks()
        {
            ReadTasks();
            Console.WriteLine("Select the task that you want to delete:");
            var taskRemove = int.Parse(Console.ReadLine());
            if (taskRemove > 0 && taskRemove <= TodoList.Count)
            {
                TodoList.RemoveAt(taskRemove - 1);
            }
        }

        public static void ShowTasks()
        {
            Console.Clear();
            Console.WriteLine("Task list:");
            for (int i = 0; i < TodoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {TodoList[i]}");
            }
        }

        public static void Msg1()
        {
            Console.WriteLine("Press any key to go back to menu");
        }
    }
}