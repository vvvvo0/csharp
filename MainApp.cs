using System; 

namespace Hello 
{
    class Mainapp
    {
        static int Sum(params int[] args) // 가변 개수의 인수는 params 키워드와 배열을 이용해서 선언
        {
            Console.Write("Summing... ");

            int sum = 0;

            for (int i = 0; i < args.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");

                Console.Write(args[i]);

                sum += args[i];
            }
            Console.WriteLine();

            return sum;
        }

        static void Main(string[] args)
        {
            int sum = Sum(3, 4, 5, 6, 7, 8, 9, 10);

            Console.WriteLine("Sum : {0}", sum);
        }
    }
}

// 형식은 같으나 인수의 개수만 유연하게 달라지는 경우 적합.
