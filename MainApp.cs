using System;
using System.Linq;


/*
LINQ:
Language Integrated Query의 약자로, C#에 톱합된 데이터 질의 기능임.
데이터 질의(Query)란, 데이터에 대해 물어본다는 의미.
데이터를 가공하기 전에 필요한 데이터를 찾아내는 일을 도와줌.
컬렉션을 편리하게 다루기 위한 목적으로 만들어진 질의(Query) 언어.

from:
모든 LINQ 쿼리식(Query Expression)은 반드시 form 절로 시작합니다.
쿼리식의 대상이 될 데이터 원본(Data Source)과 
데이터 원본 안에 들어 있는 각 요소 데이터를 나타내는 범위 변수(Range Variable)를 
from 절에서 지정해줘야 합니다.
from 절을 이용해서 데이터 원본으로부터 범위 변수를 뽑아낸 후에, 
LINQ가 제공하는 연산자(where, orderby, select 등)를 이용해서 데이터를 가공 및 추출할 수 있습니다.

from 절의 '데이터 원본':
IEnumerable<T> 인터페이스를 상속하는 형식이어야만 합니다.
배열이나 컬렉션 객체들은 IEnumerable<T> 인터페이스를 상속하기 때문에
from 절의 데이터 원본으로 사용할 수 있습니다.

from 절의 '범위 변수':
쿼리 변수(Query Variable)라고도 하는데, foreach 문의 반복 변수를 생각하면 이해하기 쉬움.
foreach(int x in arr)에서 x.

LINQ의 '범위 변수' vs foreach 문의 '반복 변수'?
foreach 문의 반복 변수는 데이터 원본으로부터 데이터를 담아내는 반면,
범위 변수는 실제로 데이터를 담지는 않음.
그래서 쿼리식 외부에서 선언된 변수에, 범위 변수의 데이터를 복사해 넣는 등의 일은 할 수 없음.
범위 변수는 오로지 LINQ 질의 안에서만 통용되며, 
질의가 실행될 떄 어떤 일이 일어날지를 묘사하기 위해 도입되었기 때문.
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