using System;
using System.Collections.Generic;
using System.Threading.Tasks;


//  지정된 범위 내에서 소수(prime number)를 찾는 프로그램이다.
//  여러 개의 Task를 사용하여 소수를 찾는 작업을 병렬로 처리한다
//  (여러 개의 Task를 생성하고 Start() 메서드를 호출하면, 각 Task는 스레드 풀의 스레드에서 병렬로 실행된다),
//  Task를 비동기적으로 실행하고,
//  메인 스레드는 Task가 완료될 때까지 기다리지 않고 다른 작업을 수행한다.
// (Task를 생성하고 Wait() 메서드를 호출하지 않으면,
// Task는 백그라운드에서 비동기적으로 실행되고, 메인 스레드는 다른 작업을 계속 수행할 수 있다.)
namespace TaskResult
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
            int taskCount = Convert.ToInt32(args[2]);  // 명령줄 인수의 세 번째 값을 int 타입으로 변환하여 taskCount에 저장한다.

            // 범위 내에서 소수를 찾는 Func<object, List<long>> 델리게이트를 생성한다.
            Func<object, List<long>> FindPrimeFunc =
                (objRange) =>
                {
                    long[] range = (long[])objRange;  // objRange를 long 배열로 변환한다.
                    List<long> found = new List<long>();  // 찾은 소수를 저장할 List<long> 객체를 생성한다.

                    for (long i = range[0]; i < range[1]; i++)  // range[0]부터 range[1] - 1까지의 수를 검사한다.
                    {
                        if (IsPrime(i))  // i가 소수이면 found 리스트에 추가한다.
                            found.Add(i);
                    }

                    return found;  // 찾은 소수 리스트를 반환한다.
                };

            Task<List<long>>[] tasks = new Task<List<long>>[taskCount];  // taskCount 크기의 Task<List<long>> 배열을 생성한다.
            long currentFrom = from;  // 현재 작업 범위의 시작 값을 저장할 변수를 from으로 초기화한다.
            long currentTo = to / tasks.Length;  // 현재 작업 범위의 끝 값을 저장할 변수를 to / tasks.Length로 초기화한다.
            for (int i = 0; i < tasks.Length; i++)  // tasks 배열의 각 요소에 대해 반복한다.
            {
                Console.WriteLine("Task[{0}] : {1} ~ {2}", i, currentFrom, currentTo);  // 현재 Task의 범위를 출력한다.

                tasks[i] = new Task<List<long>>(FindPrimeFunc, new long[] { currentFrom, currentTo });  // FindPrimeFunc 델리게이트를 사용하여 Task 객체를 생성하고 tasks 배열에 저장한다.
                currentFrom = currentTo + 1;  // 다음 Task의 시작 값을 설정한다.

                if (i == tasks.Length - 2)  // 마지막 Task의 경우 currentTo를 to로 설정한다.
                    currentTo = to;
                else
                    currentTo = currentTo + (to / tasks.Length);  // 그 외의 경우 currentTo를 to / tasks.Length만큼 증가시킨다.
            }

            Console.WriteLine("Please press enter to start...");  // "Please press enter to start..." 메시지를 출력한다.
            Console.ReadLine();  // 사용자 입력을 기다린다.
            Console.WriteLine("Started...");  // "Started..." 메시지를 출력한다.

            DateTime startTime = DateTime.Now;  // 현재 시간을 startTime에 저장한다.

            foreach (Task<List<long>> task in tasks)  // tasks 배열의 각 Task를 시작한다.
                task.Start();

            List<long> total = new List<long>();  // 모든 Task에서 찾은 소수를 저장할 List<long> 객체를 생성한다.

            foreach (Task<List<long>> task in tasks)  // tasks 배열의 각 Task에 대해 반복한다.
            {
                task.Wait();  // Task가 완료될 때까지 기다린다.
                total.AddRange(task.Result.ToArray());  // Task의 결과(소수 리스트)를 total 리스트에 추가한다.
            }
            DateTime endTime = DateTime.Now;  // 현재 시간을 endTime에 저장한다.

            TimeSpan ellapsed = endTime - startTime;  // startTime과 endTime의 차이를 계산하여 ellapsed에 저장한다.

            // from부터 to까지의 소수 개수와 경과 시간을 출력한다.
            Console.WriteLine("Prime number count between {0} and {1} : {2}", from, to, total.Count);
            Console.WriteLine("Ellapsed time : {0}", ellapsed);
        }
    }
}