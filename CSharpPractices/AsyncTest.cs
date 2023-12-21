using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
     class AsyncTest
    {

        //static void Main(string[] args)
        //{

        //    Test1();
        //    Test2();
        //    Test3();
        //}


        public static async Task Test1()
        {

            Thread.Sleep(8000);
            Console.WriteLine("Test1 Running");
           
        }


        public static async Task Test2()
        {

            Thread.Sleep(3000);
            Console.WriteLine("Test2 Running");

        }

        public static async Task Test3()
        {

            Thread.Sleep(1000);
            Console.WriteLine("Test3 Running");

        }
    }



}
