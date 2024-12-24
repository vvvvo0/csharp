using System;


/*
예외 필터(Exception Filter):
catch 절이 받아들일 예외 객체에 제약 사항을 명시해서,
해당 조건을 만족하는 예외 객체에 대해서만 예외 처리 코드를 실행할 수 있도록 함.
catch() 절 뒤에 when 키워드를 이용해서 제약 조건을 기술하면 됨.
when을 if라고 읽으면 이해하기 쉬움.

예외 필터링은 catch 블록에서 예외를 처리할지 여부를 결정하기 위해 조건을 추가하는 기능임.
즉, 특정 조건을 만족하는 예외만 처리하고,
그렇지 않은 예외는 다른 catch 블록이나 호출자에게 넘길 수 있음.

장점?
여러 catch 블록을 사용하지 않고도 다양한 조건에 따라 예외를 처리할 수 있음.
 */


// 예외 필터링을 사용하는 방법을 보여줌.

namespace ExceptionFiltering
{
    class FilterableException : Exception // Exception 클래스를 상속받아
                                          // FilterableException이라는 사용자 정의 예외 클래스를 선언합니다.
                                          // ErrorNo라는 정수형 프로퍼티를 정의하여 오류 번호를 저장합니다.
    {
        public int ErrorNo { get; set; }
    }


    class MainApp
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number Between 0~10"); // 0에서 10 사이의 숫자를 입력하라는 메시지 출력
            string input = Console.ReadLine(); // 사용자로부터 입력받은 문자열을 input 변수에 저장 

            try // try 블록: 예외가 발생할 가능성이 있는 코드를 실행합니다.
            {
                int num = Int32.Parse(input); // 입력받은 문자열(input)을 정수로 변환하여 num이라는 변수에 저장
                                              // 만약 input이 숫자 형식이 아니면 FormatException 예외가 발생      

                if (num < 0 || num > 10) // num이 0보다 작거나 10보다 크면,
                    throw new FilterableException() { ErrorNo = num }; // FilterableException 예외를 발생시키고,
                                                                       // ErrorNo 프로퍼티에 num 값을 저장
                else // num이 0에서 10 사이의 값이면,
                    Console.WriteLine($"Output : {num}"); // "Output : {num}"을 출력
            }

            catch (FilterableException e) when (e.ErrorNo < 0) // FilterableException 예외가 발생하고,
                                                               // ErrorNo가 0보다 작으면,
            {
                Console.WriteLine("Negative input is not allowed."); // "Negative input is not allowed." 메시지 출력
            }

            catch (FilterableException e) when (e.ErrorNo > 10) // FilterableException 예외 발생 시,
                                                                // ErrorNo가 10보다 크면,
            {
                Console.WriteLine("Too big number is not allowed."); // "Too big number is not allowed." 메시지 출력
            }
        }
    }
}


/*
출력 결과(15 입력)

Enter Number Between 0~10
15
Too big number is not allowed.
*/

/*
출력 결과(-5 입력)

Enter Number Between 0~10
-5
Negative input is not allowed.
*/

/*
출력 결과(5 입력)

Enter Number Between 0~10
5
Output : 5 */