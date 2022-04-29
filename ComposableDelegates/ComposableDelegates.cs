using System;

namespace ComposableDelegates
{

    public delegate void MyComposableDelegate(int args1, int args2);

    class ComposableDelegates
    {
        static void func1(int args1, int args2)
        {
            string result = (args1 + args2).ToString();
            Console.WriteLine("The number from func1 is:" + result);
        }

        static void func2(int args1 , int args2)
        {
            string result = (args1 * args2).ToString();
            Console.WriteLine("The number free from func2 is:" + result);
        }
    
        static void Main_CD(string[] args)
        {
            MyComposableDelegate cd1 = func1;
            MyComposableDelegate cd2 = func2;

            MyComposableDelegate cd1cd2 = cd1 + cd2;

            int a = 10;
            int b = 20;

            Console.WriteLine("Calling the first delegate");
            cd1(a, b);
            Console.WriteLine("Calling the second delegate");
            cd2(a, b);
            // Call the composed delegate
            Console.WriteLine("\nCalling the chained delegates");
            cd1cd2(a, b);

            // subtract off one of the delegates
            Console.WriteLine("\nCalling the unchained delegates");
            cd1cd2 -= cd1;
            cd1cd2(a, b);

        }
    }
}
