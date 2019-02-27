using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;


namespace RegexChecking
{
    class Program
    {
        static void Main(string[] args)  
        {
            int a= 5 ;
            int A = 10;
            char c = 'l';
            a = 20+3+c;
            float v = 2.0f;
            v += a;
            v = 20+3.0f+c;
            
            //Regex Myreg = new Regex("^([*+/-]{0,1}[0-9]{0,9})*$");
            //DataTable dt = new DataTable();
            //if (Myreg.IsMatch("12*5+4+88"))
            //{
            //    string ans =""+ dt.Compute("12*5+4+88",null);
            Console.WriteLine(Convert.ToUInt32(c));
            //}else
            //{

            //}
            Console.ReadKey();
        }
    }
}
