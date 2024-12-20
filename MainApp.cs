using System;


/*
클래스 vs 레코드

레코드 객체 비교:
컴파일러는 레코드의 상태를 비교하는 Equals() 메소드를 자동으로 구현함.

레코드는 참조 형식이지만, 값 형식처럼 Equals() 메소드를 재정의(오버라이딩)하지 않아도 값이 동등한지 비교가 가능함.


1) 일반적으로 클래스는 참조 형식이기 때문에, Equals() 메서드를 재정의하지 않으면 참조 동등성을 비교합니다. 
즉, 두 객체가 같은 메모리 주소를 참조하는지 여부를 비교합니다.

2) 하지만 레코드는 Equals() 메서드를 자동으로 재정의하여 값 동등성을 비교하도록 구현됩니다. 
즉, 두 레코드 객체의 모든 필드 값이 같은지 여부를 비교합니다.

3) 따라서 레코드는 Equals() 메서드를 재정의하지 않아도 값 동등성 비교가 가능합니다.
 */


// 클래스와 레코드의 동등성 비교에 대한 차이점을 보여줌
namespace RecordComp
{

    // CTransaction 클래스와 RTransaction 레코드는 모두 거래 정보를 나타내는 형식입니다.
    // 둘 다 From, To, Amount 프로퍼티를 가지고 있으며,
    // ToString() 메서드를 재정의하여 거래 정보를 문자열 형태로 반환합니다.
    class CTransaction
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }

        public override string ToString()
        {
            return $"{From,-10} -> {To,-10} : ${Amount}";
        }
    }


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

        // Main 메서드에서는 CTransaction 클래스와 RTransaction 레코드의 객체를 각각 두 개씩 생성합니다.
        // trA와 trB는 CTransaction 클래스의 객체이고,
        // tr1과 tr2는 RTransaction 레코드의 객체입니다.
        // 각 객체는 동일한 값을 가지도록 초기화됩니다. 즉, From은 "Alice", To는 "Bob", Amount는 100입니다.
        static void Main(string[] args)
        {
            CTransaction trA = new CTransaction { From = "Alice", To = "Bob", Amount = 100 };
            CTransaction trB = new CTransaction { From = "Alice", To = "Bob", Amount = 100 };


            // trA와 trB는 모두 CTransaction 클래스의 객체이므로,
            // CTransaction 클래스에 정의된 ToString() 메서드가 호출됩니다.
            // CTransaction 클래스에서는 ToString() 메서드를 재정의하여
            // From, To, Amount 프로퍼티 값을 포함하는 문자열을 반환하도록 했습니다.
            // 따라서 Console.WriteLine(trA);와 Console.WriteLine(trB);는
            // 각 객체의 From, To, Amount 프로퍼티 값을 출력합니다.

            Console.WriteLine(trA); // trA 객체의 ToString() 메서드를 호출하여, trA 객체의 정보를 출력
            Console.WriteLine(trB); // trB 객체의 ToString() 메서드를 호출하여, trB 객체의 정보를 출력
           
            Console.WriteLine($"trA equals to trB : {trA.Equals(trB)}"); // trA와 trB 객체의 동등성을 비교합니다. 
                                                                         // Equals() 메서드는 두 객체가 같은지 여부를 판별하는 메서드.
                                                                         // CTransaction은 클래스이므로,
                                                                         // Equals() 메서드는 '참조' 동등성을 비교합니다.
                                                                         // 즉, 두 객체가 같은 메모리 주소를 참조하는지 여부를 비교합니다.
                                                                         // trA와 trB는 서로 다른 객체이므로, 
                                                                         // trA.Equals(trB)는 false를 반환합니다.


            RTransaction tr1 = new RTransaction { From = "Alice", To = "Bob", Amount = 100 };
            RTransaction tr2 = new RTransaction { From = "Alice", To = "Bob", Amount = 100 };


            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
            
            Console.WriteLine($"tr1 equals to tr2 : {tr1.Equals(tr2)}"); // tr1와 tr2 객체의 동등성을 비교합니다.
                                                                         // RTransaction은 레코드이므로, 
                                                                         // Equals() 메서드는 '값' 동등성을 비교합니다. 
                                                                         // 즉, 두 객체의 모든 필드 값이 같은지 여부를 비교합니다.
                                                                         // tr1과 tr2는 모든 필드 값이 같으므로,
                                                                         // tr1.Equals(tr2)는 true를 반환합니다.
        }
    }
}


/*
출력 결과

Alice      -> Bob       : $100
Alice      -> Bob       : $100
trA equals to trB : False
Alice      -> Bob       : $100
Alice      -> Bob       : $100
tr1 equals to tr2 : True
 */


/*
레코드는 참조 형식이지만, 값 형식처럼 Equals() 메소드를 구현하지 않아도 값이 동등한지 비교가 가능함은 맞는 얘기?

네, 맞는 얘기입니다. 
레코드는 참조 형식이지만, 값 형식처럼 `Equals()` 메서드를 재정의하지 않아도 값 동등성 비교가 가능합니다. 
일반적으로 클래스는 참조 형식이기 때문에, `Equals()` 메서드를 재정의하지 않으면 참조 동등성을 비교합니다. 
즉, 두 객체가 같은 메모리 주소를 참조하는지 여부를 비교합니다. 
하지만 레코드는 `Equals()` 메서드를 자동으로 재정의하여 값 동등성을 비교하도록 구현됩니다. 
즉, 두 레코드 객체의 모든 필드 값이 같은지 여부를 비교합니다. 

따라서 레코드는 `Equals()` 메서드를 재정의하지 않아도 값 동등성 비교가 가능합니다.

**예시**

```C#
record Person
{
    public string Name { get; init; }
    public int Age { get; init; }
}

Person person1 = new Person { Name = "John", Age = 30 };
Person person2 = new Person { Name = "John", Age = 30 };

Console.WriteLine(person1.Equals(person2)); // 출력: True
```

이 코드에서 `person1`과 `person2`는 서로 다른 객체이지만, 모든 필드 값이 같기 때문에 `Equals()` 메서드는 `true`를 반환합니다.

레코드는 값 동등성 비교를 기본적으로 지원하기 때문에, 불변 객체를 다룰 때 유용하게 사용할 수 있습니다.
 */