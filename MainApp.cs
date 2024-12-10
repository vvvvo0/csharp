using System; 

namespace Hello 
{
    class MainApp
    {
        public static void Swap(int a, int b) //swap 메소드 구현
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

            Swap(x, y);

            Console.WriteLine($"x:{x}, y:{y}");
        }
        //a는 x가 가진 것과 똑같은 데이터를 갖고 있지만, a와 x는 완전히 별개의 메모리 공간을 사용함
        //따라서 a를 수정해도 x는 영향을 받지 않음

        //메소드가 매개변수를 받아들일 때는 데이터의 '복사'가 이루어짐
        //메소드를 호출할 때 데이터를 복사해서 매개변수에 넘기는 것을 '값에 의한 전달'이라고 함

    }
}
