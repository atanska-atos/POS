using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace POS
{
    class Dish
    {
        private string? name;
        public string? Name
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
        private decimal? price;
        public decimal? Price
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
        public string? Type 
        {
            get; set;
        }
        public int? Availability
        {
            get; set;
        }

        public void ShowInfo(string name)
        {
            DBActions db = new DBActions();
            db.ExecuteStoredProcedureReader("GetDishByName", cmd => cmd.Parameters.AddWithValue("@Name", "%" + name + "%"), 
            reader => 
            {
                if (reader.Read())
                {
                    Name = reader["Name"].ToString();
                    Description = reader["Description"].ToString();
                    Price = (decimal)reader["Price"];
                    Type = reader["Type"].ToString();
                    Availability = (int)reader["Availability"];
                }
                Console.Write($"Dish: {Name}\nDescription: {Description}\nPrice: {Price}\nType: {Type}\nAvailability: {Availability}");
            });
            
        }
        
    }
}