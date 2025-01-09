using System;
using System.Threading;

namespace UsingMonitor
{
    class Counter
    {
        const int LOOP_COUNT = 1000; // 반복 횟수를 나타내는 상수이다.

        readonly object thisLock; // 잠금 객체이다.

        private int count; // 카운터 값을 저장하는 필드이다.
        public int Count // count 필드에 접근하기 위한 프로퍼티이다.
        {
            get { return count; }
        }

        public Counter() // 생성자이다.
        {
            thisLock = new object(); // 잠금 객체를 초기화한다.
            count = 0; // 카운터 값을 0으로 초기화한다.
        }

        public void Increase() // 카운터 값을 증가시키는 메서드이다.
        {
            int loopCount = LOOP_COUNT; // 반복 횟수를 loopCount 변수에 저장한다.
            while (loopCount-- > 0) // loopCount가 0보다 클 때까지 반복한다.
            {
                Monitor.Enter(thisLock); // 잠금 객체를 사용하여 임계 영역을 보호한다.
                try
                {
                    count++; // 카운터 값을 1 증가시킨다.
                }
                finally
                {
                    Monitor.Exit(thisLock); // 잠금을 해제한다.
                }
                Thread.Sleep(1); // 1밀리초 동안 스레드를 일시 중지한다.
            }
        }

        public void Decrease() // 카운터 값을 감소시키는 메서드이다.
        {
            int loopCount = LOOP_COUNT; // 반복 횟수를 loopCount 변수에 저장한다.
            while (loopCount-- > 0) // loopCount가 0보다 클 때까지 반복한다.
            {
                Monitor.Enter(thisLock); // 잠금 객체를 사용하여 임계 영역을 보호한다.
                try
                {
                    count--; // 카운터 값을 1 감소시킨다.
                }
                finally
                {
                    Monitor.Exit(thisLock); // 잠금을 해제한다.
                }
                Thread.Sleep(1); // 1밀리초 동안 스레드를 일시 중지한다.
            }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter(); // Counter 객체를 생성한다.

            Thread incThread = new Thread(new ThreadStart(counter.Increase)); // Increment 메서드를 실행할 스레드를 생성한다.
            Thread decThread = new Thread(new ThreadStart(counter.Decrease)); // Decrement 메서드를 실행할 스레드를 생성한다.

            incThread.Start(); // incThread 스레드를 시작한다.
            decThread.Start(); // decThread 스레드를 시작한다.

            incThread.Join(); // incThread 스레드가 종료될 때까지 기다린다.
            decThread.Join(); // decThread 스레드가 종료될 때까지 기다린다.

            Console.WriteLine(counter.Count); // 카운터 값을 출력한다.
        }
    }
}

/*
출력 결과

0
*/