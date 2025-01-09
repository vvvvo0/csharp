using System;
using System.Threading;

namespace Synchronize
{
    class Counter
    {
        const int LOOP_COUNT = 1000; // 반복 횟수를 나타내는 상수입니다.

        readonly object thisLock; // lock 객체입니다.

        private int count; // 카운터 값을 저장하는 필드입니다.
        public int Count // count 필드에 접근하기 위한 프로퍼티입니다.
        {
            get { return count; }
        }

        public Counter() // 생성자입니다.
        {
            thisLock = new object(); // lock(잠금) 객체를 초기화합니다.
            count = 0; // 카운터 값을 0으로 초기화합니다.
        }

        public void Increment() // 카운터 값을 증가시키는 메서드입니다.
        {
            int loopCount = LOOP_COUNT; // 반복 횟수를 loopCount 변수에 저장합니다.
            while (loopCount-- > 0) // loopCount가 0보다 클 때까지 반복합니다.
            {
                lock (thisLock) // lock 객체를 사용하여 크리티컬 섹션을 보호합니다.
                {
                    count++; // 카운터 값을 1 증가시킵니다.
                }
                Thread.Sleep(1); // 1밀리초 동안 스레드를 일시 중지합니다.
            }
        }

        public void Decrement() // 카운터 값을 감소시키는 메서드입니다.
        {
            int loopCount = LOOP_COUNT; // 반복 횟수를 loopCount 변수에 저장합니다.
            while (loopCount-- > 0) // loopCount가 0보다 클 때까지 반복합니다.
            {
                lock (thisLock) // 잠금 객체를 사용하여 크리티컬 섹션을 보호합니다.
                {
                    count--; // 카운터 값을 1 감소시킵니다.
                }
                Thread.Sleep(1); // 1밀리초 동안 스레드를 일시 중지합니다.
            }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter(); // Counter 객체를 생성합니다.

            Thread incThread = new Thread(new ThreadStart(counter.Increment)); // Increment 메서드를 실행할 스레드를 생성합니다.
            Thread decThread = new Thread(new ThreadStart(counter.Decrement)); // Decrement 메서드를 실행할 스레드를 생성합니다.

            incThread.Start(); // incThread 스레드를 시작합니다.
            decThread.Start(); // decThread 스레드를 시작합니다.

            incThread.Join(); // incThread 스레드가 종료될 때까지 기다립니다.
            decThread.Join(); // decThread 스레드가 종료될 때까지 기다립니다.

            Console.WriteLine(counter.Count); // 카운터 값을 출력합니다.
        }
    }
}

/*
출력 결과

0
 */