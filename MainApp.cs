using System;


/*
예외 처리(Exception Handling):
예외 처리는 프로그램 실행 중 발생할 수 있는 예외 상황을 처리하여 
프로그램의 비정상적인 종료를 방지하고 안정성을 높이는 데 사용됩니다.

throw 문: 예외를 던지는 방법.
 예외는
(1) 발생한 메서드에서 처리할 수도 있고,
(2) 호출자에게 던져서 호출자가 처리하도록 할 수도 있습니다.
 */


namespace Throw
{

    class MainApp
    {
        static void DoSomething(int arg) // DoSomething 메서드: 정수형 인자 arg를 입력으로 받습니다.

        {
            if (arg < 10) // arg 값이 10보다 작으면,
                Console.WriteLine($"arg : {arg}"); // "arg : {arg}"를 출력하고,

            else // arg 값이 10보다 크거나 같으면
                throw new Exception("arg가 10보다 큽니다."); // throw 문을 이용해서
                                                             // Exception 예외를 발생시킵니다.
                                                             //
                                                       // (1) DoSomething() 메서드 안에서
                                                       // throw new Exception("arg가 10보다 큽니다."); 구문을 통해 
                                                       // 예외를 던졌지만, DoSomething() 메서드 안에는
                                                       // 이 예외를 처리할 수 있는 코드(예를 들어,try-catch 문이나
                                                       // finally 블록, using 문)가 없습니다.
                                                       // (2) 따라서 이 예외는 DoSomething() 메서드를 호출한
                                                       // 호출자(여기서는 Main() 메서드)에게 던져집니다.
                                                       // (3) 이렇게 던져진 예외는 메소드를 호출한 자(여기서는 Main() 메서드)의
                                                       // try~catch 문에서 받아냅니다.
        }


        static void Main(string[] args) // Main 메서드: try-catch 문을 사용하여 예외 처리를 합니다.
                                        // try 블록 안에는 DoSomething 메서드를 여러 번 호출하는 코드가 있습니다.
                                        // DoSomething 메서드를 호출할 때, 
                                        // arg 값이 10보다 크거나 같으면 Exception 예외가 발생합니다.
        {
            try
            {
                DoSomething(1);
                DoSomething(3);
                DoSomething(5);
                DoSomething(9);
                DoSomething(11); // Exception 예외가 발생하고,
                                 // catch 블록에서 예외 메시지 "arg가 10보다 큽니다."가 출력됩니다.

                DoSomething(13); // DoSomething(11);에서 예외가 발생하여 이 코드는 실행되지 않습니다.
            }

            catch (Exception e) // Exception 타입의 예외를 처리합니다. 
                                // Exception e는 발생한 예외 객체를 e 변수에 할당합니다. 
            {
                Console.WriteLine(e.Message); // 예외 객체의 메시지를 출력합니다.
                                              // DoSomething(11)에서 Exception 예외가 발생하고, 
                                              //  "arg가 10보다 큽니다."가 출력됩니다.
            }
        }
    }
}


/*
출력 결과

arg : 1
arg : 3
arg : 5
arg : 9
arg가 10보다 큽니다.
*/