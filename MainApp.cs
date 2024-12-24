using System;


/*
try-catch 문: 
C#에서 예외를 처리하는 방법.
IndexOutOfRangeException 예외를 던졌는데 Main() 메서드가 처리하지 못하게 되는 문제 발생.
이를 해결하려면 예외를 Main()메서드가 받으면(catch) 됨.
 */

// try-catch 문을 이용하여, 잘못된 인덱스를 통해 배열의 요소에 접근할 때 일어나는
// IndexOutOfRangeException 예외를 안전하게 받아 처리하는 방법.
namespace TryCatch
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 }; // 크기가 3인 정수형 배열 arr을 선언하고 {1, 2, 3}으로 초기화합니다.

            
            try // 실행하려는 코드
            {
                for (int i = 0; i < 5; i++) // i가 0부터 4까지 반복함(for 루프를 5번 실행).
                {
                    Console.WriteLine(arr[i]); // arr[i]의 값을 출력합니다.
                                               // i가 0, 1, 2일 때는
                                               // 각각 arr[0], arr[1], arr[2]의 값인 1, 2, 3이 출력됩니다.
                                               // i가 3, 4일 때는 arr[3], arr[4]에 접근하려고 시도하는데,
                                               // 이는 배열의 범위를 벗어나는 인덱스입니다. 
                                               // 따라서 IndexOutOfRangeException 예외가 발생합니다.
                }
            }
            
            
            catch (IndexOutOfRangeException e) // 예외가 발생했을 때의 처리.
                                               // try 절에서 코드를 처리하다가 예외가 던져지면
                                               // catch 블록이 받아냅니다.
                                               // 이때, catch 절은 try 블록에서 던질 예외 객체와 형식이 일치해야 합니다. 
                                               // (예외 객체와 형식이 일치하지 않으면, 예외는 아무도 받지 못했기 때문에
                                               // '처리하지 않은 예외'로 남게 됩니다.)
                                               // try 블록에서 실행하는 코드에서 여러 종류의 예외를 던질 가능성이 있다면,
                                               // 이를 받을 수 있는 catch 블록도 여러 개 둘 수 있습니다.
                                               
                                               // try 블록에서 IndexOutOfRangeException 예외가 발생하면,
                                               // catch 블록이 실행됩니다.
                                               // e는 예외 객체를 나타냅니다.
            {
                Console.WriteLine($"예외가 발생했습니다 : {e.Message}"); // 예외 메시지를 출력합니다.
            }

            Console.WriteLine("종료"); // "종료"를 출력합니다. 
                                       //  try-catch 문을 사용하여 예외를 처리했기 때문에 
                                       // 이 코드는 정상적으로 실행되고, 프로그램은 정상적으로 종료됩니다.
        }
    }
}


/*
출력 결과

1
2
3
예외가 발생했습니다 : Index was outside the bounds of the array.
종료
*/
