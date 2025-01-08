using System;
using System.Threading; // 스레드 사용을 위한 네임스페이스

namespace UsingThreadState
{
    class MainApp
    {
        private static void PrintThreadState(ThreadState state) // ThreadState 값과 해당하는 정수 값을 출력하는 메서드
        {
            Console.WriteLine("{0,-16} : {1}", state, (int)state);
        }

        static void Main(string[] args)
        {
            PrintThreadState(ThreadState.Running); // Running 상태 출력
            PrintThreadState(ThreadState.StopRequested); // StopRequested 상태 출력
            PrintThreadState(ThreadState.SuspendRequested); // SuspendRequested 상태 출력
            PrintThreadState(ThreadState.Background); // Background 상태 출력
            PrintThreadState(ThreadState.Unstarted); // Unstarted 상태 출력
            PrintThreadState(ThreadState.Stopped); // Stopped 상태 출력
            PrintThreadState(ThreadState.WaitSleepJoin); // WaitSleepJoin 상태 출력
            PrintThreadState(ThreadState.Suspended); // Suspended 상태 출력
            PrintThreadState(ThreadState.AbortRequested); // AbortRequested 상태 출력
            PrintThreadState(ThreadState.Aborted); // Aborted 상태 출력
            PrintThreadState(ThreadState.Aborted | ThreadState.Stopped); // Aborted | Stopped 상태 출력
        }
    }
}

/*
출력 결과

Running          : 0
StopRequested    : 1
SuspendRequested : 2
Background       : 4
Unstarted        : 8
Stopped          : 16
WaitSleepJoin    : 32
Suspended        : 64
AbortRequested   : 128
Aborted          : 256
Stopped, Aborted : 272
 */
// ThreadState의 요소값이 2의 제곱으로 증가하는 모습을 보임.