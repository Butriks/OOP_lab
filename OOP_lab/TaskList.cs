using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOP_lab
{
    internal class TaskList
    {
        public List<Task> TaskListItems { get; private set; }

        public TaskList(string userId)
        {
            TaskListItems = new List<Task>();
            string filePath = @"D:\OOP_lab\tasks.txt";

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                bool isCurrentUserId = false;
                List<string> taskLines = new List<string>();

                foreach (string line in lines)
                {
                    if (line.Trim() == userId)
                    {
                        // Начало задач для текущего пользователя
                        isCurrentUserId = true;
                        taskLines.Clear(); // Очищаем предыдущие строки задач
                        continue;
                    }

                    if (isCurrentUserId)
                    {
                        if (line.Trim() == string.Empty)
                        {
                            // Конец задач для текущего пользователя
                            isCurrentUserId = false;

                            // Создаем задачи на основе считанных строк
                            foreach (string taskLine in taskLines)
                            {
                                string[] taskData = taskLine.Split(';'); // Разделитель данных задачи
                                if (taskData.Length >= 7)
                                {
                                    DateTime dateOfReg = DateTime.Parse(taskData[0]);
                                    DateTime dateOfEnd = DateTime.Parse(taskData[1]);
                                    string title = taskData[2];
                                    string description = taskData[3];
                                    int priority = int.Parse(taskData[4]);
                                    string category = taskData[5];

                                    Task task = new Task(dateOfReg, dateOfEnd, title, description, priority, category);
                                    TaskListItems.Add(task);
                                }
                            }

                            taskLines.Clear(); // Очищаем список строк задач
                            continue;
                        }

                        // Добавляем строку задачи к списку строк
                        taskLines.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }


        }

        void show() { 
            
        }

    }

    
}
