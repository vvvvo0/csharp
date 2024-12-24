using System;


/*
사용자 정의 예외 클래스:
C#에서 모든 예외 객체는 System.Exception 클래스로부터 파생되어야 합니다.
따라서 Exception 클래스를 상속하기만 하면 새로운 예외 클래스를 만들 수 있습니다.

사용 이유?
.NET은 100개가 넘는 예외 형식을 제공하기 때문에 사용자 정의 예외는 자주 필요하진 않습니다.
하지만 특별한 데이터를 담아서 예외 처리 루틴에 추가 정보를 제공하고 싶거나,
예외 상황을 더 잘 설명하고 싶을 때 필요합니다.
 */


// 사용자 정의 예외 클래스를 사용하는 방법을 보여줌
// InvalidArgumentException이라는 사용자 정의 예외 클래스를 정의하고,
// MergeARGB 메서드에서 이 예외를 발생시킵니다.
namespace MyException
{
    class InvalidArgumentException : Exception // Exception 클래스를 상속받아
                                               // InvalidArgumentException이라는
                                               // 사용자 정의 예외 클래스를 선언함.
                                               // Argument 프로퍼티와 Range 프로퍼티를 추가하여
                                               // 예외 정보를 저장합니다.
    {
        public InvalidArgumentException() // 매개변수가 없는 생성자입니다.
        {
        }

        public InvalidArgumentException(string message) 
            : base(message) // 문자열 message를 매개변수로 받는 생성자입니다. 
                            // base(message)를 호출하여, 기본 클래스의 생성자를 호출합니다.
                            // 
                            // 왜 base(message)를 호출하는가?
                            // base(message)를 호출하여 기본 클래스의 생성자를 호출하면,
                            // 사용자 정의 예외 클래스에서 예외 메시지를 사용할 수 있습니다.
                            // Exception 클래스는 예외를 나타내는 '기본 클래스'이고, 
                            // InvalidArgumentException 클래스는 Exception 클래스를 상속받은 '파생 클래스'.
                            // InvalidArgumentException 클래스(파생 클래스)의 생성자에서,
                            // base(message)를 호출하면,
                            // Exception 클래스(기본 클래스)의 생성자를 호출하여 
                            // 예외 메시지를 초기화합니다.
                            // 즉, InvalidArgumentException 객체를 생성할 때,
                            // 예외 메시지를 지정할 수 있도록 하는 것입니다.
                            // 만약 base(message)를 호출하지 않으면, 
                            // InvalidArgumentException 객체는 예외 메시지를 가지지 않게 됩니다.
                            // 이처럼 base(message)를 호출하여 기본 클래스의 생성자를 호출하면, 
                            // 사용자 정의 예외 클래스에서 예외 메시지를 사용할 수 있습니다.
        {
        }

        public object Argument // 예외가 발생한 인자를 저장하는 프로퍼티입니다.
        {
            get;
            set;
        }

        public string Range // 인자의 유효한 범위를 저장하는 프로퍼티입니다.
        {
            get;
            set;
        }
    }


    class MainApp
    {

        // MergeARGB() 메서드: alpha, red, green, blue 값을 입력으로 받아
        // ARGB 색상 값을 반환하는 메서드입니다.
        static uint MergeARGB(uint alpha, uint red, uint green, uint blue)
        {
            uint[] args = new uint[] { alpha, red, green, blue }; // alpha, red, green, blue 값을
                                                                  // 배열 args에 저장합니다.

            foreach (uint arg in args) // args 배열의 각 요소를 순회합니다.
            {
                if (arg > 255) // 만약 arg 값이 255보다 크면,
                    throw new InvalidArgumentException() // InvalidArgumentException 예외를 발생시킵니다.
                    {
                        Argument = arg, // 예외가 발생한 인자를 Argument 프로퍼티에 저장합니다.
                        Range = "0~255" // 인자의 유효한 범위를 Range 프로퍼티에 저장합니다.
                    };
            }

            return (alpha << 24 & 0xFF000000) |
                   (red << 16 & 0x00FF0000) |
                   (green << 8 & 0x0000FF00) |
                   (blue & 0x000000FF);// alpha, red, green, blue 값을 사용하여
                                       // ARGB 색상 값을 계산하고 반환합니다.
        }


        // Main() 메서드: try-catch 문을 사용하여 
        // InvalidArgumentException 예외를 처리하고, 예외 정보를 출력합니다.
        static void Main(string[] args)
        {
            try // MergeARGB 메서드를 호출하여 ARGB 색상 값을 계산하고 출력합니다.
            {
                Console.WriteLine("0x{0:X}", MergeARGB(255, 111, 111, 111));
                Console.WriteLine("0x{0:X}", MergeARGB(1, 65, 192, 128));
                Console.WriteLine("0x{0:X}", MergeARGB(0, 255, 255, 300));
            }

            catch (InvalidArgumentException e) // InvalidArgumentException 예외가 발생하면,
                                               // 예외 메시지와 함께
                                               // Argument 프로퍼티와 Range 프로퍼티 값을 출력합니다.
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Argument:{e.Argument}, Range:{e.Range}");

            }

        }
    }
}


/*
출력 결과

0xFF6F6F6F
0x141C080
Exception of type 'MyException.InvalidArgumentException' was thrown.
Argument:300, Range:0~255
*/