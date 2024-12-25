using System;


/*
람다식(Lambda Expression):
익명 메서드를 만들기 위해 사용.
람다식으로 만든 익명 메서드는 무명 함수(Anonymous Function)라고 부름.
대리자보다 익명 메서드를 더욱 간결하게 작성할 수 있는 기능.
 */


namespace SimpleLambda
{
    class MainApp
    {
        delegate int Calculate(int a, int b); // 익명 메서드를 만들려면 우선 대리자가 필요함.
                                              // 따라서 Calculate라는 이름의 델리게이트를 선언합니다.
                                              // 이 델리게이트는 두 개의 정수를 매개변수로 받아
                                              // 정수 값을 반환하는 메서드를 참조할 수 있습니다.

        static void Main(string[] args)
        {
            Calculate calc = (a, b) => a + b; // calc라는 Calculate 델리게이트 변수를 선언하고,
                                              // 람다 식 (a, b) => a + b를 사용하여 초기화합니다.
                                              // 람다 식은 (a, b)라는 매개변수 목록과
                                              // a + b라는 식으로 구성됩니다. 
                                              // 이 람다 식은 두 개의 정수를 더하는 기능을 수행합니다.

            Console.WriteLine($"{3} + {4} : {calc(3, 4)}"); // calc(3,4): calc 델리게이트를 호출하여,
                                                            // 3과 4를 더한 결과 반환합니다.
        }
    }
}


/*
출력 결과

3 + 4 : 7
*/
