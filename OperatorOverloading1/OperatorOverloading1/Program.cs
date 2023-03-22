using System;

namespace OperatorOverloadingEx1
{
    public class Calculator
    {
        public int number { get; set; }

        // Overload unary operators ++ and -- 
        // Code goes here
        public static Calculator operator ++(Calculator c)
        {
            c.number++;
            return c;
        }
        public static Calculator operator--(Calculator c)
        {
            c.number--;
            return c;
        }

        // Overload Comparison Operators > and <
        // Code goes here
        public static bool operator >(Calculator lhs , Calculator rhs)
        {
            bool sizeCheck = false;
            if(lhs.number > rhs.number)
            {
                sizeCheck = true;
            }
            return sizeCheck;
        }
        public static bool operator < (Calculator lhs , Calculator rhs)
        {
            bool sizeCheck = false;
            if(lhs.number < rhs.number)
            {
                sizeCheck = true;
            }
            return sizeCheck;
        }

        // Overload Binary Operators + and -
        // Code goes here
        public static Calculator operator +(Calculator lhs , Calculator rhs)
        {
             lhs.number = lhs.number + rhs.number;
             return lhs;
        }
        public static Calculator operator -(Calculator lhs , Calculator rhs)
        {
            lhs.number = lhs.number - rhs.number; return lhs;
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            // create object array
            Calculator[] numbers = new Calculator[10];
            // place random numbers into array and print values
            Console.Write("Original Numbers= ");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = new Calculator(); // creates the object
                numbers[i].number = r.Next(1, 100);  // places a value in the object
                Console.Write(" " + numbers[i].number);
            }
            Console.WriteLine();
            // if divisible by 2, add 1 to value using operator ++ method
            // otherwise subtract 1 from value using operator -- method
            Console.Write("New Numbers +1 or -1= ");
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].number % 2 == 0)
                {
                    numbers[i]++;
                }
                else
                {
                    numbers[i]--;
                }
                Console.Write(" " + numbers[i].number);
            }
            Console.WriteLine();

            // random Calculator object to add
            Calculator numToAdd = new Calculator();
            numToAdd.number = r.Next(1, 20);
            // Using operator +, add numToAdd.number to each element in the array
            // Print the results
            Console.Write($"Numbers + {numToAdd.number} = ");

            for(int x= 0; x < numbers.Length;x++)
            {
                var result = numbers[x] + numToAdd;
                Console.Write(" "+ result.number);
            }

            Console.WriteLine();

            // random Calculator object to subtract
            Calculator numToSub = new Calculator();
            numToSub.number = r.Next(1, 20);
            // Using operator -, subtract numToSub.number from each element in the array
            // Print the results
            Console.Write($"Numbers - {numToSub.number}= ");

            for(int x=0; x < numbers.Length;x++) 
            { 
                var result = numbers[x]-numToSub;
                Console.Write(" "+result.number);
            }

            Console.WriteLine();

            // random Calculator object for comparison
            Calculator numToCompare = new Calculator();
            numToCompare.number = r.Next(1, 100);
            // Using operator > and operator <, compare each element to numToCompare.number
            // print if the element is higher, lower or equal to the number you are comparing to
            Console.WriteLine($"Numbers above or below {numToCompare.number}");

            for(int x = 0; x < numbers.Length; x++)
            {
                if (numbers[x] < numToCompare)
                    Console.WriteLine($"{numbers[x].number} is lower.");
                else
                    Console.WriteLine($"{numbers[x].number} is higher.");
            }
        }
    }
}