using System;
/*
분할 클래스: 여러 번에 나눠서 구현하는 클래스.
클래스의 구현이 길어질 경우 여러 파일에 나눠서 구현할 수 있게 함으로써,
소스 코드 관리의 편의를 제공함.
partial 키워드를 사용해서 작성.
C# 컴파일러는 분할 구현된 코드를 하나의 MyClass로 묶어서 컴파일 함.
그냥 하나의 클래스인 것처럼 사용하면 됨.
큰 그림을 여러 조각으로 나누어 그린 후, 최종적으로 하나의 그림으로 합치는 것과 같음.

 */
namespace PartialClass
{
    partial class MyClass // 클래스 이름 동일해야 함
                          // MyClass라는 이름의 분할 클래스를 선언
    {
        public void Method1()
        {
            Console.WriteLine("Method1");
        }

        public void Method2()
        {
            Console.WriteLine("Method2");
        }
    }

    partial class MyClass // 클래스 이름 동일해야 함
    {
        public void Method3()
        {
            Console.WriteLine("Method3");
        }

        public void Method4()
        {
            Console.WriteLine("Method4");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass(); // MyClass 객체를 생성
            obj.Method1(); // Method1(), Method2(), Method3(), Method4() 메서드를 호출
            obj.Method2();
            obj.Method3();
            obj.Method4();
        }
    }
}

// MyClass 클래스는 두 개의 파일로 나누어 작성되었습니다.
// 첫 번째 파일에는 Method1()과 Method2() 메서드가,
// 두 번째 파일에는 Method3()과 Method4() 메서드가 정의되어 있습니다.
