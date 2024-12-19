using System;


/*
초기화 전용 자동 구현 프로퍼티 : 
접근 한정자, readonly 필드, readonly 구조체, 튜플 등과 같은 데이터 오염 방지 장치.
프로퍼티를 읽기 전용으로 아주 간편하게 선언할 수 있는 방법.
init 접근자를 사용함.
->  set 접근자처럼 외부에서 프로퍼티를 변경할 수 있지만, set과 달리 '객체를 초기화할 때만 프로퍼티 값 변경이 가능'함.

사용 이유?
-> 초기화가 한 차례 이루어진 후 변경되면 안 되는 데이터에 사용.
   예를 들어 금융 거래 기록, 범죄 기록 등..


객체:
클래스의 인스턴스입니다. 즉, 클래스를 기반으로 만들어진 실체입니다. 
객체는 속성과 메서드를 가지고 있으며, 프로그램에서 특정 작업을 수행하는 데 사용됩니다.

프로퍼티: 
클래스의 멤버로, 객체의 데이터에 접근하고 수정하기 위한 방법을 제공합니다. 
프로퍼티는 get 접근자와 set 접근자를 사용하여 구현됩니다. 
get 접근자는 프로퍼티 값을 읽어오는 데 사용되고, set 접근자는 프로퍼티 값을 설정하는 데 사용됩니다.
 */


namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { } // IsExternalInit 클래스: init 접근자를 사용하기 위해 필요한 클래스입니다.
}


namespace InitOnly
{
    class Transaction // Transaction 클래스: 거래 정보를 나타내는 클래스
                      // From, To, Amount 속성은 init 접근자를 사용하여 초기화 전용 자동 구현 속성으로 선언
    {
        public string From { get; init; } // 자동 구현 프로퍼티를 선언하면서 set 접근자 대신 init 접근자를 명시하면 됨.
                                          // 이렇게 선언한 프로퍼티를 '초기화 전용 자동 구현' 프로퍼티라고 함.
        public string To { get; init; }
        public int Amount { get; init; }

        public override string ToString()
        {
            return $"{From,-10} -> {To,-10} : ${Amount}"; // 문자열 보간을 사용하여 From, To, Amount 속성 값을 포함하는 문자열을 생성
                                                          // {From,-10}: From 속성 값을 왼쪽 정렬하고 10칸을 확보
                                                          // {To,-10}: To 속성 값을 왼쪽 정렬하고 10칸을 확보
                                                          // : $: 콜론과 달러 기호를 출력
                                                          // {Amount}: Amount 속성 값을 출력

            // 문자열 보간: 문자열 보간은 $" 문자로 시작하는 문자열 내에 {} 괄호 안에 변수나 식을 넣어 값을 삽입하는 기능
            // $"{From,-10} -> {To,-10} : ${Amount}" 이 코드에서 중괄호 {}는 문자열 보간을 위한 기호로 사용됨.
            // From, To, Amount는 각각 변수 이름이고, 문자열 보간을 통해 이 변수들의 값을 문자열에 삽입
            // 중첩된 문자열 보간이 아니라 단순히 문자열 보간을 세 번 사용한 것


        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            Transaction tr1 = new Transaction { From = "Alice", To = "Bob", Amount = 100 }; // Transaction 객체를 생성하고,
                                                                                            // 객체 초기화자를 사용하여 속성을 초기화
            Transaction tr2 = new Transaction { From = "Bob", To = "Charlie", Amount = 50 };
            Transaction tr3 = new Transaction { From = "Charlie", To = "Alice", Amount = 50 };


            Console.WriteLine(tr1); // Console.WriteLine을 사용하여 각 Transaction 객체의 정보를 출력
            Console.WriteLine(tr2);
            Console.WriteLine(tr3);
        }
    }
}