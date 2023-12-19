using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
     class ExtensionUserdefined
    {
        //static void Main(string[] args)

        //{
        //    Geek geek = new Geek();

        //    geek.M1();
        //    geek.M2();
        //    geek.M3();
        //    geek.M4();
        //    geek.M5("this");

        //}

        }


    class Geek
    {

        // Method 1 
        public void M1()
        {
            Console.WriteLine("Method Name: M1");
        }

        // Method 2 
        public void M2()
        {
            Console.WriteLine("Method Name: M2");
        }

        // Method 3 
        public void M3()
        {
            Console.WriteLine("Method Name: M3");
        }

    }

    static class NewMethodClass
    {

        // Method 4 
        public static void M4(this Geek g)
        {
            Console.WriteLine("Method Name: M4");
        }

        // Method 5 
        public static void M5(this Geek g, string str)
        {
            Console.WriteLine(str);
        }
    }

}

