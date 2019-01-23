using System;

namespace modularization
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] product = {
                                    {"Snickers", "Almond Joy", "Reeses"},
                                    {"Skittles", "Starburst", "Jolly Ranchers"},
                                    {"Juicy Fruit", "Winter Fresh", "Big Red"}
                                };

            double[,] cost = {
                                {1.80, 1.50, 1.45},
                                {1.30, 1.45, 1.20},
                                {1.10, 1.15, 1.10}
                            };
            ConsoleKey sentinel;  //Global
            double priceAccum = 0;
            int row, column; //Global
            greeting();
            sentinel = getPrimer(); //Calling or involking
            while (sentinel != ConsoleKey.X)
            {
                //clear console
                Console.Clear();
                //Create a Module to display products
                outputTable(product);  //Calling or involking the method
                //Create a Module
                row = getRow();


                //Create a module that defensively program
                checkRange(ref row);

                //Create a Module to get column
                column = getColumn();

                //Create a module that defensively program
                checkRange(ref column);

                //Create a module that output selection and accumulates the price
                accumPrice(product, cost, ref priceAccum, row, column);

                //module that ask for priming value
                sentinel = getPrimer();

            }

            //Create a module that will output total
            outputPrice(priceAccum); 

        }//End of main

        static void greeting()
        {
            Console.WriteLine("Welcome, to simple Vending Machine");
        }

        //Defining the welcome module that will accept user input and return a Key
        static ConsoleKey getPrimer()
        {
            ConsoleKey sentinel; //Local
            
            Console.WriteLine("Press any key to add a product or press the 'X' key to exit the vending machine and receive total");
            return sentinel = Console.ReadKey(true).Key;
        }

        static void outputTable(string[ , ] prod)
        {
            Console.WriteLine($"\t 0 \t\t 1  \t\t 2");
            for (var i = 0; i < prod.GetLength(0); i++)
            {
                Console.Write($"{i} \t");
                for (var x = 0; x < prod.GetLength(1); x++)
                {
                    Console.Write($"{prod[i, x]} \t");
                }
                Console.WriteLine("");
            }
        }

        static int getRow()
        {
            int row; //Local
            Console.WriteLine("Please enter the row of the product you would like to enter");
            return row = Convert.ToInt32(Console.ReadLine());
        }

        static int getColumn()
        {
            int column; //Local
            Console.WriteLine("Please enter the column of the product you would like to enter");
            return column = Convert.ToInt32(Console.ReadLine());
        }
        //Method that defensively programs to enforce a particular range of numbers
        static void checkRange(ref int num)
        {
            while ((num < 0) || (num > 2))
            {
                Console.WriteLine("Invalid entry, please enter a number between 0 and 2");
                num = Convert.ToInt32(Console.ReadLine());
            }
            
           
        }

        static void accumPrice(string [ , ] prod, double [ , ] price, ref double accum, int row, int column)
        {
           Console.WriteLine($"You have selected {prod[row, column]} for {price[row, column].ToString("c")}");
           accum += price[row, column];
        }

        static void outputPrice(double totalPrice)
        {
            Console.WriteLine("Based on your selections, you owe {0}", totalPrice.ToString("c"));
        }
    }
}
