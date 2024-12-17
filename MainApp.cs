using System;
using AbstractClass;


/*
추상 클래스:
구현을 가질 수 있으나, 클래스와 달리 인스턴스를 가질 수 없음. 
객체를 직접 생성할 수 없는 클래스로, 파생 클래스에서 상속받아 사용해야 함.
abstract 한정자와 class 키워드를 이용해서 선언.

-> 클래스와 차이점:
직접 인스턴스를 가질 수 없음.
추상 메소드를 가질 수 있음.

추상 메소드:
구현을 갖지 못하지만, 추상 클래스를 상속하는 파생 클래스에서 반드시 이 메소드를 구현하도록 강제함.
즉, 추상 클래스가 '인터페이스의 역할'도 할 수 있게 해주는 장치.
-> 따라서 접근자는 private가 될 수 없도록 c# 컴파일러가 강제함.
abstract 한정자로 선언.


추상 클래스의 장점:
공통적인 기능을 추상 클래스에 정의하고, 파생 클래스에서 세부적인 기능을 구현할 수 있습니다.
파생 클래스에서 특정 메서드를 반드시 구현하도록 강제할 수 있습니다.
코드의 재사용성을 높이고 유지보수를 용이하게 합니다.
 */

namespace AbstractClass 
{

    // 추상 클래스 정의
    abstract class AbstractBase // 추상 클래스
                                // abstract 키워드를 사용하여 AbstractBase를 추상 클래스로 선언
    {
        protected void PrivateMethodA() // protected 접근 제한자를 가진 메서드. 파생 클래스에서 접근 가능.
        {
            Console.WriteLine("AbstractBase.PrivateMethodA()");
        }

        public void PublicMethodA() // public 접근 제한자를 가진 메서드
        {
            Console.WriteLine("AbstractBase.PublicMethodA()");
        }

        public abstract void AbstractMethodA(); // 추상 메소드
                                                // abstract 키워드를 사용하여 추상 메서드로 선언.
                                                // 추상 메소드는 구현 코드가 없으며(이렇게 비워놔야 함),
                                                // 파생 클래스에서 반드시 재정의(오버라이딩)해야 합니다.
    }


    // 파생 클래스 정의
    class Derived : AbstractBase // 파생 클래스
                                 // Derived: AbstractBase 클래스를 상속받는 클래스
    {
        public override void AbstractMethodA() // 추상 메소드 구현
                                               // (구현=재정의=오버라이딩)
                                               // override 키워드를 사용하여 기본 클래스의 추상 메서드를 재정의함.
        {
            Console.WriteLine("Derived.AbstractMethodA()");
            PrivateMethodA(); // 기본 클래스의 protected 메서드를 호출함.
        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            AbstractBase obj = new Derived(); // AbstractBase 타입의 변수 obj를 선언하고 Derived 클래스의 객체를 할당합니다. 
                                              // 추상 클래스는 직접 객체를 생성할 수 없지만, 파생 클래스의 객체를 할당할 수 있음.
                                              // Derived 클래스의 객체를 생성하고 AbstractBase 타입으로 변환

            obj.AbstractMethodA(); // obj 변수를 통해 AbstractMethodA() 메서드를 호출합니다.
                                   // Derived 클래스에서 재정의된 AbstractMethodA() 메서드가 실행됩니다.

            obj.PublicMethodA(); // obj 변수를 통해 PublicMethodA() 메서드를 호출합니다.
                                 // AbstractBase 클래스에 정의된 메서드가 실행됩니다.
        }
    }
}


/*출력:
Derived.AbstractMethodA()
AbstractBase.PrivateMethodA()
AbstractBase.PublicMethodA()
*/