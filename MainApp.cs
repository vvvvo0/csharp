using System;


/*
 대리자(delegate):
메서드에 대한 참조.
대리자에 메소드의 주소를 할당한 후, 대리자를 호출하면 대리자가 메소드를 호출해줌.

델리게이트의 장점?
메서드를 변수처럼 저장하고 전달할 수 있습니다.
메서드를 동적으로 호출할 수 있습니다.
콜백 함수를 구현하는 데 사용할 수 있습니다.
 */


// 대리자(delegate)를 사용하여 메서드를 참조하고 호출하는 방법
namespace Delegate
{
    delegate int MyDelegate(int a, int b); // delegate 키워드를 사용하여,
                                           // MyDelegate라는 이름의 델리게이트를 선언.
                                           // 델리게이트는 인스턴스가 아닌 형식(Type)임,
                                           // 따라서 메소드를 참조하는 무엇을 만드려면
                                           // MyDelegate라는 델리게이트의 인스턴스를 따로 만들어야 함.
                                           // MyDelegate 델리게이트는 두 개의 정수형 '매개변수'를 받고,
                                           // 정수형 값을 '반환'하는 "메서드를 참조"할 수 있습니다.


    // 대리자의 반환 형식과 매개변수를 따르는 메서드를 선언해야 대리자가 참조할 수 있음. 
    class Calculator
    {
        public int Plus(int a, int b) // Plus(): 두 정수를 더하는 '인스턴스 메서드' 
                                      // 인스턴스 메서드(static으로 한정x):
                                      // 인스턴스를 생성해야만 호출가능한 메서드
        {
            return a + b;
        }

        public static int Minus(int a, int b) // Minus(): 두 정수를 빼는 '정적 메서드'
                                              // 정적 메서드(static으로 한정o):
                                              // 인스턴스를 생성안해도 호출가능한 메서드
        {
            return a - b;
        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            Calculator Calc = new Calculator(); // Calculator 클래스의 인스턴스인 Calc 생성
                                                // 인스턴스 메서드인 Puls() 메서드 사용하려면 필요함
            
            MyDelegate Callback; // (1) MyDelegate 델리게이트 타입의 변수인 Callback을 선언 

            Callback = new MyDelegate(Calc.Plus); // 생성한 인스턴스(Calc)를 통해야만 호출 가능한 Plus() 메서드 
            Console.WriteLine(Callback(3, 4)); 

            Callback = new MyDelegate(Calculator.Minus); // (2) MyDelegate () 생성자를 호출해서 Callback 인스턴스(객체)를 생성
                                                         // -> 생성자 인수는 Minus() 메서드를 사용
                                                         // -> Callback은 Minus() 메서드를 참조함
            Console.WriteLine(Callback(7, 5)); // (3) 메서드를 호출하듯 대리자를 호출하면, 참조하고 있는 메서드가 실행됨.
                                               // 즉, Calllback을 호출하면 Callback은
                                               // 현재 자신이 참조하는 주소에 있는 메서드(Minus())의 코드를 실행하고,
                                               // 그 결과(숫자 2)를 호출자에게 반환함
        }
    }
}


/*
출력 결과

7
2
 */