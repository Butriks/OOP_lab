using System;
using System.IO;

namespace OOP_lab
{
    internal class User
    {
        public string name;
        public string password;
        public string id;

        public User(string name, string password, string id)
        {
            this.name = name;
            this.password = password;
            this.id = id;
        }

        // Метод для проверки наличия пользователя по логину и паролю
        public static User IsInclude(string login, string password)
        {
            string usersFilePath = @"D:\OOP_lab\users.txt"; // Путь к файлу с пользователями

            try
            {
                // Считываем все строки из файла
                string[] lines = File.ReadAllLines(usersFilePath);

                // Поиск пользователя с заданным логином и паролем
                foreach (string line in lines)
                {
                    string[] userData = line.Split(' ');
                    if (userData.Length >= 3)
                    {
                        string storedLogin = userData[0];
                        string storedPassword = userData[1];
                        string storedId = userData[2];

                        // Сравниваем логин и пароль
                        if (storedLogin == login && storedPassword == password)
                        {
                            // Пользователь найден, возвращаем объект User
                            return new User(storedLogin, storedPassword, storedId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }

            // Если пользователь не найден, возвращаем null
            return null;
        }

        // Метод для добавления нового пользователя в файл
        public static void Add(User user)
        {
            string usersFilePath = @"D:\OOP_lab\users.txt"; // Путь к файлу с пользователями

            try
            {
                // Открыть файл для дополнения данных в конец
                using (StreamWriter writer = File.AppendText(usersFilePath))
                {
                    // Записать нового пользователя в файл
                    writer.WriteLine($"{user.name} {user.password} {user.id}");
                }

                Console.WriteLine("Пользователь успешно добавлен в файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении пользователя в файл: {ex.Message}");
            }
        }
    }
}
