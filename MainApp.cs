using System;


/*
finally 절:
예외 처리를 하는 방법.
try~catch 문의 마지막에 연결해서 사용.
자신이 소속된 try 절이 실행된다면 finally 절은 어떤 경우라도 실행됨.
즉, 예외 발생 여부와 관계없이 finally 절은 실행됨.
심지어 return 문이나 throw 문이 사용되더라도 finally 절은 반드시 실행됨.

finally 절 나온 이유?
try 블록에서 코드를 실행하다가 예외가 던져지면 프로그램의 실행이 catch 절로 바로 뛰어넘어감.
따라서 try 블록에 중요한 코드를 실행하지 못할 수 있음.
그렇다고 모든 catch 절에 중요한 코드를 배치하는 것은 별로임.

finally 절 안에서 또 예외가 일어나면 어떻게 함?
finally 블록 안에 예외가 일어나면 받아주거나 처리해주는 코드가 없으면,
이 예외는 '처리되지 않은 예외'가 되버림.
따라서 예외가 발생하지 않도록 할 수 없다면,
finally 절 안에서 다시 한 번 try-catch 절을 사용하는 것도 방법임.

finally 절의 용도?
예외 발생 여부와 관계없이 항상 실행해야 하는 코드를 작성할 때 유용합니다.
주로 파일 닫기, 네트워크 연결 해제, 리소스 해제 등에 사용됩니다.
*/


// finally 절을 사용하여 예외 발생 여부와 관계없이 특정 코드를 실행하는 방법을 보여줌
namespace Finally
{
    class MainApp
    {
        static int Divide(int divisor, int dividend) // Divide() 메서드: 정수형 divisor를
                                                     // 정수형 dividend로 나눈 결과를
                                                     // 반환하는 메서드입니다.

        // Divide 메서드에는 FormatException예외를 처리하는 catch문이 없어도 되는이유?
        //  FormatException은 Convert.ToInt32() 메서드에서 발생할 수 있는 예외이고, 
        //  Divide 메서드에서는 Convert.ToInt32() 메서드를 사용하지 않기 때문입니다.
        // 반대로, Main 메서드에서는 Divide 메서드를 호출하기 전에 
        // Convert.ToInt32() 메서드를 사용하여 문자열을 정수로 변환합니다. 
        // 따라서 Main 메서드에서는 FormatException 예외를 처리하는 catch 문이 필요합니다.
        {
            try // divisor / dividend 연산을 수행합니다.
                // 만약 dividend가 0이면 DivideByZeroException 예외가 발생합니다.
            {
                Console.WriteLine("Divide() 시작");
                return divisor / dividend;
            }

            catch (DivideByZeroException e) // DivideByZeroException 예외가 발생하면,
                                            // "Divide() 예외 발생" 메시지를 출력하고,
                                            // throw e;를 사용하여 예외를 다시 던집니다.
                                            // DivideByZeroException:
                                            // 숫자를 0으로 나누려고 할 때 발생하는 예외입니다.
                                            // System 네임스페이스에 정의된 예외 클래스입니다.
                                            // 즉, .NET Framework에서 기본적으로 제공하는 예외입니다.
                                            // 따라서 using System;을 사용하면
                                            // DivideByZeroException 예외를 사용할 수 있습니다.
            {
                Console.WriteLine("Divide() 예외 발생");
                throw e;
            }

            finally // finally 블록은 예외 발생 여부와 관계없이 항상 실행됩니다.
                    // "Divide() 끝" 메시지를 출력합니다.
            {
                Console.WriteLine("Divide()  끝");
            }
        }


        static void Main(string[] args)
        {
            try // 사용자로부터 피제수와 제수를 입력받습니다.
                // Divide 메서드를 호출하여 나눗셈 연산을 수행하고 결과를 출력합니다.
            {
                Console.Write("피제수를 입력하세요. :");
                String temp = Console.ReadLine(); // 콘솔에서 사용자의 입력을 받아, temp라는 문자열 변수에 저장
                                                  // Console.ReadLine():
                                                  // 사용자가 Enter 키를 누를 때까지 입력한 모든 문자를 문자열로 반환합니다.
                int divisor = Convert.ToInt32(temp); // temp에 저장된 문자열을 정수형(int)으로 변환하여,
                                                     // divisor라는 변수에 저장.
                                                     // Convert.ToInt32() 메서드: 문자열을 정수로 변환하는 역할.
                                                     // 
                                                     // 만약 temp에 숫자 형식이 아닌 문자열이 저장된 경우,
                                                     // Convert.ToInt32(temp)는 FormatException 예외를 발생시킵니다.
                                                     // 예를 들어, temp에 "abc"와 같은 문자열이 저장된 경우,  
                                                     // Convert.ToInt32(temp)는 FormatException 예외를 발생시키고,
                                                     // 프로그램이 비정상적으로 종료될 수 있습니다.
                                                     // 따라서 try-catch 문을 사용하여 FormatException 예외를 처리하는 것이 안전.

                Console.Write("제수를 입력하세요. : ");
                temp = Console.ReadLine();
                int dividend = Convert.ToInt32(temp);

                Console.WriteLine("{0}/{1} = {2}",
                    divisor, dividend, Divide(divisor, dividend)); // Divide(divisor, dividend):
                                                                   // 이 코드에서 Divide() 메서드가 사용됨.
                                                                   // divisor와 dividend는 메서드에 전달되는 인자입니다.
                                                                   // Divide() 메서드는 전달받은 두 정수를 나눈 결과를 반환하고,
                                                                   // Console.WriteLine()은 이 결과를 출력합니다.
            }

            catch (FormatException e) // FormatException 예외가 발생하면,
                                      // "에러 : " 메시지와 함께 예외 메시지를 출력합니다.
                                      // FormatException: 숫자 형식이 잘못된 경우 발생하는 예외입니다.
            {
                Console.WriteLine("에러 : " + e.Message);
            }

            catch (DivideByZeroException e) // DivideByZeroException 예외가 발생하면,
                                            // "에러 : " 메시지와 함께 예외 메시지를 출력합니다.
                                            // DivideByZeroException: 숫자를 0으로 나누려고 할 때 발생하는 예외입니다.
            {
                Console.WriteLine("에러 : " + e.Message);
            }

            finally // finally 블록은 예외 발생 여부와 관계없이 항상 실행됩니다.
                    // "프로그램을 종료합니다." 메시지를 출력합니다.
            {
                Console.WriteLine("프로그램을 종료합니다.");
            }
        }
    }
}


/*
출력 결과

피제수를 입력하세요. :10
제수를 입력하세요. : 2
Divide() 시작
Divide()  끝
10/2 = 5
프로그램을 종료합니다.
 */

/*
출력 결과(0으로 나눔)

피제수를 입력하세요. :10
제수를 입력하세요. : 0
Divide() 시작
Divide() 예외 발생
Divide()  끝
에러 : Attempted to divide by zero.
프로그램을 종료합니다.
 */

/*
출력 결과(문자열 입력)

피제수를 입력하세요. :10
제수를 입력하세요. : abc
에러 : The input string 'abc' was not in a correct format.
프로그램을 종료합니다.
 */