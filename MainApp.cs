using System; //네임스페이스 전체를 사용한다. System.Console.WriteLine() -> Console.WriteLine()
using static System.Console;

namespace Hello //비슷한 것들끼리 하나의 이름 아래 묶음.
{
    class MainApp /* MainApp이라는 클래스(c#프로그램을 구성하는 기본단위)를 만듦.
                     클래스: 데이터와 데이터를 처리하는 기능(메소드)으로 구성됨.*/
    {
        static void Main(string[] args) //Main() 메소드. c의 Main함수랑 비슷.
         //static은 한정자. 메소드나 변수 등을 수식.
         // static 키워드로 수식되는 코드는 프로그램이 처음 구동될 때부터 메모리에 할당된다. 
        {

            int a = 111 + 222;
            Console.WriteLine($"a:{a}");

            int b = a - 100;
            Console.WriteLine($"b:{b}");

            int c = b * 10;
            Console.WriteLine($"c:{c}");

            double d = c / 6.3;
            Console.WriteLine($"d: {d}");

            Console.WriteLine($"22/7 = {22 / 7}({22 % 7})");
            
        }
    }
}
