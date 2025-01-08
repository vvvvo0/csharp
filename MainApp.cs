using System;
using System.Threading; // 스레드 사용을 위한 네임스페이스

namespace BasicThread
{
    class MainApp
    {
        static void DoSomething() // 스레드가 실행할 메서드
        {
            for (int i = 0; i < 5; i++) // 0부터 4까지 5번 반복
            {
                Console.WriteLine($"DoSomething : {i}"); // "DoSomething : {i}" 출력
                Thread.Sleep(10); // 10밀리초 동안 스레드 실행 중지
            }
        }

        static void Main(string[] args)
        {
            // (1) Thread의 인스턴스 생성
            Thread t1 = new Thread(new ThreadStart(DoSomething)); // DoSomething 메서드를 실행할 스레드 t1 생성

            Console.WriteLine("Starting thread..."); // "Starting thread..." 출력
            
            // (2) 스레드 시작
            t1.Start(); // 스레드 t1 시작

            for (int i = 0; i < 5; i++) // 0부터 4까지 5번 반복
            {
                Console.WriteLine($"Main : {i}"); // "Main : {i}" 출력
                Thread.Sleep(10); // 10밀리초 동안 메인 스레드 실행 중지
            }

            Console.WriteLine("Wating until thread stops..."); // "Wating until thread stops..." 출력
            
            // (3) 스레드의 종료 대기
            t1.Join(); // 스레드 t1이 종료될 때까지 기다림

            Console.WriteLine("Finished"); // "Finished" 출력
        }
    }
}