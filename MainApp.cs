using System;
using System.Xml.Linq;


/*
인터페이스의 프로퍼티:
인터페이스에 프로퍼티를 선언하면, 해당 인터페이스를 구현하는 모든 클래스는 해당 프로퍼티를 구현해야 합니다. 

인터페이스는 프로퍼티의 get 및 set 접근자를 선언하지만, 구현은 제공하지 않습니다.
인터페이스를 구현하는 클래스는 인터페이스에 선언된 모든 프로퍼티를 구현해야 합니다.(메소드와 동일)
인터페이스의 프로퍼티는 클래스 간의 계약을 정의하는 데 사용됩니다.
 */


// 인터페이스에 프로퍼티를 선언하고, 
// 해당 인터페이스를 구현하는 클래스에서 프로퍼티를 구현하는 방법을 보여줌
namespace PropertiesInInterface
{

    // INamedValue 인터페이스는 Name과 Value라는 두 개의 문자열 프로퍼티를 선언
    // 인터페이스는 프로퍼티의 get 및 set 접근자를 선언하지만,
    // 인터페이스이므로 인터페이스의 프로퍼티에 대해서 구현은 제공하지 않습니다.
    // 즉, 자동 구현 프로퍼티 모습이랑 똑같아도 컴파일러가 자동으로 구현해주지 않음. 
    interface INamedValue 
    {
        string Name
        {
            get;
            set;
        }

        string Value
        {
            get;
            set;
        }
    }


    // NamedValue 클래스:
    // INamedValue 인터페이스를 상속하는 클래스.
    // 따라서 NamedValue 클래스는 반드시 Name 프로퍼티와 Value 프로퍼티를 구현해야 함.
    // 아래와 같이 자동구현 프로퍼티를 이용하여 구현하는 것도 가능함.
    class NamedValue : INamedValue
    {
        public string Name // Name 프로퍼티는 컴파일러에 의해 자동으로 구현됨.
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }


    class MainApp
    {

        // Main 메서드에서는 NamedValue 클래스의 객체를 세 개 생성합니다. 
        // 각 객체는 이름과 값을 나타내는 프로퍼티를 가지며, 
        // 객체 초기화 구문을 사용하여 프로퍼티에 값을 할당합니다.
        static void Main(string[] args)
        {
            NamedValue name = new NamedValue() // NamedValue 클래스의 객체를 생성하고,
                                               // Name 프로퍼티와 Value 프로퍼티에 값을 할당합니다.
            { Name = "이름", Value = "박상현" };

            NamedValue height = new NamedValue()
            { Name = "키", Value = "177Cm" };

            NamedValue weight = new NamedValue()
            { Name = "몸무게", Value = "90Kg" };


            // Console.WriteLine을 사용하여 각 객체의 Name 프로퍼티와 Value 프로퍼티 값을 출력합니다.
            Console.WriteLine("{0} : {1}", name.Name, name.Value);
            Console.WriteLine("{0} : {1}", height.Name, height.Value);
            Console.WriteLine("{0} : {1}", weight.Name, weight.Value);
        }
    }
}

/*
출력 결과

이름 : 박상현
키 : 177Cm
몸무게 : 90Kg
 */