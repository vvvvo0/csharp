using System; 

namespace Hello 
{
    class Mainapp
    {
        static int Plus(int a, int b)
        {
            Console.WriteLine("Calling int Plus(int,int)...");
            return a + b;
        }

        static int Plus(int a, int b, int c)
        {
            Console.WriteLine("Calling int Plus(int,int,int)...");
            return a + b + c;
        }

        static double Plus(double a, double b)
        {
            Console.WriteLine("Calling double Plus(double,double)...");
            return a + b;
        }

        static double Plus(int a, double b)
        {
            Console.WriteLine("Calling double Plus(int, double)...");
            return a + b;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Plus(1, 2));
            Console.WriteLine(Plus(1, 2, 3));
            Console.WriteLine(Plus(1.0, 2.4));
            Console.WriteLine(Plus(1, 2.4));
        }
    }
}

// 하나의 메소드 이름에 여러 개의 구현을 올리는 것.
//오버로딩을 해 놓으면 컴파일러가 메소드 호출 코드에 사용되는 매개변수의 수와 형식을 분석해서
//어떤 버전이 호출될지를 찾아줌.

//실행할 메소드의 버전을 찾는 작업은 컴파일 타임에 이루어지므로 성능 저하 X.
//이름에 대한 고민을 줄여줌. 코드를 일관성 있게 유지해줌.
