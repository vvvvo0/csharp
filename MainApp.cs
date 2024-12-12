using System;

namespace Hello
{
    class Mainapp
    {
        class Cat // 클래스 선언, 모든 클래스는 복합 데이터 형식임. 그리고 복합 데이터 형식은 참조 형식임.
        {
            public string Name; // 필드: Name, Color 처럼 클래스 안에 선언된 변수들
            public string Color;

            public void Meow() //메소드
            {
                Console.WriteLine($"{Name} : 야옹");
            }
        }

        class MainApp
        {
            static void Main(string[] args)
            {
                Cat kitty = new Cat(); // kitty 객체 생성,
                                       // new키워드: 객체 생성에 사용하는 연산자
                                       // Cat(): 생성자 메소드
                                       // 매개변수가 없는 버전의 Cat() 생성자는 컴파일러가 자동으로 생성해준
                                       // 생성자를 호출할 때처럼 사용
                kitty.Color = "하얀색";
                kitty.Name = "키티";
                kitty.Meow();
                Console.WriteLine($"{kitty.Name} : {kitty.Color}");

                Cat nero = new Cat();
                nero.Color = "검은색";
                nero.Name = "네로";
                nero.Meow();
                Console.WriteLine($"{nero.Name} : {nero.Color}");
            }
        }
    }
}

// 형식은 같으나 인수의 개수만 유연하게 달라지는 경우 적합.
