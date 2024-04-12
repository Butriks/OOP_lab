using System;
using System.Windows;
using System.Windows.Controls;

namespace OOP_lab
{
    public partial class MainWindow : Window
    {
        // Поля для хранения логина и пароля
        private string login;
        private string password;

        public MainWindow()
        {
            InitializeComponent();
        }

        TaskList tasklist;

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текст из поля ввода логина и пароля
            TextBox loginTextBox = FindName("loginTextBox") as TextBox;
            PasswordBox passwordBox = FindName("passwordBox") as PasswordBox;

            if (loginTextBox != null && passwordBox != null)
            {
                login = loginTextBox.Text;
                password = passwordBox.Password;

                User user;

                // Добавьте здесь логику для проверки логина и пароля
                if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password))
                {
                    // Проверяем, существует ли пользователь с таким логином и паролем
                    User existingUser = User.IsInclude(login, password);
                    if (existingUser != null)
                    {
                        // Создаем новое окно основного интерфейса
                        MainAppWindow mainAppWindow = new MainAppWindow();
                        mainAppWindow.Show(); // Отображаем новое окно

                        // Закрываем текущее окно
                        this.Close();

                        TaskList tasklist = new TaskList(existingUser.id);

                    }
                    else
                    {
                        // Создаем нового пользователя
                        User newUser = new User(login, password, Guid.NewGuid().ToString());
                        // Добавляем пользователя в файл
                        User.Add(newUser);

                        // Очищаем поля ввода после обработки
                        loginTextBox.Text = string.Empty;
                        passwordBox.Password = string.Empty;

                        MessageBox.Show($"Пользователь с логином {login} успешно зарегистрирован.");

                        // Создаем новое окно основного интерфейса
                        MainAppWindow mainAppWindow = new MainAppWindow();
                        mainAppWindow.Show(); // Отображаем новое окно

                        // Закрываем текущее окно
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните оба поля (логин и пароль).");
                }
            }
        }
    }
}
