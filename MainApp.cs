using System;


/*
인터페이스의 '기본 구현 메소드':
구현부를 가지는 메소드.
놓친 메소드를 인터페이스에 안전하게 추가하는 방법임 !

인터페이스에 새로운 메소드를 추가할 떄, 기본적인 구현체를 갖도록 해서
기존에 인터페이스를 구현한 클래스들이 코드를 수정하지 않아도 컴파일 오류가 발생하지 않도록 하는 기능 !
(스마트폰 운영체제 업데이트를 했을 때, 기존 앱들이 호환성 문제없이 작동하는 것과 비슷)

인터페이스 참조로 업캐스팅했을 때만 사용할 수 있음. 인터페이스를 직접 참조해야함.
-> 따라서 파생 클래스에서 인터페이스에 추가된 메소드를 잘못 호출할 가능성도 없으므로 좋음.

<-> 원래는 인터페이스가 선언하는 메소드는 파생될 클래스가 무엇을 구현해야 하는지를 정의하는 역할만 했음.
   따라서 인터페이스에 선언하는 메소드에 구현부가 없는게 보통.
 */


namespace DefaultImplementation
{
    interface ILogger
    {
        void WriteLog(string message);

        void WriteError(string error) // 새로운 메소드 추가
        {
            WriteLog($"Error: {error}"); // WriteError() 메소드는 기본 구현을 가지고 있음.
        }
    }


    // ConsoleLogger: ILogger 인터페이스를 구현하는 클래스
    // WriteLog() 메서드만 구현했음.
    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(
                $"{DateTime.Now.ToLocalTime()}, {message}");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger(); // ILogger 타입의 변수 logger를 선언하고 ConsoleLogger 객체를 할당합니다.
            logger.WriteLog("System Up"); // WriteLog() 메서드를 호출하여 "System Up" 메시지를 출력합니다.
            logger.WriteError("System Fail"); // WriteError() 메서드를 호출하여 "System Fail" 오류 메시지를 출력합니다.
                                              // ConsoleLogger 클래스는 WriteError() 메서드를 구현하지 않았지만, 
                                              // 인터페이스의 기본 구현을 사용하기 때문에 오류 없이 실행됩니다!!


            ConsoleLogger clogger = new ConsoleLogger(); // ConsoleLogger 타입의 변수 clogger를 선언하고 ConsoleLogger 객체를 할당합니다.
            clogger.WriteLog("System Up"); //  clogger 변수를 통해 WriteLog() 메서드를 호출합니다.

            // clogger.WriteError("System Fail"); // 컴파일 에러
            //  clogger 변수는 ConsoleLogger 타입이기 때문에 인터페이스의 기본 구현 메서드인 WriteError()를 호출할 수 없습니다.

        }
    }
}
