using System;
using System.Collections.Generic;
using System.Globalization;

namespace POS
{
    class Orders
    {
        public List<string> orders = new List<string>();
        
        
        
        
        public void Order()
        {
            Console.WriteLine("Shall we start with an appetizer? yes/no");
            string ans = "";
            while (ans == "")
            {
                ans = Console.ReadLine()!;
                if (ans.ToLower() == "yes")
                {
                    ChooseMeal("appetizer");
                }
                else if (ans.ToLower() == "no")
                {
                    break;
                }
                else
                {
                    ans = "";
                    Console.WriteLine("Could you provide the answer again if you want to add an appetizer?");
                }
            }
            

        }

        private void ChooseMeal(string dishType)
        {
            
            

            switch (dishType)
            {
                case "appetizer":
                    Console.WriteLine("Choose appetizer:");
                    ChooseMealMethod("appetizers.txt");
                    break;
                    
                    
            }
        }

        private List<string> ChooseMealMethod(string filePath)
        {
            
            List<string> dishes = DishListSet(filePath);
            bool addNext = true;

            while (addNext)
            {
                Console.WriteLine("\nWhat would you like to add?");
                string dish = Console.ReadLine()!;
                if (dish == "")
                {
                    break;
                }
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                dish = ti.ToTitleCase(dish.ToLower());
                if (dishes.Contains(dish))
                {
                    orders.Add(dish);
                }
                else
                {
                    Console.WriteLine("There is no such item on the list.");
                }
                
            }
            return dishes;
        }

        private static List<string> DishListSet(string filePath)
        {
            List<string> dishes = new List<string>();
            foreach(string line in File.ReadLines(filePath))
            {
                dishes.Add(line);
                Console.WriteLine(line);
            }
            return dishes;
        }
    }
}