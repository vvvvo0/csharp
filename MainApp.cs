using System; // System 네임스페이스를 사용한다.
using System.Threading.Tasks; // Task 클래스를 사용하기 위해 필요하다.

namespace Async // Async 네임스페이스를 정의한다.
{
    class MainApp // MainApp 클래스를 정의한다.
    {
        async static private void MyMethodAsync(int count) // 비동기 메서드 MyMethodAsync를 정의한다. count는 반복 횟수를 나타낸다.
        {
            Console.WriteLine("C"); // 콘솔에 "C"를 출력한다.
            Console.WriteLine("D"); // 콘솔에 "D"를 출력한다.

            await Task.Run(async () => // Task.Run() 메서드를 사용하여 비동기적으로 작업을 실행한다.
            {
                for (int i = 1; i <= count; i++) // 1부터 count까지 반복한다.
                {
                    Console.WriteLine($"{i}/{count} ..."); // 콘솔에 현재 진행 상황을 출력한다.
                    await Task.Delay(100); // 100밀리초 동안 대기한다.
                }
            });

            Console.WriteLine("G"); // 콘솔에 "G"를 출력한다.
            Console.WriteLine("H"); // 콘솔에 "H"를 출력한다.
        }

        static void Caller() // Caller 메서드를 정의한다.
        {
            Console.WriteLine("A"); // 콘솔에 "A"를 출력한다.
            Console.WriteLine("B"); // 콘솔에 "B"를 출력한다.

            MyMethodAsync(3); // MyMethodAsync 메서드를 호출한다. count는 3으로 설정된다.

            Console.WriteLine("E"); // 콘솔에 "E"를 출력한다.
            Console.WriteLine("F"); // 콘솔에 "F"를 출력한다.
        }

        static void Main(string[] args) // 프로그램의 진입점인 Main 메서드를 정의한다.
        {
            Caller(); // Caller 메서드를 호출한다.

            Console.ReadLine(); // 프로그램 종료 방지
        }
    }
}

/*
출력 결과

A
B
C
D
E
F
1/3 ...
2/3 ...
3/3 ...
G
H
 */