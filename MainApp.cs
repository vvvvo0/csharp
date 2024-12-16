using System;


/*
인터페이스: 
인스턴스를 가질 수 없지만, 인터페이스를 상속받는 클래스의 인스턴스를 만드는 것 가능.
파생 클래스는 인터페이스에 선언된 모든 메소드 및 프로퍼티를 구현해야 함. (인터페이스는 '약속'이다!)
이 메소드들은 public 한정자로 수식해야 함.

인터페이스 장점?
다형성: 
인터페이스를 사용하면 다양한 클래스에서 동일한 메서드를 구현하도록 강제할 수 있음. 
이를 통해 코드의 유연성과 재사용성을 높일 수 있음.
 */


namespace DerivedInterface
{

    // ILogger: WriteLog(string message) 메서드를 정의하는 인터페이스입니다.
    interface ILogger // interface 키워드를 이용해서 선언
    {
        void WriteLog(string message);
    }


    // IFormattableLogger: ILogger 인터페이스를 상속하고,
    // WriteLog(string format, params Object[] args) 메서드를 추가로 정의하는 인터페이스임.
    interface IFormattableLogger : ILogger
    {
        void WriteLog(string format, params Object[] args);
        // string format:
        // 서식 문자열을 나타내는 매개변수입니다.
        // 서식 문자열은 {0}, {1}과 같은 자리 표시자를 포함할 수 있으며,
        // 이 자리 표시자는 args 배열의 요소로 대체됩니다.

        // params Object[] args:
        // 가변 개수의 인자를 나타내는 매개변수입니다.
        // params 키워드는 메서드가 임의 개수의 인자를 받을 수 있도록 해줍니다.
        // Object[]는 args 매개변수가 Object 타입의 배열임을 나타냅니다.
        // 즉, args 배열에는 어떤 타입의 객체든 저장할 수 있습니다.
    }


    // ConsoleLogger2: IFormattableLogger 인터페이스를 구현하는 클래스.
    // WriteLog() 메서드를 두 가지 버전으로 구현하여, 문자열 또는 서식 문자열을 사용하여 로그를 출력.
    class ConsoleLogger2 : IFormattableLogger 
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(
                $"{DateTime.Now.ToLocalTime()}, {message}"); // DateTime.Now.ToLocalTime(): C#에서 기본적으로 제공되는 DateTime 구조체의 멤버 메서드
                                                             // DateTime 구조체는 System 네임스페이스에 정의되어 있으므로, using System;을 사용하면 DateTime 구조체를 사용할 수 있습니다.
                                                             // DateTime 구조체는 C#에서 기본적으로 제공되는 구조체이므로, 따로 클래스를 정의하지 않아도 사용할 수 있습니다.
        }

        public void WriteLog(string format, params Object[] args)
        {
            String message = String.Format(format, args);
            Console.WriteLine(
                $"{DateTime.Now.ToLocalTime()}, {message}");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            IFormattableLogger logger = new ConsoleLogger2(); // IFormattableLogger 타입의 변수 logger를 선언하고 ConsoleLogger2 객체를 할당함.
                                                              // logger를 통해 ConsoleLogger2 객체에 접근하고,
                                                              // ConsoleLogger2 객체의 메서드를 호출하거나 속성에 접근할 수 있음.

            logger.WriteLog("The world is not flat."); // WriteLog() 메서드를 호출하여 문자열을 출력
            logger.WriteLog("{0} + {1} = {2}", 1, 1, 2); // WriteLog() 메서드를 호출하여 서식 문자열을 사용하여 출력
                                                         // 출력: 1+1=2
        }
    }
}