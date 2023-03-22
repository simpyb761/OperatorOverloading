using System;
using static System.Console;

namespace overloadingoperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Cars[] carInventory = new Cars[6];
            carInventory[0]= new Cars("Ferrari 812 Superfast", 350000, 3);
            carInventory[1] = new Cars("Lamborghini Aventador", 400000, 4);
            carInventory[2]  = new Cars("Porsche 911 GTS", 200000, 7);
            carInventory[3] = new Cars("BMW M8 Competition", 150000, 11);
            carInventory[4] = new Cars("Aston Martin DB 11", 250000, 6);
            carInventory[5] = new Cars("Mercedes-Benz SL Roadster", 150000, 12);
            // selling a car
            for(int x=0; x<carInventory.Length; x++) 
            {
                Console.WriteLine($"We had {carInventory[x].CarInventory} {carInventory[x].CarName}'s valued at {carInventory[x].CarPrice}");
                carInventory[x]--;
                Console.WriteLine($"We now have {carInventory[x].CarInventory} {carInventory[x].CarName}'s valued at {carInventory[x].CarPrice}");
                WriteLine();
            }
            // recieving trade-ins
            for (int x = 0; x < carInventory.Length; x++)
            {
                Console.WriteLine($"We had {carInventory[x].CarInventory} {carInventory[x].CarName}'s valued at {carInventory[x].CarPrice}");
                carInventory[x]++;
                Console.WriteLine($"We now have {carInventory[x].CarInventory} {carInventory[x].CarName}'s valued at {carInventory[x].CarPrice}");
                WriteLine();
            }
            // getting enough inventory stock
            for (int x=0; x< carInventory.Length; x++)
            {
                if (carInventory[x] > 300000)
                {
                    WriteLine($"{carInventory[x].CarName} is valued over $300,000. We need 5 in stock!");
                    int orderAmount = 5 - carInventory[x];
                    carInventory[x].CarInventory += orderAmount;
                    WriteLine($"We had to order {orderAmount} of the {carInventory[x].CarName}'s");
                    WriteLine($"We now have {carInventory[x].CarInventory} in stock");
                    WriteLine();


                }
                else if (carInventory[x] < 300000 && carInventory[x] > 199999)
                {
                    WriteLine($"{carInventory[x].CarName} is valued between $200,000 and $300,000. We need 10 in stock!");
                    int orderAmount = 10 - carInventory[x];
                    carInventory[x].CarInventory += orderAmount;
                    WriteLine($"We had to order {orderAmount} of the {carInventory[x].CarName}'s");
                    WriteLine($"We now have {carInventory[x].CarInventory} in stock");
                    WriteLine();

                }
                else
                {
                    WriteLine($"{carInventory[x].CarName} is valued less than $200,000. We need 15 in stock!");
                    int orderAmount = 15 - carInventory[x];
                    carInventory[x].CarInventory += orderAmount;
                    WriteLine($"We had to order {orderAmount} of the {carInventory[x]}'s");
                    WriteLine($"We now have {carInventory[x].CarInventory} in stock");
                    WriteLine();

                }
            }
        }
        
    }
    class Cars
    {
        public string CarName { get; set; }
        public int CarPrice { get; set; }
        public int CarInventory { get; set; }

        public Cars() 
        {
            CarName= string.Empty;
            CarPrice= 0;
            CarInventory= 0;
        }
        public Cars(string carName, int carPrice, int carInventory) 
        {
            CarName= carName;
            CarPrice= carPrice;
            CarInventory= carInventory;
        }
        public static Cars operator +(Cars lhs, int rhs)
        {
            lhs.CarInventory = lhs.CarInventory + rhs;
            return lhs;
        }
        public static Cars operator-(Cars lhs, int rhs)
        {
            lhs.CarInventory = lhs.CarInventory - rhs;
            return lhs;
        }
        public static int operator -(int lhs, Cars rhs)
        {
            int result = lhs - rhs.CarInventory;
            return result;
        }
        public static bool operator <(Cars lhs, int rhs)
        {
            bool inventoryCheck = false;
            if(lhs.CarPrice < rhs)
            {
                inventoryCheck= true;
            }
            return inventoryCheck;
        }
        public static bool operator > (Cars lhs, int rhs)
        {
            bool inventoryCheck = false;
            if (lhs.CarPrice > rhs)
            {
                inventoryCheck= true;
            }
            return inventoryCheck;
        }
        public static Cars operator ++(Cars c)
        {
            c.CarInventory++;
            return c;
        }
        public static Cars operator --(Cars c) 
        { 
            c.CarInventory--;
            return c;
        }
    }

}