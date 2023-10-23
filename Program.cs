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
                Console.WriteLine("5 - Save file");
                Console.WriteLine("6 - Open file");
                Console.WriteLine("0 - Exit");

                var option = int.Parse(Console.ReadLine());


                switch (option)
                {
                    case 1: CreateTasks(); break;
                    case 2: ReadTasks(); break;
                    case 3: UpdateTasks(); break;
                    case 4: DeleteTasks(); break;
                    case 5: Save(); break;
                    case 6: OpenFile(); break;
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
            Console.WriteLine("Task added with success!\n Press any key");
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
            Console.WriteLine("This is the list of tasks\nPress any key");
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
        public static void Save()
        {
            Console.Clear();
            Console.WriteLine("Where do you want to save the file?");

            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                foreach (string s in TodoList)
                    file.Write(s);
            }

            Console.WriteLine($"File {path} saved with success!\n Press any key");
            Console.ReadKey();
        }

        public static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Enter the file path");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}