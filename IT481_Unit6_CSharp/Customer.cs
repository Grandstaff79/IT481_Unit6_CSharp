using System;
using System.Collections.Generic;
using System.Text;

namespace IT481_Unit6_CSharp
{
    class Customer
    {

        int NumberOfItems;

        public Customer()
        {
            NumberOfItems = 6;
        }

        public Customer(int items)
        {

            int ClothingItems = items;
            if (ClothingItems == 0)
            {
                NumberOfItems = GetRandomNumber(1, 20);
            }
            else
            {
                NumberOfItems = ClothingItems;
            }
        }

        //Return number of items

        public int getNumberOfItems()
        {
            return NumberOfItems;
        }


        //Return number methods
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return getrandom.Next(min, max);
            }
        }

        
        
            
        }
    }

