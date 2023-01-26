using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace ArrayDataStruct
{
    public class LinearArrayList
    {

        // ATTRIBUTES

        /*
         * Array to hold the values entered
         */

        public int[] values;


        /*
         * how many numbers currently stored
         */
        public int count;


        //METHODS

        /*
         * Empty(default) constructor.Sets count = 0 and values = 10
         */
        public LinearArrayList()
        {
            count = 0;
            values = new int[10];
        }

        /*
         * Empty(default) constructor.Sets count = 0 and values = size
         */  
        public LinearArrayList(int size)
        {
            count = 0;
            values = new int[size];
        }


        /*
         * Displays current contents of values to the standard output
         */
        public void displayUI()
        {
            foreach (var entry in values)
            {
                Console.WriteLine(entry);
            }

        }

        /*
         * Removes all contents from values
         */
        public void destroy()
        {
            Array.Clear(values, 0, values.Length);
        }

        /* 
         * Checks if values is empty (filled with 0s)
         * returns true if empty otherwise false
         */
        public bool isEmpty()
        {

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != 0)
                {
                    Console.WriteLine("Array is not empty.");
                    return false;
                }
            }
            Console.WriteLine("Array is empty.");
            return true;
        }
        /* 
         * Checks if values is full, returns true if full otherwise false
         */
        public bool isFull()
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == 0)
                {
                    Console.WriteLine("Array is not full.");
                    return false;
                }
            }
            Console.WriteLine("Array is full.");
            return true;
        }

        /*
         * Adds value at the first position of values.
         * The existing entries will move up (ie current index +1).	
         * Throws an exception if list is full
        */

        public void addFirst(int value)
        {
            if (isFull())
            {
                throw new Exception("Array is full. Cannot add value.");
            }
            for (int i = count; i > 0; i--)
            {
                values[i] = values[i - 1];
            }
            values[0] = value;
            count++;
        }


        /* Adds value after the last current value. 
         * Throws an exception if list is full
         */

        public void addLast(int value)
        { 
    if (count == values.Length)
    {
        throw new Exception("List is full, cannot add new value.");
    }
    else
    {
        values[count] = value;
        count++;
    }
                }
        /* Removes the value at the first position and returns it.
         * The remaining entries will move down (ie current index -1).
         * Throws an exception if the list is empty */


        public int removeFirst()
        {
            if (values.Length == 0)
            {
                throw new Exception("The array is empty");
            }
            int first = values[0];
            for (int i = 0; i < values.Length - 1; i++)
            {
                values[i] = values[i + 1];
            }
            Array.Resize(ref values, values.Length - 1);
            return first;


        }
        /* Removes the last stored value and returns it.
         * Throws an exception if the list is empty.*/

        public int removeLast()
        {
            if (isFull())
            {
                throw new Exception("The list is empty. Cannot remove last element.");
            }

            int lastValue = values[count - 1];
            values[count - 1] = 0;
            count--;
            return lastValue;
        }


        public void add(int value)
        {
            values[count] = value;
            count++; 
        }
        /*
         * Use a linear search algorithm
        Returns the index of the first match
        If no match is found then -1 is returned
        */

        public int search(int value)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                {
                    Console.WriteLine("Value found at index: " + i);
                    return i;
                }
            }
            Console.WriteLine("Value not found in the array.");
            return -1;
        }

        /*
         * Use a selection sort algorithm
         */

        public void sort()
        {
            int n = values.Length;

            
            for (int i = 0; i < n - 1; i++)
            {
                
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (values[j] < values[min_idx])
                        min_idx = j;

               
                int temp = values[min_idx];
                values[min_idx] = values[i];
                values[i] = temp;
            }
        }
    }
}
