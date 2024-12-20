using System;


/*
with 식을 이용한 레코드 복사:
with 식을 사용하면 레코드 객체의 일부 프로퍼티(속성) 값만 변경하면서 새로운 객체를 쉽게 생성할 수 있습니다. 
이는 불변 객체를 다룰 때 유용하게 사용할 수 있습니다.
*/


/*
클래스 vs 프로퍼티 vs 레코드?

1) 클래스: 객체를 만들기 위한 설계도 또는 틀입니다. 클래스는 객체의 속성(프로퍼티)과 메서드를 정의합니다.
2) 프로퍼티: 객체의 데이터에 접근하고 수정하기 위한 방법을 제공하는 클래스의 멤버입니다. 
             프로퍼티는 get 접근자와 set 접근자를 사용하여 구현됩니다.
3) 레코드: 클래스의 일종입니다. C# 9.0에서 도입된 레코드는 불변성을 기본적으로 지원하는 참조 형식입니다.
           즉, 레코드는 불변성을 지원하는 특수한 클래스.
           레코드는 클래스와 마찬가지로 속성과 메서드를 가질 수 있습니다.
 */


// with 식을 사용하여 레코드 객체를 복사하고 일부 속성 값을 변경하는 방법
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}



namespace WithExp
{

    // RTransaction 레코드는 거래 정보를 나타내는 레코드
    // From, To, Amount 속성은 init 접근자를 사용했으므로, 초기화 전용 자동 구현 속성으로 선언됨
    record RTransaction 
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }

        public override string ToString()
        {
            return $"{From,-10} -> {To,-10} : ${Amount}";
        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            RTransaction tr1 = new RTransaction { From = "Alice", To = "Bob", Amount = 100 }; // RTransaction 레코드의 객체 tr1을 생성

            RTransaction tr2 = tr1 with { To = "Charlie" }; // with 식을 사용하여 tr1 객체를 복사하고,
                                                            // To 프로퍼티 값만 "Charlie"로 수정해서 tr2라는 새로운 레코드 객체를 생성함

            RTransaction tr3 = tr2 with { From = "Dave", Amount = 30 }; // tr2 객체를 복사하고
                                                                        // From 속성 값을 "Dave"로, Amount 속성 값을 30으로 변경한
                                                                        // tr3이라는 새로운 객체를 생성

            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
            Console.WriteLine(tr3);
        }
    }
}


/*
출력 결과

Alice      -> Bob       : $100
Alice      -> Charlie   : $100
Dave       -> Charlie   : $30
 */