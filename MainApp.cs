using System; 

namespace Hello 
{
    class MainApp
    {
        public static void Swap(ref int a, ref int b) //ref 키워드를 매개변수 앞에 붙여줌
        {
            int temp = b;
            b = a;
            a = temp;
        }

       
        static void Main(string[] args)
        {
            int x = 3;
            int y = 4;

            Console.WriteLine($"x:{x}, y:{y}");

            Swap(ref x, ref y); //메소드를 호출할 때 다시 ref 키워드를 붙여줌

            Console.WriteLine($"x:{x}, y:{y}");
        }
    }
}
