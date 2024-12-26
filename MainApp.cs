using System;


/*
Statement Lambda(문 형식의 람다식):
여러 문장으로 구성된 코드 블록을 델리게이트에 할당할 수 있도록 합니다.
반환 형식이 없는 무명 함수를 만들 수 있습니다.
<-> 식 형식의 람다식: 반환 형식이 없는 무명 함수를 만들 수 없음.
 */


// 문장을 입력하면 스페이스를 모두 지우는 프로그램
namespace StatementLambda
{
    class MainApp
    {
        delegate string Concatenate(string[] args); // Concatenate라는 이름의 델리게이트를 선언합니다.
                                                    // 이 델리게이트는 문자열 배열을 매개변수로 받아 
                                                    // 문자열 값을 반환하는 메서드를 참조할 수 있습니다.

        static void Main(string[] args)
        {

            // Concatenate concat = (arr) => { ... };:
            // concat라는 Concatenate 델리게이트 변수를 선언하고, 문 형식({})의 람다 식을 사용하여 초기화합니다. 
            // 람다 식은 arr 라는 매개변수 목록과 {} 안에 여러 문장으로 구성된 코드 블록으로 구성됩니다.
            Concatenate concat = (arr) =>
                {
                    string result = "";
                    foreach (string s in arr)
                        result += s;

                    return result;
                };

               Console.WriteLine(concat(args)); // concat 델리게이트를 호출하여,
                                                // args 배열을 연결한 결과를 출력합니다.
            
        }
    }
}
