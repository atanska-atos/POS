using System;

namespace POS
{
    class Program
    {
        static void Main(string[] args)
        {
            Orders order = new Orders();
            order.Order();
            foreach (string ord in order.orders)
            {
                Console.WriteLine(ord);
            }
        }
    }

}