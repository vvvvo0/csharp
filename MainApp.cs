using System;
using System.Collections;


/*
yield 키워드:
반복기(Enumerator)를 생성하는 데 사용되며, foreach 문에서 사용할 수 있는 시퀀스를 생성합니다.


foreach 문 vs for 문?
foreach 문은 for 문 보다 편하고 읽기 좋음.
for 문처럼 요소의 위치를 위한 인덱스 변수를 선언하지 않아도 됨.
세미콜론을 2개 넣지 않아도 되고, 조건문이나 증감식을 쓰지 않아도 됨.

foreach 문은 배열이나 리스트 같은 컬렉션에서만 사용할 수 있음.
foreach 문은 IEnumerable 인터페이스를 상속하는 형식만 직원함.
따라서 IEnumerable 인터페이스를 상속하기만 하면 foreach 문을 이용해서 요소를 순회할 수 있음.
IEnumerable 인터페이스가 갖고 있는 메서드는 IEnumerator GetEnumerator() 딱 한 개밖에 없음.

GetEnumerator() 메서드는 IEnumerator 인터페이스를 상속하는 클래스의 객체를 반환해야 하는데,
'yield 문'을 이용하면 IEnumerator를 상속하는 클래스를 따로 구현하지 않아도, 
컴파일러가 자동으로 IEnumerator 인터페이스를 구현한 클래스를 생성해줍니다.
 */


// yield 키워드를 사용하여 반복기(Enumerator)를 구현하는 방법을 보여줌
namespace Yield
{
    class MyEnumerator
    {
        int[] numbers = { 1, 2, 3, 4 }; // 4개의 정수 값을 가진 numbers 배열을 선언하고 초기화합니다.
        public IEnumerator GetEnumerator() // IEnumerator 인터페이스를 구현하는 GetEnumerator() 메서드를 정의합니다.
                                           // GetEnumerator() 메서드: yield return 문을 사용하여 numbers 배열의 요소를 반환합니다.
                                           // yield return 문: 
                                           // 현재 메소드(GetEnumerator())의 실행을 일시 정지해놓고 호출자에게 결과를 반환합니다.
                                           // 메소드가 다시 호출되면, 일시 정지된 실행을 복구하여 yield return 문 또는 yield break 문을
                                           // 만날 때까지 나머지 작업을 실행합니다.

        {
            yield return numbers[0]; // numbers 배열의 첫 번째 요소를 반환합니다.
            yield return numbers[1]; // numbers 배열의 두 번째 요소를 반환합니다.
            yield return numbers[2]; // numbers 배열의 세 번째 요소를 반환합니다.
            yield break; // yield break문: 반복을 종료합니다.
            yield return numbers[3]; // numbers 배열의 네 번째 요소를 반환합니다. 
                                     // 이 문은 yield break; 때문에 실행되지 않습니다.
        }
    }


    class MainApp
    {

        static void Main(string[] args)
        {
            var obj = new MyEnumerator(); // MyEnumerator 클래스의 객체 obj를 생성합니다.

            foreach (int i in obj) // obj 객체를 foreach 문에서 사용합니다.
                                   // obj 객체는 GetEnumerator() 메서드를 통해 Enumerator(반복기)를 반환합니다.
                Console.WriteLine(i); // 현재 요소를 출력합니다.
        }
    }
}


/*
출력 결과

1
2
3
*/