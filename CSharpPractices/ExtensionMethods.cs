using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractices
{
     class ExtensionMethods
    {
        //static void Main(string[] args)

        //{
        //    string input = "100";
        //    input.IntegerExtension(input);
        //}
     }


    public static class ExtMetClass
    {
        public static int IntegerExtension(this string str,string input)
        {
            return Int32.Parse(str);
        }
    }

}
