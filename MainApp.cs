using System;
using System.Runtime.CompilerServices;


/*
CallerInfo 애트리뷰트:
호출자 정보(Caller Information) 애트리뷰트입니다.
호출자 정보는 메서드의 매개변수에 사용되며, 
메서드의 호출자 이름, 호출자 메서드가 정의된 소스 파일 경로, 심지어 소스 파일 내 행 번호까지 알 수 있습니다.
(C/C++의 __FILENAME__, __LINE__, __FUNCTION__ 매크로에 해당하는 기능입니다.)
이를 이용해서 응용 프로그램의 이벤트를 로그 파일이나 화면에 출력하면,
그 이벤트가 어떤 코드에서 일어났는지 알 수 있습니다.

호출자 정보 애트리뷰트 3개
(1) CallerMemberName: 현재 메서드를 '호출한 멤버(메서드 또는 프로퍼티)의 이름'을 나타냅니다.
(2) CallerFilePath: 현재 메서드가 '호출된 소스 파일 경로'를 나타냅니다. 
                    이때 경로는 소스 코드를 컴파일할 때의 전체 경로를 나타냅니다. 
(3) CallerLineNumber: 현재 메서드가 '호출된 소스 파일 내의 행 번호'를 나타냅니다.
 */


// 호출자 정보 애트리뷰트(Caller Info 애트리뷰트)를 사용하여 호출자 정보를 출력하는 방법 
namespace CallerInfo
{
    public static class Trace // Trace라는 이름의 정적 클래스를 정의합니다.
    {
        public static void WriteLine(string message, // WriteLine 메서드를 정의합니다.
                                                     // string message: 출력할 메시지를 나타냅니다.

            [CallerFilePath] string file = "", // 호출자 파일 경로를 나타내는 선택적 매개변수입니다.
                                               // CallerFilePath 애트리뷰트는
                                               // 컴파일러에게 호출자 파일 경로를 제공하도록 지시합니다.
            [CallerLineNumber] int line = 0, // 호출자 줄 번호를 나타내는 선택적 매개변수입니다.
                                             // CallerLineNumber 애트리뷰트는
                                             // 컴파일러에게 호출자 줄 번호를 제공하도록 지시합니다.
            [CallerMemberName] string member = "") // 호출자 멤버 이름을 나타내는 선택적 매개변수입니다.
                                                   // CallerMemberName 애트리뷰트는 
                                                   // 컴파일러에게 호출자 멤버 이름을 제공하도록 지시합니다.
        {
            Console.WriteLine(
                $"{file}(Line:{line}) {member}: {message}"); // 호출자 정보와 메시지를 결합하여 콘솔에 출력합니다.
        }
    }


    class MainApp
    {
        static void Main(string[] args) 
        {
            Trace.WriteLine("즐거운 프로그래밍!"); // Trace 클래스의 WriteLine 메서드를 호출합니다.
                                                   // Trace.WriteLine() 메서드의 선언부를 보면.
                                                   // [CallerFilePath], [CallerLineNumber], [CallerMemberName]이
                                                   // 선택적 인수로 사용되고 있는데, 이렇게 하면
                                                   // Trace.WriteLine() 메서드를 호출할 때,
                                                   // 호출자 정보 애트리뷰트로 수식한 매개변수는 프로그래머가 별도로
                                                   // 입력하지 않아도 됩니다.
        }
    }
}
