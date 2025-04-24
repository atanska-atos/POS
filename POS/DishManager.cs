using System;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using POS;


namespace POS
{
    class DishManager
    {
        public void EditDish(string newName, Dish dish)
        {

            try{

                DBActions db = new DBActions();
                db.ExecuteStoredProcedureVoid("UpdateDishByName", cmd => cmd.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("@Name", "%"+dish.Name+"%"),
                        new SqlParameter("@NewName", newName),
                        new SqlParameter("@NewDescription", dish.Description),
                        new SqlParameter("@NewPrice", dish.Price),
                        new SqlParameter("@NewType", dish.Type),
                        new SqlParameter("@NewAvailability", dish.Availability)
                    }));
                Console.WriteLine($"Dish has been added successfully to the Menu.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: \n{ex}");
            }
            
        }

        public void AddDish(Dish dish)
        {

            try
            {
                DBActions db = new DBActions();
                db.ExecuteStoredProcedureVoid("AddDishToMenu", cmd => cmd.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("@Name", dish.Name),
                        new SqlParameter("@Description", dish.Description),
                        new SqlParameter("@Price", dish.Price),
                        new SqlParameter("@Type", dish.Type),
                        new SqlParameter("@Availability", dish.Availability)
                    }));
                Console.WriteLine("Dish has been added successfully to the Menu.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: \n{ex}");
            }
            
        }

        public void RemoveDish(Dish dish)
        {
            try
            {
                DBActions db = new DBActions();
                db.ExecuteStoredProcedureVoid("RemoveDishFromTheMenuByName", cmd => cmd.Parameters.AddWithValue("@Name", dish.Name));

                Console.WriteLine("Dish has been removed successfully from the menu.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot connect to the database correctly. Exception {ex}");
            }
            
        }
    }
}

/*
dodaj danie public void AddDish();

usuń danie public void RemoveDish(string name);

edytuj dane dania (np. dla managera). public void EditDish(string name)*/