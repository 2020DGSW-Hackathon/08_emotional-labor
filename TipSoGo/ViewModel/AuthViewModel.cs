using System;
using TipSoGo.Models;

namespace TipSoGo.ViewModel
{
    public class AuthViewModel
    {
        public bool Signup(User user)
        {
            WebApiApplication.conn.Open();
            var cmd = WebApiApplication.conn.CreateCommand();
            cmd.CommandText = String.Format("SELECT * FROM user WHERE Id = '{0}';", user.Id);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                WebApiApplication.conn.Close();
                return false;
            }
            else
            {
                cmd.CommandText = String.Format("INSERT INTO user(`Id`, `Password`, `Name`, `UserType`) VALUES ('{0}', '{1}', '{2}', '{3}');", user.Id, user.Password, user);
                cmd.ExecuteNonQuery();

                WebApiApplication.conn.Close();
                return true;
            }
        }
        public bool Login(string id, string pw)
        {
            WebApiApplication.conn.Open();
            var cmd = WebApiApplication.conn.CreateCommand();
            cmd.CommandText = String.Format("SELECT * FROM user WHERE Id = '{0}';", id);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                User u = new User()
                {
                    UserIdx = Int32.Parse(reader["UserIdx"].ToString()),
                    Id = reader["Id"].ToString(),
                    Password = reader["Password"].ToString(),
                    Name = reader["Name"].ToString(),
                    UserType = reader["UserType"].ToString()
                };
                if (pw.Equals(u.Password))
                {
                    WebApiApplication.conn.Close();
                    return true;
                }
                else
                {
                    WebApiApplication.conn.Close();
                    return false;
                }
            }
            else
            {
                WebApiApplication.conn.Close();
                return false;
            }
        }
    }
}