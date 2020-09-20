using System;
using System.Threading;

namespace Assignment1_Fall20
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question #1
            //This code reads in the input that is to be placed in the function.
            int n;
            Console.Write("Enter number of rows\n");
            n = int.Parse(Console.ReadLine());
            // This code runs the function with the input recieved from the user. 
            PrintTriangle(n);

            // Question # 2
            //This code reads in the input that is to be placed in the function.
            int n2;
            Console.Write("Enter number for the sequence: ");
            n2 = int.Parse(Console.ReadLine());
            // This code runs the function with the input recieved from the user. 
            PrintSeriesSum(n2);


            // Question #3
            // This code runs the program and displays whether the array is monotonic or not.
            int[] A = new int[] { 1, 2, 2, 6 }; 
            bool check = MonotonicCheck(A);
            Console.WriteLine(check);

            // Question # 4
            // The next step in this proces is to learn how to read in values and convert them to an array from the user.
            // This code below calls the function for the specified array and calvulates the difference then writes it on the screen.
            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int k = 2;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine(pairs);



            // Question # 5
            // This code declares the keyboard and word as strings, then it runs the function BullsKeyboard() to calculate the time it 
            // would take to write the specific word on the keyboard. 
            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "dis";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine($"The time taken to type the given word is :\t{time} ");

            //Question # 6
            // This code reads in the string values as well as the length of each string that we are trying to compare and match.
            // The code then runs the method on the two strings. 
            string str1 = "goulls";
            string str2 = "gobulls";
            int m = str1.Length;
            int s = str2.Length;
            int minEdits = StringEdit(str1, str2, m, s);
            Console.WriteLine(minEdits);

        }

        // Question # 1
        public static void PrintTriangle(int x)
        {
            //This is the main body of the method. It is wrapped in a try block to gracefully deal with all errors.
           try
            {
                // The method begins by declaring all variables that are used. Note the the input variable x is declard above.
                int i, k, count = 1;
                count = x - 1;
                // This for loop is used to keep a count and pass over the printing of the stars. Note that is is a nested for loop.
                for (k = 1; k <= x; k++)
                {
                    for (i = 1; i <= count; i++)
                        Console.Write(" ");
                    count--;
                    for (i = 1; i <= 2 * k - 1; i++)
                        Console.Write("*");
                    Console.WriteLine();
                }

            }
            // Catch block which gracefully deals with any error in the code. 
            catch
            {
                Console.WriteLine(" Please try running the function again. Ensure that you enter integer for number of rows!");
            }
         }

        // Question # 2

            public static void PrintSeriesSum(int n)
        {
            // This is the main body of the method. It is wrapped in a try block to gracefully deal with all errors.
            try
            {
                // The method begins by declaring all variables, Note the inout variable is declared above in the method declaration.
                int i, sum = 0;
                
                // This part of the method calculates the odd numbers and adds them up. Note that a for loop is used. 
                Console.Write("\nThe odd numbers are :");
                for (i = 1; i <= n; i++)
                {
                    Console.Write("{0} ", 2 * i - 1);
                    sum += 2 * i - 1;
                }
                Console.Write("\nThe Sum of odd Natural Number upto {0} terms are : {1} \n", n, sum);
            }
            catch
            {
                // The catch block deals with all errors gracefully.
                Console.WriteLine("Error occured while trying to process odd numbers and sum. Please ensure you are entering an integer!");
            }
        }

        //Question #3
        // Method definition is given below. 
        public static bool MonotonicCheck(int[] n)
        {
            try
            {
                // simple "for" loop to determine if the array is monotonic. 
                for (int i = 0; i < n.Length - 1;)
                {
                    i++;
                    if (n[i] <= n[i + 1])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                
            }
            catch
            {
                // Catch block to handle errors gracefully 
                Console.WriteLine("There was an error in processing the program. As a result we could not determine if the array is Monotonic");
            }

            return false;
        }

        // Question # 4
        // The method below calculates teh difference for the given array. Each steps is commented to signify what the program is doing!
        public static int DiffPairs(int[] J, int k)
        {
            try
            {
                int count = 0;

                // Pick all elements one by one 
                for (int i = 0; i < J.Length; i++)
                {

                    // See if there is a pair of this picked element 

                    for (int z = i + 1; z < J.Length; z++)
                        if (J[i] - J[z] == k ||
                              J[z] - J[i] == k)
                            count++;
                }
                return count;
            }
            catch
            {
                // The catch block handles all errors gracefully and returns a message along with zero if any error is found.
                Console.WriteLine("There was an error hence we were not able to calculate a difference!");
                
            }
            return 0;


        }

        // Question # 5
        // The method definition is given below. It takes two arguments of type string, namely, keyboard and word
        public static int BullsKeyboard(string keyboard, string word)
        {
            try
            {
                // The try block is to set run the main area of the code. If something happens the error will be captured in the catch block
                // This part of the takes the input string and converst them to arrays. A new array is intialized, then a for loop writes the values
                // to the array. 
                char[] keys = keyboard.ToCharArray();
                int[] countArray = new int[26];
                for (int i = 0; i < countArray.Length; i++)
                {
                    countArray[keys[i] - 'a'] = i;
                }

                int result = 0, position = 0;
                char[] keysword = word.ToCharArray();
                for (int i = 0; i < keysword.Length; i++)
                {
                    // This part of the method calulates the time it takes to write the word on the keyboard and then return the result!
                    result = result + Math.Abs(countArray[keysword[i] - 'a'] - position);
                    position = countArray[keysword[i] - 'a'];
                }
                return result;
            }
            catch
            {
                // Catch block which handles all errors gracefully. 
                Console.WriteLine("Error occured while trying to run the program. Please ensure that all input values are of type string!");
            }

            return 0;
        }

        // Question # 6

        public static int StringEdit(string str1, string str2, int m, int s)
        {
            try
            {
                
                // Option one is an empty string where we insert all char of second string into first.
                if (m == 0)
                    return s;

                
                // Option two is another empty string however this time we will remove all char of first string so it matches second 
                if (s == 0)
                    return m;

                
                // Last two char the same so we just ignore them and get count for the rest of the string.
                if (str1[m - 1] == str2[s - 1])
                    return StringEdit(str1, str2, m - 1, s - 1);

                
                // Last char of the string are not the same so we just calculate the minimum cost for all three choices and take min. 
                // This is done recursively 
                int smallest = Math.Min(StringEdit(str1, str2, m, s - 1), Math.Min(StringEdit(str1, str2, m - 1, s), StringEdit(str1, str2, m - 1, s - 1)));
                return 1 + smallest;
            }
            catch
            {
                // Catch block to handle all errors gracefully.
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
    }

}


