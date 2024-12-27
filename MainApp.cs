using System;
using System.Linq;


/*
LINQ:
Language Integrated Query의 약자로, C#에 톱합된 데이터 질의 기능임.
데이터 질의(Query)란, 데이터에 대해 물어본다는 의미.
데이터를 가공하기 전에 필요한 데이터를 찾아내는 일을 도와줌.
컬렉션을 편리하게 다루기 위한 목적으로 만들어진 질의(Query) 언어.
*/


// LINQ를 사용하여 정수 배열에서 짝수를 찾아 오름차순으로 정렬
namespace From
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 }; 
            // 10개의 정수 값을 가진 numbers 배열을 선언하고 초기화합니다.

            var result = from n in numbers // numbers 배열(데이터 원본) 안에 있는 각 요소를
                                           // n이라는 변수(범위 변수)에 할당하며 쿼리를 시작합니다.
                         where n % 2 == 0 // n을 2로 나눈 나머지가 0인 경우(즉, 짝수인 경우)에만, 요소를 선택합니다.
                         orderby n // 선택된 요소를 n 값을 기준으로 오름차순으로 정렬합니다.
                         select n; // 정렬된 요소를 선택하여 result 변수에 저장합니다.

            foreach (int n in result) // result에 저장된 요소를 순회하며 각 요소를 n이라는 변수에 할당합니다.
                Console.WriteLine($"짝수 : {n}"); // n 값을 "짝수 : {n}" 형식으로 출력합니다.
        }
    }
}


/*
출력 결과

짝수 : 2
짝수 : 4
짝수 : 6
짝수 : 8
짝수 : 10
*/