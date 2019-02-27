using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static double sum = 0,num1=0,num2=0;
        public static bool Flag = true;
        static void Main(string[] args)
        {
            string r = null;
            Stack<string> verse = new Stack<string>();
            Stack<double> num = new Stack<double>();
            Stack<string> reverse = new Stack<string>();
            string res = "5*7-6/2*4+7";//5*7-6/2*4+7"//'7-6/9'//'13*9*9+10/4*9'//'13+13+13/2-9+18'
            List<string> lst = new List<string>();
            char[] arr = res.ToCharArray();
            for (int i = 0; i < arr.Count(); i++)
            {
                if (arr[i] == '1' || arr[i] == '2' || arr[i] == '3' || arr[i] == '4' || arr[i] == '5' || arr[i] == '6' || arr[i] == '7' || arr[i] == '8' || arr[i] == '9')
                {
                    r += arr[i];
                }
                else if (arr[i] == '+' || arr[i] == '-' || arr[i] == '*' || arr[i] == '/')
                {
                    lst.Add(r);
                    lst.Add(arr[i].ToString());
                    r = null;
                }

            }
            lst.Add(r);
            r = null;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] == "*")
                {
                    if (verse.Count == 0)
                    {
                        verse.Push(lst[i]);
                    }
                    else
                    {
                        if (verse.Peek().Equals("*"))
                        {
                            verse.Pop();
                             num1 = num.Pop();
                            num2 = num.Pop();
                            sum = num2 * num1;
                            num.Push(sum);
                            verse.Push(lst[i]);
                        }else
                        {
                            verse.Push(lst[i]);
                        }
                        
                    }
                }
                else if (lst[i] == "+")
                {
                    if (verse.Count == 0)
                    {
                        verse.Push(lst[i]);
                    }
                    else
                    {
                        if (verse.Peek().Equals("*"))
                        {
                            verse.Pop();
                             num1 = num.Pop();
                            num2 = num.Pop();
                            sum = num2 * num1;
                            num.Push(sum);
                            verse.Push(lst[i]);
                        }
                        else if(verse.Peek().Equals("+"))
                        {
                            verse.Pop();
                             num1 = num.Pop();
                             num2 = num.Pop();
                            sum = num2 + num1;
                            num.Push(sum);
                            verse.Push(lst[i]);
                        }
                        else
                        {
                            verse.Push(lst[i]);
                        }
                        
                    }

                }
                else if (lst[i] == "/")
                {
                    if (verse.Count == 0)
                    {
                        verse.Push(lst[i]);
                    }
                    else
                    {
                        if (verse.Peek().Equals("*"))
                        {
                            verse.Pop();
                             num1 = num.Pop();
                             num2 = num.Pop();
                            sum = num2 * num1;
                            num.Push(sum);
                            verse.Push(lst[i]);
                        }
                        else if (verse.Peek().Equals("+"))
                        {
                            verse.Pop();
                            num1 = num.Pop();
                            num2 = num.Pop();
                            sum = num2 + num1;
                            num.Push(sum);
                            verse.Push(lst[i]);
                        }
                        else if (verse.Peek().Equals("/"))
                        {
                            verse.Pop();
                             num1 = num.Pop();
                             num2 = num.Pop();
                            sum = num2 / num1;
                            num.Push(sum);
                            verse.Push(lst[i]);
                        }
                        else 
                        {
                          
                            verse.Push(lst[i]);
                        }
                        
                    }
                }
                else if (lst[i] == "-")
                {
                    if (verse.Count == 0)
                    {
                        verse.Push(lst[i]);
                    }
                    else
                    {
                        if (verse.Peek().Equals("*"))
                        {
                            verse.Pop();
                             num1 = num.Pop();
                            num2 = num.Pop();
                            sum = num2 * num1;
                            num.Push(sum);
                            verse.Push(lst[i]);
                        }
                        else if (verse.Peek().Equals("+"))
                        {
                            verse.Pop();
                             num1 = num.Pop();
                             num2 = num.Pop();
                            sum = num2 + num1;
                            num.Push(sum);
                            verse.Push(lst[i]);
                        }
                        else if (verse.Peek().Equals("/"))
                        {
                            verse.Pop();
                            num1 = num.Pop();
                            num2 = num.Pop();
                            sum = num2 / num1;
                            num.Push(sum);
                            verse.Push(lst[i]);
                        }
                        else if(verse.Peek().Equals("-"))
                        {
                            verse.Pop();
                             num1 = num.Pop();
                             num2 = num.Pop();
                            sum = num2 - num1;
                            num.Push(sum);
                            verse.Push(lst[i]);
                        }else
                        {
                            verse.Push(lst[i]);
                        }
                    }
                }
                else if (int.Parse(lst[i].ToString()) > 0)
                {
                    num.Push(int.Parse(lst[i].ToString()));
                }
                else
                {
                    //error
                }
            }
            while (Flag == true)
            {
                if (verse.Count != 0)
                {
                    if (verse.Peek().Equals("*"))
                    {

                        num1 = num.Pop();
                         num2 = num.Pop();
                        sum = num2 * num1;
                        num.Push(sum);
                        verse.Pop();
                    }
                    else
                if (verse.Peek().Equals("+") )
                    {
                         num1 = num.Pop();
                         num2 = num.Pop();
                        sum = num2 + num1;
                        num.Push(sum);
                        verse.Pop();
                    }
                    else if (verse.Peek().Equals("/") )
                    {
                         num1 = num.Pop();
                         num2 = num.Pop();
                        sum = num2 / num1;
                        num.Push(sum);
                        verse.Pop();
                    }
                    else if (verse.Peek().Equals("-") )
                    {
                         num1 = num.Pop();
                        num2 = num.Pop();
                        sum = num2 - num1;
                        num.Push(sum);
                        verse.Pop();
                    }

                }
                else
                {
                    Flag = false;
                }
            }
                Console.WriteLine("your result " + sum);
            Console.ReadKey();
        }
    }
}
