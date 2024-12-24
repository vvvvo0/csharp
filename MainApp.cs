using System;


/*
throw 식: 
예외를 발생시키는 방법.
C# 7.0에서 도입된 기능으로, 
조건 연산자 안에서도 예외를 발생시킬 수 있습니다.

throw 식의 장점?
-코드를 간결하게 작성할 수 있습니다.
-조건부로 예외를 발생시킬 수 있습니다.
-식 내에서 예외를 발생시킬 수 있으므로, 코드의 가독성을 높일 수 있습니다.
 */


// throw 식을 사용하여 예외를 발생시키는 방법.
namespace ThrowExpression
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 첫 번째 try-catch 문
            try
            {
                int? a = null; // Nullable int 형식의 변수 a를 선언하고, null로 초기화합니다.
                               // ? 연산자: Nullable 형식을 선언할 때 사용하는 연산자.
                               // 일반적으로 int와 같은 값 형식은 null 값을 가질 수 없습니다, 
                               // 하지만 int?와 같이 Nullable 형식으로 선언하면 null 값을 가질 수 있습니다.
                int b = a ?? throw new ArgumentNullException(); // a가 null이 아니면 a의 값을 b에 할당하고,
                                                                // a가 null이면 ArgumentNullException 예외를 발생시킵니다.
                                                                // ?? 연산자: null 병합 연산자로,
                                                                // 왼쪽 피연산자가 null인지 평가합니다.
                                                                // 왼쪽 피연산자(a)가 null이 아니면 왼쪽 피연산자를 반환하고, 
                                                                // 왼쪽 피연산자(a)가 null이면 오른쪽 피연산자를 반환합니다.

            }

            catch (ArgumentNullException e) // ArgumentNullException 타입의 예외를 catch하고,
                                            // 발생한 예외 객체를 e 변수에 할당합니다. 
                                            // e 변수에 예외 객체를 할당하면?
                                            // catch 블록 내에서 e 변수를 사용하여
                                            // 예외 정보에 접근할 수 있습니다. 
                                            // 예를 들어, e.Message를 사용하여 예외 메시지를 출력하거나,
                                            // e.StackTrace를 사용하여 예외가 발생한 위치를 확인할 수 있습니다.
                                            // catch 블록에서 예외 객체를 변수에 할당하지 않으면,
                                            // 예외 정보를 활용할 수 없게 됩니다. 
                                            // ArgumentNullException:
                                            // .NET Framework에서 제공하는 예외 클래스 중 하나로,
                                            // 메서드에 전달된 인자가 null인 경우 발생하는 예외다.
            {
                Console.WriteLine(e); // 예외 객체 e를 출력합니다.
            }


            // 두 번째 try-catch 문
            try
            {
                int[] array = new[] { 1, 2, 3 }; // 크기가 3인 정수형 배열 array를 선언하고 초기화합니다.
                int index = 4; // index 변수에 4를 할당합니다.
                int value = array // array 배열에서 index에 해당하는 요소를 가져와 value 변수에 할당합니다.
                    [
                    index >= 0 && index < 3
                    ? index : throw new IndexOutOfRangeException()
                    ]; // index가 0보다 크거나 같고 3보다 작으면 index를 반환하고,
                       // 그렇지 않으면 IndexOutOfRangeException 예외를 발생시킵니다.
            }
            catch (IndexOutOfRangeException e) // IndexOutOfRangeException 예외를 catch하고,

            {
                Console.WriteLine(e); // 예외 객체 e를 출력합니다.
            }
        }
    }
}


/*
출력 결과

System.ArgumentNullException: Value cannot be null.
   at ThrowExpression.MainApp.Main(String[] args) in C:\Users\M\source\repos\Hello\MainApp.cs:line 31
System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at ThrowExpression.MainApp.Main(String[] args) in C:\Users\M\source\repos\Hello\MainApp.cs:line 62
*/