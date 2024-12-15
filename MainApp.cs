using System;

/* 오버라이딩 봉인: 파생 클래스의 작성자를 위한 기반 클래스 작성자의 배려.
 파생 클래스의 작성자가 기반 클래스로부터 상속받은 메소드 하나를 오버라이딩 한 뒤,
 이 때문에 오작동하게 된다면, 파생 클래스 작성자는 그 오작동의 원인을 알 길이 없음.
 오버라이딩을잘못 해서 문제가 발생할 수 있다면, 봉인 메소드를 이용해서 상속을 사전에 막는 것이 나음.
 컴파일할 때 에러가 나오기 때문. */

class Base
{
    public virtual void SealMe() // virtual로 선언된 가상 메소드
    {
    }
}

class Derived : Base
{
    public sealed override void SealMe() // virtual로 선언된 가상 메소드를 오버라이딩한 메소드에서만
                                         // 이렇게 오버라이딩되지 않도록 sealed 키워드를 이용해서 봉인 가능.
    {
    }
}

class WantToOverride : Derived
{
    public override void SealMe() // 'WantToOverride.SealMe()': 상속된 'Derived.SealMe()' 멤버는 봉인되어 있으므로 재정의할 수 없습니다.
    {
    }
}

class MainApp
{
    static void Main(string[] args)
    {
    }
}
