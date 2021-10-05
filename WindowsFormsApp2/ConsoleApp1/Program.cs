using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            string result;

            Console.Write("Nhap mot so bat ky trong he thap phan: ");
            answer = Console.ReadLine();

            int num = Convert.ToInt32(answer);
            result = "";
            while (num > 1)
            {
                int remainder = num % 2;
                Console.WriteLine(remainder);
                result = Convert.ToString(remainder) + result;
                Console.WriteLine( "haha" +result); 
                num /= 2;
            }
            result = Convert.ToString(num) + result;
            Console.WriteLine("So trong he nhi phan tuong ung la: {0}", result);

            Console.ReadKey();

        }
    }
}
