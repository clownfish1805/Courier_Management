using System;
using System.Collections.Generic;
using Courier_Management.Models;
using Courier_Management.Dao;
using Courier_Management.Util;
using Courier_Management.Exceptions;
using Microsoft.Data.SqlClient;
using Courier_Management.Main;
using Courier_Management.CodingQues;
using System.Threading.Tasks;


namespace Courier_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1 task1 = new Task1();
            Task2 task2 = new Task2();
            Task3 task3 = new Task3();
            Task4 task4 = new Task4();

            Console.WriteLine("\n--- Task1: Question 1 ---");
            task1.ques1();

            Console.WriteLine("\n--- Task1: Question 2 ---");
            task1.ques2();

            Console.WriteLine("\n--- Task1: Question 3 ---");
            task1.ques3();

            Console.WriteLine("\n--- Task1: Question 4 ---");
            task1.ques4();

            Console.WriteLine("\n--- Task1: Question 5 ---");
            task1.ques5();

            // Task 2
            Console.WriteLine("\n--- Task2: Question 6 ---");
            task2.ques5();

            Console.WriteLine("\n--- Task2: Question 7 ---");
            task2.ques6();

            // Task 3
            Console.WriteLine("\n--- Task3: Question 8 ---");
            task3.ques7();

            Console.WriteLine("\n--- Task3: Question 9 ---");
            task3.ques8();

            // Task 4 (Q9 to Q15)
            Console.WriteLine("\n--- Task4: Questions 9 to 15 ---");
            task4.RunDemo();

            //MainModule menu=new MainModule();
            //menu.Start();
        }
    }
}
