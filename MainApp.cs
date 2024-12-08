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
            object obj = null;

            string s = Console.ReadLine(); //문자열 입력 받음
            if (int.TryParse(s, out int out_i)) //Tryparse는 Parse와 같은 기능(문자열을 숫자로 변환).
                                                //out 키워드는 출력 전용 매개변수임을 나타내는 용도로 쓰임
                obj = out_i; 
            else if (int.TryParse(s, out int out_f))
                obj = out_f;
            else
                obj = s;

            switch(obj) //박싱된 데이터의 형식에 따라 메시지 출력
            {
                case int:
                    Console.WriteLine($"{(int)obj}는 int 형식입니다.");
                    break;

                case float:
                    Console.WriteLine($"{(float)obj}는 float 형식입니다.");
                    break;
                default:
                    Console.WriteLine($"{(obj)}(은)는 모르는 형식입니다.");
                    break;

            }
        }
    }
}
