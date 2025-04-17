using System;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;


namespace POS
{
    class DishManager
    {
        private string _connectionString;

                public DishManager()
        {
            _connectionString = File.ReadAllText("config.txt");
        }
        

        public void EditDish(string name, string newName, string description, decimal price, string type, int availability)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UpdateDishByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@Name", "%"+name+"%"),
                    new SqlParameter("@NewName", newName),
                    new SqlParameter("@NewDescription", description),
                    new SqlParameter("@NewPrice", price),
                    new SqlParameter("@NewType", type),
                    new SqlParameter("@NewAvailability", availability)
                });

                cmd.ExecuteReader();
            }
            
            Console.Write("Dish has been updated successfully.");

        }
    }
}

/*
dodaj danie public void AddDish();

usuń danie public void RemoveDish(string name);

edytuj dane dania (np. dla managera). public void EditDish(string name)*/