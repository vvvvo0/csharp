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
        //매개변수가 메소드에 넘겨진 원본 변수를 직접 참조함
        //따라서 메소드 안에서 매개변수를 수정하면 매개변수가 참조하고 있는 원본 변수에 수정이 이루어짐
    }
}
