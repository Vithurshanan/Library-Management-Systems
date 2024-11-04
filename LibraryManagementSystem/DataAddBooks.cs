﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    internal class DataAddBooks
    {

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Admin User\Documents\library.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True");


        public int ID { set; get; }
        public string BookTitle { set; get; }
        public string Author { set; get; }
        public string Published { set; get; }
        public string image {  set; get; }  
        public string Status { set; get; }

        public List<DataAddBooks> addBooksData()
        {
            List<DataAddBooks> ListData = new List<DataAddBooks>();


            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();


                    String selectData = "SELECT * FROM books WHERE date_delete IS NULL";


                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        

                        while (reader.Read())
                        {
                            DataAddBooks dab = new DataAddBooks();
                            dab.ID = (int)reader["id"];
                            dab.BookTitle = reader["books_title"].ToString();
                            dab.Author = reader["author"].ToString();
                            dab.Published = reader["published_date"].ToString();
                            dab.image = reader["image"].ToString();
                            dab.Status = reader["status"].ToString();

                            ListData.Add(dab);
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting Database :" + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return ListData;
        }
    }

}
