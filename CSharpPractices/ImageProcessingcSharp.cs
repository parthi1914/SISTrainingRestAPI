using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Drawing;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;

namespace CSharpPractices
{
     class ImageProcessingcSharp
    {
        static void Main(string[] args)
        {
            string fpath = @"C:\TestImage\TestImage.PNG";

            byte[] bytes = File.ReadAllBytes(fpath);
            string file = Convert.ToBase64String(bytes);

            Console.WriteLine("Base64 String: " + file);


            


            Console.WriteLine("Press Enter Key to Exit..");


            Console.ReadLine();

        }


        
    }
}
