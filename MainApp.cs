using System;


/*
예외 처리(Exception Handling) 장점:
(1) 실제 일을 하는 코드(try 절)와 문제를 처리하는 코드(catch 절)를 분리시킴으로써,
코드를 간결하게 만들어 줌.

(2) 예외 객체의 StackTrace 프로퍼티를 통해, 문제가 발생한 부분의 위치를 알려주기 때문에,
디버깅이 용이함.

(3) 여러 문제점을 하나로 묶거나, 코드에서 발생할 수 있는 오류를 종류별로 정리해줌.
예를 들어, try 블록의 코드 중에서DivideByZeroException 예외를 일으킬 수 있는 부분이
둘 이상일 수 있는데, 이 형식의 예외를 받는 catch 블록 하나면 모두 처리 가능함.

StackTrace 프로퍼티의 활용?
(1) 예외 발생 위치를 추적하여 디버깅을 용이하게 합니다.
(2) 예외 발생 시점의 호출 스택 정보를 로깅하여 프로그램 분석에 활용할 수 있습니다.

로깅?
프로그램 실행 중에 발생하는 다양한 이벤트나 정보를 기록하는 과정.

호출 스택 정보를 로깅한다는 것?
예외 발생 시점의 호출 스택 정보를 로그에 기록하는 것을 의미.
예외가 발생하면 프로그램은 현재 실행 중인 메서드, 그 메서드를 호출한 메서드, 
또 그 메서드를 호출한 메서드 등을 순차적으로 따라 올라가면서 호출 스택 정보를 생성합니다.
이 정보에는 각 메서드의 이름, 파일 이름, 줄 번호 등이 포함됩니다.
 */


// 예외 처리(Exception Handling) 과정에서 StackTrace 프로퍼티를 사용하여
// 예외 발생 위치를 추적하는 방법을 보여줌
namespace StackTrace
{
    class MainApp
    {
        static void Main(string[] args)
        {
            try
            {
                int a = 1; // 정수형 변수 a를 선언하고 1로 초기화합니다.
                Console.WriteLine(3 / --a); // a 값을 먼저 1 감소시킨 후(전위 감소 연산자),
                                            // 3을 a로 나눈 결과를 출력하려고 시도합니다. 
                                            // a 값이 0이 되므로,
                                            // DivideByZeroException 예외가 발생합니다.
            }

            catch (DivideByZeroException e) // DivideByZeroException 예외가 발생하면,
                                            // catch 블록이 실행됩니다.
                                            // e는 예외 객체를 나타내며,
                                            // e.StackTrace는 예외 발생 위치의 호출 스택 정보를 문자열로 반환합니다.
            {
                Console.WriteLine(e.StackTrace); // e.StackTrace 값을 콘솔에 출력합니다.
            }
        }
    }
}


/*
출력 결과

   at StackTrace.MainApp.Main(String[] args) in C:\Users\M\source\repos\Hello\MainApp.cs:line 29
*/
// 출력 결과는 예외가 발생한 위치를 나타냅니다.
// 'StackTrace.MainApp.Main(String[] args)'는
// MainApp 클래스의 Main 메서드에서 예외가 발생했음을 의미하고, 
// 'C:\...\StackTrace\MainApp.cs:line 29' 는 예외가 발생한 파일과 줄 번호를 나타냅니다.