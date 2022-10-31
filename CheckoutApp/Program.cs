using CheckoutApp_CL.BL;
using CheckoutApp_CL.DAL;
using System;

namespace CheckoutApp
{
    internal class Program
    {
        const int END_SELECTION = -1;
        static void Main(string[] args)
        {
            Execute();

            Console.ReadLine();
        }

        private static void Execute()
        {
            var bl = new InventoryBL(new InventoryDAL());
            while (true)
            {
                Console.WriteLine("Menu: ");

                foreach (var item in bl.Items)
                {
                        Console.WriteLine($"{item.InventoryItemId}. {item.Description} - ${item.Price}");
                }

                Console.WriteLine("Please enter selection to add to basket or enter -1 to checkout");
                var selection = int.Parse(Console.ReadLine());

                if(selection == END_SELECTION)
                    break;

                bl.AddToBasket(selection);
            }
            
            var totalPrice = bl.CheckoutItems();
            Console.WriteLine($"Order has been placed. Cost of total items: ${totalPrice}");
        }
    }
}
