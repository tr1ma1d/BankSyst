using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
namespace Banking_System.Models
{
    internal class Users
    {
        static public string connectionString = "server=localhost;userid=root;database=test;password=12345678;sslmode=none";
        static public string FullName { get; set; }
        static public string NickName { get; set; }
        static public string Email { get; set; }
        static public string Password { get; set; }
        static public string Phone { get; set; }
       
        static public string Cash { get; set; }
        // make new account of register
        static public bool CheckUserRegisterButton()
        {

            string nickname = NickName;

            string sqlQuery = "SELECT * FROM `users` WHERE `userName` = @uN";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = nickname;

            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show($"Имя пользователя '{nickname}' уже занято. ");
            }
            else
            {
                return true;
            }
            connection.Close();
            return false;
        }
        static public void RegisterUser()
        {
            string fullname = FullName;
            string nickname = NickName;
            string email = Email;
            string password = Password;
            string phone = Phone;
            string cash = Cash;
            Random rnd = new Random();
            int admin = rnd.Next(1, 2);    
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string sqlQuery = $"INSERT INTO `users` (`userName`,`FullName`,`userPassword`,`Phone`,`Email`,`idEmployes_Users`,`Cash`) VALUES ('{nickname}','{fullname}','{password}','{phone}','{email}','{admin}', '{cash}')";


            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            int rowsAffected = command.ExecuteNonQuery();
           

            if (rowsAffected > 0)
            {
                MessageBox.Show("User added successfully");
            }
            else
            {
                MessageBox.Show("Failed to add user");
            }

            connection.Close();
        }

        //Make sign in
        static public bool SignIn()
        {
            string nickname = NickName;
            string password = Password;
            string sqlQuery = "SELECT * FROM `users` WHERE `userName` = @uN AND `userPassword` = @uP";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = nickname;
            command.Parameters.AddWithValue("@uP", password);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                MessageBox.Show("Вход успешно произведен");
                return true;
             
            }
            connection.Close();
            return false;
        }
        static public bool CheckEmployes()
        {
            string nickname = NickName;
            string sqlQuery = "SELECT * FROM `employes` WHERE `emplyesName` = @uN";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = nickname;
          
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Вход успешно произведен");
                return true;

            }
            connection.Close();
            return false;
        }
    }
}
