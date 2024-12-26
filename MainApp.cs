﻿using System;


/*
Func 대리자:
결과를 반환하는 메서드를 참조하기 위해 만들어짐.
.NET에 17가지 버전의 Func 대리자가 준비되어 있는데,
입력 매개변수가 하나도 없는 것부터 16개에 이르는 것까지 버전이 다양하기 때문에,
입력 매개변수가 16개 이상이거나 ref나 out 한정자로 수식된 매개변수를 사용해야 하는 경우가 아니면
별도의 대리자를 만들어 쓸 필요가 없습니다.

Func 델리게이트의 마지막 타입 매개변수는 반환 타입을 나타내고,
나머지 매개변수는 입력 매개변수의 타입을 나타냅니다.
예를 들어, Func<int>는 입력 매개변수가 없고 int 타입의 값을 반환하는 메서드를 나타내고,
Func<int, int>는 int 타입의 입력 매개변수를 하나 받고 int 타입의 값을 반환하는 메서드를 나타냅니다.

Func 사용 이유?
익명 메서드와 무명 함수(람다식으로 만든 익명 메서드)를 선언하려면,
매번 별개의 대리자를 선언해야 합니다.
이러한 번거로움을 '.NET에 미리 선언되어 있는' Func 대리자와 Action 대리자로 해결할 수 있습니다.

Func 델리게이트의 장점?
다양한 입력 매개변수와 반환 타입을 지원합니다.(.NET에 미리 선언되어 있음)
람다 식을 사용하여 간결하게 표현할 수 있습니다.
메서드를 변수처럼 저장하고 전달할 수 있습니다.(=델리게이트)
 */


// Func 델리게이트를 사용하는 방법
namespace FuncTest
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Func<int> func1 = () => 10; // 입력 매개변수가 없고, 무조건 10을 반환하는 람다 식을
                                        // func1에 할당합니다.
            Console.WriteLine($"func1() : {func1()}"); // func1()을 호출하고 결과를 출력합니다.
                                                       // 10이 출력됩니다.


            Func<int, int> func2 = (x) => x * 2; // 입력 매개변수는 int 형식 하나이고, 반환 형식도 int.
                                                 // int 타입 매개변수를 하나 받고,
                                                 //  x * 2를 반환하는 람다 식을 func2에 할당합니다.

            Console.WriteLine($"func2(4) : {func2(4)}"); // func2(4)를 호출하고 결과를 출력합니다.
                                                         // 8이 출력됩니다.

            Func<double, double, double> func3 =
                (x, y) => x / y; // 입력 매개변수는 double 타입 둘, 반환 타입은 double.
                                 // double 타입 매개변수를 두 개 받고,
                                 // x / y를 반환하는 람다 식을 func3에 할당합니다.

            Console.WriteLine($"func3(22, 7) : {func3(22, 7)}"); // func3(22, 7)을 호출하고
                                                                 // 결과를 출력합니다.
        }
    }
}


/*
출력 결과

func1() : 10
func2(4) : 8
func3(22, 7) : 3.142857142857143 
 */