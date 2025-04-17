using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace POS
{
    class Dish
    {
        private string _connectionString;
        private string name;
        public string Name
        {
            get {return name;}
            set{
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                else {name = value;}
            }
        }
        public string? Description {get; set;}
        private decimal price;
        public decimal Price
        {
            get {return price;}
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
                else {price = 0;}
            }
        }

        private string type;
        public string Type 
        {
            get; set;
        }
        private bool availability;
        public bool Availability
        {
            get; set;
        }

        public Dish()
        {
            _connectionString = File.ReadAllText("config.txt");
        }

        public void ShowInfo(string name)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetDishByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", "%" + name + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Name = reader["Name"].ToString();
                        Description = reader["Description"].ToString();
                        Price = (decimal)reader["Price"];
                        Type = reader["Type"].ToString();
                        
                        if ((int)reader["Availability"] != 0)
                        {
                            Availability = true;
                        }
                        else {Availability = false;}
                        
                    }
                }
            }
            Console.Write($"Dish: {Name}\nDescription: {Description}\nPrice: {Price}\nType: {Type}\nAvailability: {Availability}");
        }
        
    }
}