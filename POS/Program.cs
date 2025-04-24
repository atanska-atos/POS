using System;

namespace POS
{
    class Program
    {
        static void Main(string[] args)
        {
            Dish dish1 = new Dish{
                Name = "Cedar-Plank Salmon",
                Description = "Fish",
                Price = 46.70m,
                Type = "Main course",
                Availability = 1
            };
            
            //dish1.ShowInfo("Buffalo Cauliflower Wings");

            //DishManager dishMan1 = new DishManager();
            //dishMan1.EditDish("Buffalo Cauliflower Wings","Buffalo Cauliflower Wings","Mild",23.40m,"Appetizer",1);


            //dishMan1.AddDish(dish1);
            //dishMan1.RemoveDish("Cedar-Plank Salmon");

            Employees emp1 = new Employees{
                Name = "Katie",
                Surname = "Miller",
                HireDate = DateTime.Now,
                Username = "kmiller"
            };

            EmployeeManager empMan = new EmployeeManager();
            empMan.AddEmployee(emp1);


        }
    }

}