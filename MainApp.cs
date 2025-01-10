using System;
using System.Threading;

namespace WaitPulse
{
    class Counter
    {
        const int LOOP_COUNT = 1000; // 반복 횟수를 나타내는 상수이다.

        // (1) 클래스 안에 동기화 객체 필드를 선언한다.
        readonly object thisLock; // 잠금 객체이다.

        // (2) 스레드를 WaitSleepJain 상태로 바꿔 블록할 조건(Wait() 메서드를 호출할 조건)을
        // 결정할 필드를 선언한다.
        bool lockedCount = false; // count 변수에 대한 잠금 여부를 나타내는 변수이다.

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
                // (3) 스레드를 블록하고 싶은 곳에 lock 블록 안에서 (2)에서 선언한 필드를 검사하여,
                // Monitor.Wait() 메서드를 호출한다.
                lock (thisLock) // 잠금 객체를 사용하여 임계 영역을 보호한다.
                {
                    // (4) (3)에서 선언한 코드는 count가 0보다 크거나 lockedCount가 true이면 해당 스레드는 블록된다.
                    while (count > 0 || lockedCount == true) // count가 0보다 크거나 lockedCount가 true이면 대기한다.
                        Monitor.Wait(thisLock); // 잠금을 해제하고 다른 스레드가 Pulse()를 호출할 때까지 대기한다.

                    // (5) 블록되어있던 스레드가 깨어나면 작업을 수행해야한다,
                    // 따라서 가장 먼저 (2)에서 선언한 lockedCount의 값을 true로 바꾼다.
                    // 이렇게 해두면 다른 스레드가 이 코드에 접근할 때 (3)에서 선언해둔 블록 코드에 걸려서
                    // 같은 코드를 실행할 수 없게 된다.
                    lockedCount = true; // count 변수에 대한 잠금을 설정한다.
                    count++; // 카운터 값을 1 증가시킨다.

                    // (6) 작업을 마치면, lockedCount의 값을 다시 false로 바꾼 뒤 Monitor.Pulse() 메서드를 호출한다,
                    // 그러면 Waiting Queue에 대기하고 있던 다른 스레드가 깨어나서, 
                    // False로 바뀐 lockedCount를 보고 작업을 수행한다.
                    lockedCount = false; // count 변수에 대한 잠금을 해제한다.
                    Monitor.Pulse(thisLock); // 대기 중인 스레드를 깨운다.
                }
            }
        }

        public void Decrease() // 카운터 값을 감소시키는 메서드이다.
        {
            int loopCount = LOOP_COUNT; // 반복 횟수를 loopCount 변수에 저장한다.

            while (loopCount-- > 0) // loopCount가 0보다 클 때까지 반복한다.
            {
                lock (thisLock) // 잠금 객체를 사용하여 임계 영역을 보호한다.
                {
                    while (count < 0 || lockedCount == true) // count가 0보다 작거나 lockedCount가 true이면 대기한다.
                        Monitor.Wait(thisLock); // 잠금을 해제하고 다른 스레드가 Pulse()를 호출할 때까지 대기한다.

                    lockedCount = true; // count 변수에 대한 잠금을 설정한다.
                    count--; // 카운터 값을 1 감소시킨다.
                    lockedCount = false; // count 변수에 대한 잠금을 해제한다.

                    Monitor.Pulse(thisLock); // 대기 중인 스레드를 깨운다.
                }
            }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter(); // Counter 객체를 생성한다.

            Thread incThread = new Thread(new ThreadStart(counter.Increase)); // Increase 메서드를 실행할 스레드를 생성한다.
            Thread decThread = new Thread(new ThreadStart(counter.Decrease)); // Decrease 메서드를 실행할 스레드를 생성한다.

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