using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDelegates
{
    public delegate string MathDelegate(int arg1, int arg2);

    public delegate string AnonymousDelegate(int args1, int args2);

    public class InstanceClass
    {
        public string instanceMethod(int arg1, int arg2) => ((arg1 + arg2) * arg1).ToString();
    }
    internal class BasicDelegates
    {
        static string func1(int args1, int args2) => (args1 + args2).ToString();

        static string func2(int args1, int args2) => (args1 * args2).ToString();

        static void Main(string[] args)
        {
            MathDelegate func = func1;

            Console.WriteLine("The Number is" + func(10,20));

            func = func2;
            Console.WriteLine("The Number is" + func(10,20));

            InstanceClass inc = new InstanceClass();
            func = inc.instanceMethod;
            Console.WriteLine("The number is:" + func(10,20));

            //Anonymous delegates
            AnonymousDelegate ad = delegate(int args1, int args2)
            {
                return (args1 + args2).ToString();
            };
            Console.WriteLine("The Number is:" + func(10,20));
        }
    }
}