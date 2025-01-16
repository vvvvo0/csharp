using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParallelLoop
{
    class MainApp
    {
        static bool IsPrime(long number)  // 주어진 수가 소수인지 판별하는 메서드이다.
        {
            if (number < 2)  // 2보다 작으면 소수가 아니다.
                return false;

            if (number % 2 == 0 && number != 2)  // 2를 제외한 짝수는 소수가 아니다.
                return false;

            for (long i = 2; i < number; i++)  // 2부터 number - 1까지의 수로 나누어 떨어지는지 확인한다.
            {
                if (number % i == 0)  // 나누어 떨어지면 소수가 아니다.
                    return false;
            }

            return true;  // 위 조건을 모두 만족하면 소수이다.
        }

        static void Main(string[] args)
        {
            long from = Convert.ToInt64(args[0]);  // 명령줄 인수의 첫 번째 값을 long 타입으로 변환하여 from에 저장한다.
            long to = Convert.ToInt64(args[1]);  // 명령줄 인수의 두 번째 값을 long 타입으로 변환하여 to에 저장한다.

            Console.WriteLine("Please press enter to start...");  // "Please press enter to start..." 메시지를 출력한다.
            Console.ReadLine();  // 사용자 입력을 기다린다.
            Console.WriteLine("Started...");  // "Started..." 메시지를 출력한다.

            DateTime startTime = DateTime.Now;  // 현재 시간을 startTime에 저장한다.
            List<long> total = new List<long>();  // 찾은 소수를 저장할 List<long> 객체를 생성한다.

            Parallel.For(from, to, (long i) =>  // from부터 to - 1까지의 숫자에 대해 병렬로 반복 작업을 수행한다.
            {
                if (IsPrime(i))  // i가 소수이면
                    lock (total)  // total 객체에 락을 걸어 동기화한다.
                        total.Add(i);  // total 리스트에 i를 추가한다.
            });

            DateTime endTime = DateTime.Now;  // 현재 시간을 endTime에 저장한다.

            TimeSpan ellapsed = endTime - startTime;  // startTime과 endTime의 차이를 계산하여 ellapsed에 저장한다.

            // from부터 to까지의 소수 개수와 경과 시간을 출력한다.
            Console.WriteLine("Prime number count between {0} and {1} : {2}", from, to, total.Count);
            Console.WriteLine("Ellapsed time : {0}", ellapsed);
        }
    }
}