using System;

namespace Inheritance
{
    class Base // 기본 클래스 선언
    {
        protected string Name; // Name 이라는 필드 선언
        public Base(string Name) // 기본 클래스의 생성자.
                                 // 이 클래스를 상속받는 클래스를 만들 때, 각 클래스의 생성자에서
                                 // Name 필드를 초기화해야 함.
        {
            this.Name = Name;
            Console.WriteLine($"{this.Name}.Base()");
        }

        ~Base()
        {
            Console.WriteLine($"{this.Name}.~Base()");
        }

        public void BaseMethod()
        {
            Console.WriteLine($"{Name}.BaseMethod()");
        }
    }

    class Derived : Base // 파생 클래스
    {
        public Derived(string Name) : base(Name) // 파생클래스의 생성자에서 기본 클래스의 생성자 호출.
        {
            Console.WriteLine($"{this.Name}.Derived()"); // 추가적인 초기화 작업
        }

        ~Derived()
        {
            Console.WriteLine($"{this.Name}.~Derived()");
        }

        public void DerivedMethod()
        {
            Console.WriteLine($"{Name}.DerivedMethod()");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Base a = new Base("a"); // a라는 객체 생성. 
                                    // Base("a") -> 생성자를 호출하여 Name 필드를 "a"로 초기화 함.
                                    // new 키워드를 사용 -> 클래스의 인스턴스를 생성할 때 생성자가 호출됨.

            a.BaseMethod();

            Derived b = new Derived("b");
            b.BaseMethod();
            b.DerivedMethod();
        }
    }
}
