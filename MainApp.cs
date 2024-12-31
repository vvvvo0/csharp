using System;


/*
dynamic 형식:
데이터 형식임.
다만 형식 검사를 하는 시점이 프로그램 실행 중입니다.
(즉, dynamic 형식으로 선언하면 형식 검사를 실행할 때로 미룹니다.)

duck typing(덕 타이핑):
'OOP'에서는 C#에서 어떤 형식이 오리(Duck)라고 인정 받으려면, 그 형식의 조상 중에 오리가 있어야 합니다.
반면, '덕 타이핑'에서 어떤 형식이 오리로 인정받으려면, 오리처럼 걷고, 오리처럼 헤엄치고, 오리처럼 꽉꽉거리기만 하면 됩니다.
그 형식이 어느 형식으로부터 상속받는지는 중요하지 않습니다.

덕 타이핑 사용하는 이유?
인터페이스 상속을 사용해도 비슷한 일을 할 수 있지만,
인터페이스를 설계하기 위해서는 추상화를 잘해야 하는데, 추상화를 잘하기 쉽지 않습니다.
인터페이스를 잘못 설계했다가 나중에 파생 클래스를 수정해야 할 일이 생기면,
위로는 인터페이스를 수정하고, 아래로는 자신의 파생 클래스들, 옆으로는 형제 클래스들을 줄줄이 수정해야 하는 일이 생깁니다.
'덕 타이핑'은 이런 문제를 좀 더 유연하게 해결할 수 있도록 돕습니다.
'덕 타이핑'은 상속 관계를 이용하지 않기 때문에 프로그램의 동작에 관여한느 부분만 손을 대면 되기 때문입니다.

덕 타이핑의 장점:
코드의 유연성을 높일 수 있습니다.
객체 간의 결합도를 낮출 수 있습니다.
다양한 타입의 객체를 동일한 방식으로 처리할 수 있습니다.

덕 타이핑의 단점:
컴파일 시점에 타입 검사를 수행하지 않으므로, 런타임 오류가 발생할 가능성이 높습니다.
코드의 가독성을 떨어뜨릴 수 있습니다.
비쥬얼 스튜디오의 '리팩터링 기능'을 이용할 수 없습니다.
(예를 들어 Walk() 메서드의 이름을 Run()으로 고치고 싶어도, 프로그래머가 직접 Walk() 메서드를 선언한 곳과
사용하고 있는 곳을 코드에서 찾아 수정해야 합니다. 
인터페이스를 사용했다면 비쥬얼 스튜디오를 이용해서 단번에, 자동으로 이 일을 할 수 있습니다.)
 */


// 동적 타입(dynamic)을 사용하여 덕 타이핑(duck typing)을 구현
namespace DuckTyping
{
    class Duck // Walk, Swim, Quack 메서드를 가진 클래스입니다.
    {
        public void Walk()
        { Console.WriteLine(this.GetType() + ".Walk"); }

        public void Swim()
        { Console.WriteLine(this.GetType() + ".Swim"); }

        public void Quack()
        { Console.WriteLine(this.GetType() + ".Quack"); }
    }


    class Mallard : Duck // Duck 클래스를 상속받는 클래스입니다.
    { }


    class Robot // Walk, Swim, Quack 메서드를 가진 클래스입니다.
                // Duck 클래스와는 상속 관계가 없습니다.
    {
        public void Walk()
        { Console.WriteLine("Robot.Walk"); }

        public void Swim()
        { Console.WriteLine("Robot.Swim"); }

        public void Quack()
        { Console.WriteLine("Robot.Quack"); }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            dynamic[] arr = new dynamic[] { new Duck(), new Mallard(), new Robot() };
            // dynamic 타입의 배열 arr을 선언하고, Duck, Mallard, Robot 객체를 요소로 추가합니다.
            // dynamic 타입은 런타임에 타입 검사를 수행하므로, 컴파일 시점에 객체의 타입을 알 필요가 없습니다.
            // 만약, Duck[] arr = new Duck[] { new Duck(), new Mallard(), new Robot() }; 라고 했다면,
            // C# 컴파일러는 Robot은 오리로 인정하지 않기 때문에,
            // 컴파일러는 Robot은 Duck 형식이 아니라고 에러 메시지를 보여줍니다.
            // 즉, 오리처럼 걷고 헤엄치고 꽉꽉거리더라도 컴파일러는 그렇게 생각하지 않습니다.
            // 이런 문제를 dynamic 형식으로 선언하여 해결한 것입니다.
            // dynamic 형식으로 선언하면, 형식 검사를 실행할 때로 미루기 때문입니다.

            foreach (dynamic duck in arr) // arr 배열의 각 요소를 duck 변수에 할당하며 반복합니다.
            {
                Console.WriteLine(duck.GetType()); // duck 객체의 타입을 출력합니다.

                // duck 객체의 Walk, Swim, Quack 메서드를 호출합니다.
                // 덕 타이핑을 사용하면 duck 객체의 실제 타입에 관계없이 동일한 방식으로 메서드를 호출할 수 있습니다.
                duck.Walk();
                duck.Swim();
                duck.Quack();

                Console.WriteLine();
            }
        }
    }
}


/*
출력 결과

DuckTyping.Duck
DuckTyping.Duck.Walk
DuckTyping.Duck.Swim
DuckTyping.Duck.Quack

DuckTyping.Mallard
DuckTyping.Mallard.Walk
DuckTyping.Mallard.Swim
DuckTyping.Mallard.Quack

DuckTyping.Robot
Robot.Walk
Robot.Swim
Robot.Quack
 */