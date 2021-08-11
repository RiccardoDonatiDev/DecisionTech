using System;

namespace DecisionTechTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Basket basket = new Basket();
            Discount discount = new Discount();

            bool buying = true;
            int milkCount = 0;
            int butterCount = 0;
            int price = 0;
            int breadDiscoutToUse = 0;
            int milkDiscoutToUse = 0;


            int CheckForApplicableOffersForMilk(int itemQuantity)
            {
                if (itemQuantity == 3)
                {
                    milkDiscoutToUse = milkDiscoutToUse + 1;
                    return 0;
                }
                else return itemQuantity;
            }
            int CheckForApplicableOffersForButter(int itemQuantity)
            {
                if (itemQuantity == 2)
                {

                    breadDiscoutToUse = breadDiscoutToUse + 1;
                    return 0;
                }
                else return itemQuantity;
            }

          
            Console.WriteLine("Welcome, please type 1 to increase bread quantity, 2 for milk or 3 for butter. Press 5 to focus your basket or 6 to checkout");

            while (buying)
            {


                milkCount = CheckForApplicableOffersForMilk(milkCount);
                butterCount = CheckForApplicableOffersForButter(butterCount);
                Console.WriteLine($"{milkCount}");
                Console.WriteLine($"{milkDiscoutToUse}");

                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        Console.WriteLine("Added Bread");
                        basket.Bread.Quantity = basket.Bread.Quantity + 1;
                        if (breadDiscoutToUse > 0)
                        {
                            price = price + (basket.Bread.Price / 2);
                            breadDiscoutToUse--;
                            discount.UsedBreadVouchers.Quantity = discount.UsedBreadVouchers.Quantity + 1;
                        }
                        else
                        {
                            price = price + basket.Bread.Price;
                        }
                        break;
                    case "2":
                        Console.WriteLine("Added Milk");
                        basket.Milk.Quantity = basket.Milk.Quantity + 1;

                        if (milkDiscoutToUse > 0)
                        {
                            milkDiscoutToUse = milkDiscoutToUse - 1;
                            discount.UsedMilkVouchers.Quantity = discount.UsedMilkVouchers.Quantity + 1;
                           
                        }
                        else
                        {
                            price = price + basket.Milk.Price;
                        }

                        milkCount = milkCount + 1;

                        break;
                    case "3":
                        Console.WriteLine("Added Butter");
                        basket.Butter.Quantity = basket.Butter.Quantity+ 1;
                        price = price + basket.Butter.Price;
                        butterCount = butterCount + 1;
                        break;
                    case "5":
                        Console.WriteLine($"Current Basket Contains: Bread <{basket.Bread.Quantity.ToString()}>,  Milk <{basket.Milk.Quantity.ToString()}>,  Bread <{basket.Butter.Quantity.ToString()}>");
                        break;
                    case "6":
                        buying = false;
                        break;

                }


                
            }

            Console.WriteLine(price.ToString());

            string stringedPrice = price.ToString();

            string pennyPrice = stringedPrice.Substring(stringedPrice.Length - 2);
            string poundPrice = stringedPrice.Substring(0, stringedPrice.Length - 2);



            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Total Cost is £{poundPrice}.{pennyPrice}");
            Console.ForegroundColor = ConsoleColor.Green;
            if (discount.UsedMilkVouchers.Quantity > 0)
            {
                Console.WriteLine($"The offer 'Buy 3 Milk and geth the 4th Milk free!' was applied {discount.UsedMilkVouchers.Quantity.ToString()} time(s)");

            }
            if (discount.UsedBreadVouchers.Quantity > 0)
            {
                Console.WriteLine($"The offer 'Buy 2 Butter and get a Bread at 50% off' was applied {(discount.UsedBreadVouchers.Quantity - breadDiscoutToUse).ToString()} time(s)");
            }


        }


    }
}

