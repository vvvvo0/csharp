using System;


/*
레코드 형식: 
값 형식처럼 다룰 수 있는 불변 참조 형식.
참조 형식의 비용 효율과,
값 형식의 편리함을 모두 제공.

record 키워드와 초기화 전용 자동 구현 프로퍼티(읽기 전용 프로퍼티 간편 선언 방법)를 함께 이용해서 선언함.
레코드에는 쓰기 가능한 프로퍼티와 필드도 자유롭게 선언해서 넣을 수 있음.
이렇게 선언한 레코드로 인스턴스를 만들면 불변 객체가 만들어짐.

즉, 레코드 형식의 객체는 생성 후에는 값을 변경할 수 없습니다.

불변객체:
내부 데이터(상태)를 변경할 수 없는 객체.
데이터 복사와 비교할 때 많이 사용.


불변 객체 만드는 방법?
1) 참조 형식: 클래스의 모든 필드를 readonly로 선언
2) 값 형식: readonly struct로 구조체를 선언(컴파일러가 모든 필드를 readonly로 선언하도록 강제함)

객체를 다른 객체에 할당 할 때 복사되는 방식?
1) 참조형식: 참조 형식 객체는 다른 객체에 할당 할 때 -> 얕은 복사( 객체가 참조하는 메모리 주소만 복사함 )
2) 값 형식: 값 형식 객체는 다른 객체에 할당할 때 -> 깊은 복사 ( 모든 필드를 새 객체가 가진 필드에 1:1로 복사함 )

결과?
1) (비용 효율): 불변 객체를 '참조 형식'으로 선언하면 복사 비용을 줄일 수 있음. 
2) (편리함): 불변 객체는 데이터(상태) 표현과 데이터(상태) 확인을 위해 ,깊은 복사와 내용 비교가 필수적임.
-> 따라서 불변 객체를 '값 형식'으로 선언하면 프로그래머는 편리함. 


레코드 형식의 장점?
1) 불변성: 레코드 형식의 객체는 생성 후에는 값을 변경할 수 없습니다.
2) 간결성: record 키워드를 사용하면 불변 클래스를 간결하게 정의할 수 있습니다.
3) 값 비교: 레코드 형식의 객체는 값 비교를 지원합니다. 즉, 두 레코드 객체의 모든 필드 값이 같으면 두 객체는 같은 것으로 간주됩니다.
*/


namespace Record
{

    // RTransaction 레코드: 거래 정보를 나타내는 레코드
    // From, To, Amount 속성은 init 접근자를 사용하여 초기화 전용 자동 구현 속성으로 선언됨
    record RTransaction
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }

        public override string ToString() // RTransaction 레코드에서 ToString() 메서드를 재정의함
                                          // ToString() 메서드는 거래 정보를 문자열 형태로 반환함

                                          // ToString() 메서드:: .NET의 모든 객체에 기본적으로 정의되어 있는 메서드로,
                                          // 객체를 문자열로 표현하는 역할을 함
                                          // override 키워드는 기본 클래스 또는 레코드에서 상속받은 메서드를 재정의할 때 사용됨

                                          // RTransaction 레코드에서 ToString() 메서드를 재정의하여 
                                          // RTransaction 객체를 문자열로 표현하는 방법을 사용자 정의했습니다.
                                          

        {
            return $"{From,-10} -> {To,-10} : ${Amount}"; // 문자열 보간을 사용하여 From, To, Amount 속성 값을 포함하는 문자열을 반환하도록
                                                          // ToString() 메서드를 재정의

            // RTransaction 객체를 Console.WriteLine()과 같은 메서드에서 출력할 때, 사용자 정의된 형식의 문자열로 출력됩니다.
        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            RTransaction tr1 = new RTransaction // RTransaction 레코드의 객체를 생성하고,
                                                // 객체 초기화자를 사용하여 속성을 초기화함
            {
                From = "Alice",
                To = "Bob",
                Amount = 100
            };

            RTransaction tr2 = new RTransaction
            {
                From = "Alice",
                To = "Charlie",
                Amount = 100
            };


            // Console.WriteLine을 사용하여 각 RTransaction 객체의 정보를 출력함
            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
        }
    }
}
