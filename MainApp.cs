using System;


/*
인터페이스의 다중 상속: 
여러 인터페이스를 다중 상속하는 클래스 사용 가능.
즉, 클래스는 여러 개의 인터페이스를 상속 받아 여러 인터페이스의 기능을 동시에 구현할 수 있음.

-> 왜냐하면 인터페이스는 내용이 아닌 외형을 물려줌.
따라서 죽음의 다이아몬드 같은 문제 발생 x

<-> 클래스는 여러 클래스를 한꺼번에 상속할 수 없음.
     -> 왜냐하면 프로그램이 어떻게 동작할지 정확하게 예측할 수 없는 모호성이 발생하기 때문에!
      1) 죽음의 다이아몬드 문제
      2) 업캐스팅 문제
 */


namespace MultiInterfaceInheritance
{

    // IRunnable: Run() 메서드를 정의하는 인터페이스
    interface IRunnable
    {
        void Run();
    }


    // IFlyable: Fly() 메서드를 정의하는 인터페이스
    interface IFlyable
    {
        void Fly();
    }


    // FlyingCar: IRunnable과 IFlyable 인터페이스를 모두 상속받는 클래스
    // Run() 메서드와 Fly() 메서드를 구현
    class FlyingCar : IRunnable, IFlyable
    {
        public void Run()
        {
            Console.WriteLine("Run! Run!");
        }

        public void Fly()
        {
            Console.WriteLine("Fly! Fly!");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            FlyingCar car = new FlyingCar(); // FlyingCar 클래스의 객체를 생성해서 car라는 변수에 참조값 저장
                                             // car 변수가 FlyingCar 객체를 나타낸다 !
            car.Run(); // car 변수를 통해 FlyingCar 객체에 접근하여 FlyingCar 객체의 메소드를 호출
                       // car 객체의 Run() 메서드를 호출하여 "Run! Run!"을 출력
            car.Fly();

            IRunnable runnable = car as IRunnable; // FlyingCar 타입인 car 객체를 IRunnable 인터페이스 타입으로 '형변환'하여, runnable 변수에 할당합니다.
                                                   // : FlyingCar 타입( IRunnable과 IFlyable 인터페이스의 기능 모두를 가지고 있음)인 car 객체를
                                                   //   IRunnable 타입으로 형변환하면,
                                                   //   car 객체가 FlyingCar 클래스의 객체라는 것을 잊고
                                                   //   IRunnable 인터페이스의 기능만 사용할 수 있습니다.

            runnable.Run(); // 즉, 이렇게 runnable 변수를 통해 Run() 메서드를 호출하면,
                            // FlyingCar 클래스에서 구현한 Run() 메서드가 실행됩니다.
                            // 따라서 runnable.Fly();를 입력하면 아래와 같은 오류 발생!
                            // 오류: 'IRunnable'에는 'Fly'에 대한 정의가 포함되어 있지 않고, 
                            // 'IRunnable' 형식의 첫 번째 인수를 허용하는 액세스 가능한 확장 메서드 'Fly'이(가) 없습니다.
                            // using 지시문 또는 어셈블리 참조가 있는지 확인하세요.


            IFlyable flyable = car as IFlyable; // as 연산자를 사용하여 car 객체를 IFlyable 인터페이스 타입으로 형변환하고, flyable 변수에 할당함.
            flyable.Fly(); // flyable 변수를 통해 car 객체의 Fly() 메서드를 호출할 수 있음.
        }
    }
}


/*
왜 형변환을 할까?

형변환을 하는 이유는 다형성을 활용하기 위해서. 다형성은 같은 이름의 메서드가 여러 클래스에서 다르게 동작하는 것을 의미.

IRunnable 인터페이스는 Run() 메서드를 정의하고 있지만, Run() 메서드의 구체적인 내용은 IRunnable 인터페이스를 구현하는 각 클래스에서 다르게 정의할 수 있음.

car 객체를 IRunnable 타입으로 형변환하면, car 객체가 FlyingCar 클래스의 객체라는 것을 잊고 IRunnable 인터페이스의 기능만 사용할 수 있습니다.

즉, runnable 변수를 통해 Run() 메서드를 호출하면, FlyingCar 클래스에서 구현한 Run() 메서드가 실행됩니다.
 */