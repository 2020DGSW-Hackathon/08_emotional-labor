using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using TipSoGo.Models;

namespace TipSoGo.ViewModel
{
    public class BulletinBoardViewModel
    {
        public BulletinBoardViewModel()
        {
            WebApiApplication.conn = new MySqlConnection("Server = localhost; Database = tipsogo; Uid = root; Pwd = y28645506;");
        }
        public List<Bulletin> SelectAllBulletin()
        {
            WebApiApplication.conn.Open();
            var cmd = WebApiApplication.conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM bulletin;";
            var reader = cmd.ExecuteReader();

            List<Bulletin> bulletins = new List<Bulletin>();
            while (reader.Read())
            {
                bulletins.Add(new Bulletin()
                {
                    BulletinIdx = Int32.Parse(reader["BulletinIdx"].ToString()),
                    Title = reader["Title"].ToString(),
                    Contents = reader["Contents"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    NumComments = Int32.Parse(reader["NumComments"].ToString()),
                    Topic = reader["Topic"].ToString()
                }
                );
            }
            WebApiApplication.conn.Close();
            return bulletins;
        }
        public Bulletin SelectBulletin(int idx)
        {
            WebApiApplication.conn.Open();
            var cmd = WebApiApplication.conn.CreateCommand();
            cmd.CommandText = String.Format("SELECT * FROM bulletin WHERE BulletinIdx = {0};", idx);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Bulletin b = new Bulletin()
                {
                    BulletinIdx = Int32.Parse(reader["BulletinIdx"].ToString()),
                    Title = reader["Title"].ToString(),
                    Contents = reader["Contents"].ToString(),
                    UserName = reader["UserName"].ToString(),
                    NumComments = Int32.Parse(reader["NumComments"].ToString()),
                    Topic = reader["Topic"].ToString()
                };
                WebApiApplication.conn.Close();
                return b;
            }
            else
            {
                WebApiApplication.conn.Close();
                return null;
            }
        }
    }
}