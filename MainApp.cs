using System;


/*
예외(Exception):
프로그래머가 생각한 시나리오에서 벗어나는 사건.
예를 들어, 숫자만 입력해야 하는데 문자열을 입력하거나,
파일을 전송하고 있는데 네트워크가 다운되는 등의 사건 발생.

예외 처리(Exception Handling):
예외가 프로그램의 오류나 다운으로 이어지지 않도록 적절하게 처리하는 것.
 */


// 배열의 범위를 벗어나는 인덱스에 접근하여 IndexOutOfRangeException 예외를 발생시키는 모습.
namespace KillingProgram
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 }; // 크기가 3인 정수형 배열 arr을 선언하고,
                                     // {1, 2, 3}으로 초기화합니다.

            for (int i = 0; i < 5; i++) // i가 0부터 4까지 반복합니다.(for 루프 총 5번 실행됨)
            {
                Console.WriteLine(arr[i]); // arr[i]의 값을 출력합니다. 
                                           // i가 0, 1, 2일 때는
                                           // arr[0], arr[1], arr[2]의 값인 1, 2, 3이 출력됩니다.
                                           // i가 3, 4일 때는
                                           // arr[3], arr[4]에 접근하려고 시도하는데,
                                           // 이는 배열의 범위를 벗어나는 인덱스입니다.
                                           // 따라서 IndexOutOfRangeException 예외가 발생하고,
                                           // 프로그램이 비정상적으로 종료됩니다.

                // 즉, i가 '배열의 크기-1'을 넘어서면 예외를 일으키고 종료됩니다.
                // 이후의 코드들은 더 이상 실행되지 않습니다.
            }

            Console.WriteLine("종료");//  "종료"를 출력합니다.
                                    // 하지만 IndexOutOfRangeException 예외가 발생하여,
                                    // 프로그램이 비정상적으로 종료되었으므로
                                    // 이 문장은 실행되지 않습니다.
        }
    }
}


/*
출력 결과

1
2
3
Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at KillingProgram.MainApp.Main(String[] args) in C:\Users\M\source\repos\Hello\MainApp.cs:line 14
*/