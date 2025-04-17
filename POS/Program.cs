using System;

namespace POS
{
    class Program
    {
        static void Main(string[] args)
        {
            Dish dish1 = new Dish();
            dish1.ShowInfo("Buffalo Cauliflower Wings");

            DishManager dishMan1 = new DishManager();
            dishMan1.EditDish("Buffalo Cauliflower Wings","Buffalo Cauliflower Wings","Mild",23.40m,"Appetizer",1);

            
        }
    }

}