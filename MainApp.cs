using System;


/*
Action 대리자:
값을 반환하지 않는 메서드를 참조할 수 있는 대리자.
Func 대리자처럼 17개 버전이 선언되어 있음.
Action 델리게이트는 값을 반환하지 않으므로, Func 대리자와 달리 반환 형식이 없음.

예를 들어, Action은 입력 매개변수가 없는 메서드를 나타내고,
Action<int>는 int 타입의 입력 매개변수를 하나 받는 메서드를 나타냅니다.

Action 델리게이트의 장점?(=Func 대리자의 장점)
다양한 입력 매개변수를 지원합니다.
람다 식을 사용하여 간결하게 표현할 수 있습니다.
메서드를 변수처럼 저장하고 전달할 수 있습니다.
 */


// Action 델리게이트를 사용하는 방법
namespace ActionTest
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Action act1 = () => Console.WriteLine("Action()"); // 입력 매개변수가 없고,
                                                               // Console.WriteLine("Action()")을 실행하는 람다 식을
                                                               // act1에 할당합니다.
            act1(); // act1()을 호출합니다.

            int result = 0; // 정수형 변수 result를 선언하고 0으로 초기화합니다.
            Action<int> act2 = (x) => result = x * x;  // int 타입 매개변수를 하나 받고,
                                                       // esult에 x * x를 할당하는 람다 식을 
                                                       // act2에 할당합니다.

            act2(3); // act2(3)을 호출합니다.

            Console.WriteLine($"result : {result}"); // result 값을 출력합니다.

            Action<double, double> act3 = (x, y) => // double 타입 매개변수를 두 개 받고
                                                    // pi를 계산하여 출력하는 람다 식을
                                                    //  act3에 할당합니다.
            {
                double pi = x / y;
                Console.WriteLine($"Action<T1, T2>({x}, {y}) : {pi}");
            };

            act3(22.0, 7.0); // act3(22.0, 7.0)을 호출합니다.
        }
    }
}


/*
출력 결과

Action()
result : 9
Action<T1, T2>(22, 7) : 3.142857142857143
*/