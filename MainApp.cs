using System;

namespace MethodHiding
    // 메소드 숨기기: CLR에게 기반 클래스에서 구현된 버전의 메소드를 감추고,
    // 파생 클래스에서 구현된 버전만 보여주는 것.
    // 왜냐하면 어떤 메소드가 향후 오버라이딩될지 안 될지를 판단하는 것이 어렵기 때문에 사용함.
    // 기반 클래스에서는 아무 생각없이 메소들르 구현해도 메소드 숨기기를 하면 오버라이딩과 같은 효과 얻을 수 있음.
{
    class Base
    {
        public void MyMethod()
        {
            Console.WriteLine("Base.MyMethod()");
        }
    }

    class Derived : Base
    {
        public new void MyMethod() // 파생클래스의 메소드를 new 한정자로 수식함으로써 메소드 숨기기 가능.
        {
            Console.WriteLine("Derived.MyMethod()");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Base baseObj = new Base();
            baseObj.MyMethod();

            Derived derivedObj = new Derived();
            derivedObj.MyMethod();

            Base baseOrDerived = new Derived(); // 이렇게 객체를 생성하면 CLR에 Base 버전의 MyMethod가 노출되어 이를 실행함.
            baseOrDerived.MyMethod(); // "Base.MyMethod();" 출력
        }
    }
}
