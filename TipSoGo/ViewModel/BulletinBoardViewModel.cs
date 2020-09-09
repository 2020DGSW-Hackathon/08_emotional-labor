using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TipSoGo.Models;

namespace TipSoGo.ViewModel
{
    public class BulletinBoardViewModel
    {
        public List<Bulletin> SelectAllBulletin()
        {
            WebApiApplication.conn.Open();
            var cmd = WebApiApplication.conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM bulletin ORDER BY BulletinIdx DESC;";
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
                    Topic = reader["Topic"].ToString(),
                    CreatedDate = reader["CreatedDate"].ToString()
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
        public bool InsertBulletin(Bulletin b)
        {
            WebApiApplication.conn.Open();
            var cmd = WebApiApplication.conn.CreateCommand();
            cmd.CommandText = String.Format("INSERT INTO bulletin" +
                "(Title, Contents, UserName, NumComments, Topic, CreatedDate)" +
                " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');"
                , b.Title, b.Contents, b.UserName, b.NumComments, b.Topic, b.CreatedDate);
            cmd.ExecuteNonQuery();
            WebApiApplication.conn.Close();
            return true;
        }
        public List<Comment> GetComments(int idx)
        {
            WebApiApplication.conn.Open();
            var cmd = WebApiApplication.conn.CreateCommand();
            cmd.CommandText = String.Format("SELECT * FROM Comments WHERE BulletinIdx = {0};", idx);
            var reader = cmd.ExecuteReader();
            List<Comment> comments = new List<Comment>();
            if (reader.Read())
            {
                comments.Add(new Comment()
                {
                    CommentsIdx = Int32.Parse(reader["CommentsIdx"].ToString()),
                    UserIdx = Int32.Parse(reader["UserIdx"].ToString()),
                    BulletinIdx = Int32.Parse(reader["BulletinIdx"].ToString()),
                    Contents = reader["Contents"].ToString(),
                    CreatedDate = reader["CreatedDate"].ToString()
                });
                WebApiApplication.conn.Close();
                return comments;
            }
            else
            {
                WebApiApplication.conn.Close();
                return null;
            }
        }
        public bool InsertComment(Comment c)
        {
            WebApiApplication.conn.Open();
            var cmd = WebApiApplication.conn.CreateCommand();
            cmd.CommandText = String.Format("INSERT INTO comments" +
                "(UserIdx, BulletinIdx, Contents, CreatedDate)" +
                " VALUES ({0}, {1}, '{2}', '{3}');",
                c.UserIdx, c.BulletinIdx, c.Contents, c.CreatedDate);
            cmd.ExecuteNonQuery();
            WebApiApplication.conn.Close();
            return true;
        }
    }
}