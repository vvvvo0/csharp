using System; 

namespace Hello 
{
    class Mainapp
    {
        static void Divide(int a, int b, out int quotient, out int remainder) //메소드 선언부에 ref 키워드 대신 out 키워드 사용
        {
            quotient = a / b;
            remainder = a % b;
        }
        static void Main(string[] args)
        {
            int a= 20;
            int b = 3;
            // int c;
            // int d;

            Divide(a, b, out int c, out int d); // 메소드 호출부에 ref 키워드 대신 out 키워드 사용

            Console.WriteLine($"a: {a}, b: {b}, a/b: {c}, a%b:{d}");

        }
    }
}

// out에는 ref에 없는 안전장치 존재.
//out 키워드를 이용하여 매개변수를 넘길 떄는 메소드가 해당 매개변수에 결과를 저장하지 않으면 컴파일러가 
//에러 메시지를 출력해줌.
