using System;

namespace UserBank
{
    public class Users
    {
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
       
        // check for user.
        private void CheckUserRegisterButton()
        {
            using (SQLiteCommand checkUserCommand = new SQLiteCommand(
           "SELECT * FROM users WHERE username=@username", connection))
            {
                checkUserCommand.Parameters.AddWithValue("@username", username);

                using (SQLiteDataReader reader = checkUserCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Имя пользователя '{username}' уже занято.");
                    }
                    else
                    {
                       RegisterUser();
                    }
                }
            }

        }
        private void RegisterUser()
        {
            string fullname = FullName;
            string nickname = NickName;
            string email = Email;
            string password = Password;
            string phone = Phone;
            
            //add
            // Добавление пользователя, если имя не занято
            using (SQLiteCommand addUserCommand = new SQLiteCommand(
                "INSERT INTO users (username) VALUES (@username)", connection))
            {
                addUserCommand.Parameters.AddWithValue("@username", username);
                addUserCommand.ExecuteNonQuery();
                Console.WriteLine($"Имя пользователя '{username}' успешно добавлено в базу данных.");
            }
        }

        private void SignInUser()
        {
            string nickName = "";
            string Password = "";

            string checkName = "";
            string checkPass = "";
        }
    }

}