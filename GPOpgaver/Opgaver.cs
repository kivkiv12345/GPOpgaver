using System;
using System.Collections.Generic;
using System.Linq;

namespace GPOpgaver
{
    public static class Opgaver
    {
        /*
        * Introduktion til Algoritmer
        * Exercise 1. 
        * Describe an algorithm that interchanges the values of the variables x and y, using only assignment statements.
        * What is the minimum number of assignment statements needed to do so?
        */
        public static void Interchange(ref int x, ref int y)
        {
            //Write your solution here

            // My basic solution
            /*
            int temp = x;
            x = y;
            y = temp;
            Console.WriteLine($"{x.ToString()}, {y.ToString()}");
            */

            // Google answer: https://www.tutorialspoint.com/Swap-two-variables-in-one-line-using-Chash
            x = x ^ y ^ (y = x); // I don't really get bitwise operations, but they sure seem cool.

            // Swapping requires a minimum of two assignments.
        }
        /*
        * Introduktion til Algoritmer
        * Exercise 2. 
        * 2.Describe an algorithm that uses only assignment statements to replace thevalues of the triple(x, y, z) with (z, x, y).
        * What is the minimum number of assignment statements needed?
        */
        public static void InterchangeTriple(ref int a, ref int b, ref int c)
        {
            //Write your solution here

            // Probably quite boilerplate, but that's what ya' get when having me write this in (goddamn) C#, rather than Python.
            int[] iarr = { c, a, b };
            a = iarr[0];
            b = iarr[1];
            c = iarr[2];
            // ... I mean; Python would have allowed me to write: "c, a, b = a, b, c", and all sorts of cool stuffs.

            // BTW: I would estimate that this operation requires a minimum of O(n+1) assignments (4; in this case).
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 3.
         * A palindrome is a string that reads the same forward and backward.
         * Describe an algorithm for determining whether a string of n characters is a palindrome.
         */
        public static bool IsPalindrome(string s)
        {
            //Write your solution here

            // Class based solution
            char[] temparr = s.ToCharArray();
            Array.Reverse(temparr);  // Multiple statements are sadly needed as: 'Array.Reverse()' doesn't return a reversed array.
            Console.WriteLine(Enumerable.SequenceEqual(s.ToCharArray(), temparr));

            // Iterative solution
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - i - 1])  // Compare characters at the end and start.
                {
                    return false;
                }
            }
            return true;  // Passing the loop means we are dealing with a palindrome.
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 4.a.
         * List all the steps used to search for 9 in the sequence 1, 3, 4, 5, 6, 8, 9, 11
         * Do this by completing the unit test for 4A
         */
        public static int StepsInLinearSearch(int searchFor, int[] intergerArray)
        {
            //Write your solution here

            // Class based solution
            return intergerArray.ToList().IndexOf(searchFor) + 1; // +1 needed to pass unit tests. ¯\_( ͡° ͜ʖ ͡°)_/¯

            // Iterative solution
            for (int i = 0; i < intergerArray.Length; i++)
            {
                if (intergerArray[i] == searchFor)
                {
                    return i + 1;  // +1 needed to pass unit tests. ¯\_( ͡° ͜ʖ ͡°)_/¯
                }
            }
            return -1; // Element is not present in the array.
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 4.b.
         * List all the steps used to search for 9 in the sequence 1, 3, 4, 5, 6, 8, 9, 11
         * Do this by completing the unit test for 4B
         */
        public static int StepsInBinarySearch(int[] integerArray, int arrayStart, int arrayEnd, int searchFor, int depth=1)
        {
            //Write your solution here

            // Adapted from: https://www.geeksforgeeks.org/binary-search/
            if (arrayEnd >= arrayStart)
            {
                int mid = arrayStart + (arrayEnd - arrayStart) / 2;

                // If the element is present at the middle itself.
                if (integerArray[mid] == searchFor)
                    return depth;

                // If the element is smaller than mid, then it can only be present in the left side of the array.
                if (integerArray[mid] > searchFor)
                    return StepsInBinarySearch(integerArray, arrayStart, mid - 1, searchFor, depth+1);

                // Else the element can only be present in the right side of the array.
                return StepsInBinarySearch(integerArray, mid + 1, arrayEnd, searchFor, depth+1);
            }

            // We reach here; when the element is not present in the array 
            return depth;
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 5.
         * Describe an algorithm based on the linear search for de-termining the correct position in which to insert a new element in an already sorted list.
         */
        public static int InsertSortedList(List<int> sortedList, int insert)
        {
            //Write your solution here

            // Iterate over the list until we find the index to insert our number at.
            for (int i = 0; i < sortedList.Count - 2; i++)
            {
                if (sortedList[i + 1] > insert) // Insert when the next index is larger.
                {
                    sortedList.Insert(i, insert);
                    return i + 1;  // +1 needed to pass unit tests. ¯\_( ͡° ͜ʖ ͡°)_/¯
                }
            }
            sortedList.Add(insert);  // Append to the end when no matches are found.
            return sortedList.Count;
        }
        /*
         * Exercise 6.
         * Arrays
         * Create a function that takes two numbers as arguments (num, length) and returns an array of multiples of num up to length.
         * Notice that num is also included in the returned array.
         */
        public static int[] ArrayOfMultiples(int num, int length)
        {
            //Write your solution here

            int[] temparr = new int[length]; // Create our array using the provided length.

            for (int i = 0; i < length; i++)  // Populate it with multiples.
            {
                temparr[i] = num * (i + 1);
            }
            return temparr;
        }
        /*
         * Exercise 7.
         * Create a function that takes in n, a, b and returns the number of values raised to the nth power that lie in the range [a, b], inclusive.
         * Remember that the range is inclusive. a < b will always be true.
         */
        public static int PowerRanger(int power, int min, int max)
        {
            //Write your solution here
            int counter = 0;

            for (int i = 1; i < max + 1; i++)
            {
                double result = Math.Pow(i, power);
                if (result - 1 > max) // Return the current counter if the power of value is above the max.
                {
                    return counter;
                } else if (result >= min) // Otherwise increment the counter if it is above or equal to our min.
                {
                    counter++;
                }
            }
            return counter; // Returns counter ;)
        }
        /*
         * Exercise 8.
         * Create a Fact method that receives a non-negative integer and returns the factorial of that number.
         * Consider that 0! = 1.
         * You should return a long data type number.
         * https://www.mathsisfun.com/numbers/factorial.html
         */
        public static long Factorial(int n)
        {
            //Write your solution here

            if (n == 0)  // Exclude 0 from the normal operation.
            {
                return 1;
            }

            for (int i = n - 1; i > 1; i--)
            {
                n *= i;
            }
            return n;
        }
        /*
         * Exercise 9.
         * Write a function which increments a string to create a new string.
         * If the string ends with a number, the number should be incremented by 1.
         * If the string doesn't end with a number, 1 should be added to the new string.
         * If the number has leading zeros, the amount of digits should be considered.
         */
        public static string IncrementString(string txt)
        {
            //Write your solution here

            // We create a list to store character representations of the numbers we find.
            List<char> lst = new List<char> {};

            // Search the string for trailing numbers.
            for (int intindex = txt.Length - 1; intindex >= 0; intindex--)
            {
                char i = txt[intindex];
                if (char.IsNumber(i))
                {
                    lst.Insert(0, i);
                } 
                else
                {
                    break;
                }
            }

            // Add 0 to empty lists to prevent exceptions.
            int oldcount = lst.Count();
            if (lst.Count == 0)
            {
                lst.Add('0');
            }

            // Combine the string (excluding found numbers) with a string from the found numbers + 1.
            return txt.Substring(0, txt.Length - oldcount) + (Convert.ToInt32(new string(lst.ToArray())) + 1).ToString();
        }
        /*
         * Exercise 10.
         * Write a more effectiv version of this function.
         */
    }
}