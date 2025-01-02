using System;
using System.Windows.Forms; // 윈도우 폼 애플리케이션을 만들기 위한 네임스페이스


/*
윈도우 기반 응용 프로그램(윈도우 애플리케이션)들은, 
갑자기 일어나는 사건(이벤트: Event)에 반응해서 코드가 실행되는, 
'이벤트 기반Event Driven' 방식으로 만들어집니다.

이 이벤트(Event)들은 사용자가 직접 응용 프로그램에 대해 일으킨 것처럼 보이지만, 
사실은 '윈도우 OS'가 일으킨 것입니다.
사용자가 마우스나 키보드 같은 하드웨어를 제어하면 '인터럽트'가 발생하고,
이 인터럽트를 윈도우 OS가 받아들입니다.
윈도우 OS는 다시 이 인터럽트를 바탕으로 윈도우 메시지(Windows Message)를 만든 뒤, 
이벤트를 받아야 하는 응용 프로그램에게 보내줍니다.


윈도우 메시지(Windows Message):
윈도우 응용 프로그램은 마우스 이동이나 클릭, 키보드 입력처럼 미리 시스템에 정의된 메시지를 받지만,
다른 응용 프로그램이 자체적으로 정의한 메시지도 받을 수 있습니다.


Application 클래스:
응용 프로그램이 받는 수많은 메시지 중에 관심 있는 메시지만 걸러낼 수 있는 'Message Filtering 기능'을 갖고 있습니다.
윈도우 OS에서 정의하고 있는 메시지는 식별 번호(ID)가 붙여져 있습니다,
Application 클래스는 특정 ID를 가진 메시지를 걸러내는 필터를 함께 등록해뒀다가,
응용 프로그램에 메시지가 전달되면 해당 메시지 필터를 동작시킵니다.
(메시지의 ID가 필터에서 관심을 갖고 있는 값이라면, 필터는 메시지를 요리하고
 메시지의 ID가 필터에서 관심을 갖고 있는 값이 아니라면, 필터는 메시지를 거르지 않고
 메시지를 받아야 하는 폼이나 컨트롤로 보내서 '이벤트'를 발생시킵니다.)


윈도우 폼:
윈도우 폼은 .NET Framework에서 윈도우 애플리케이션의 UI를 구축하기 위한 기술입니다.
(윈도우 애플리케이션을 구축하기 위한 기술)
윈도우 폼은 컨트롤(버튼, 텍스트 박스 등)을 사용하여 사용자 인터페이스를 구성하고, 
이벤트 처리를 통해 사용자 상호 작용을 처리합니다. 윈도우 폼 애플리케이션은 하나 이상의 윈도우 창을 가질 수 있습니다.


PreFilterMessage() 메서드 구현할 때 매개 변수:
Message 구조체. Message 구조체는 여러 프로퍼티를 갖고 있습니다.
(1) HWnd: 메시지를 받는 윈도우의 핸들(Handle)입니다. 핸들은 윈도우의 인스턴스를 식별하고 관리하기 위해 
  운영체제가 붙여놓은 번호입니다.
(2) Msg: 메시지 ID입니다.
(3) LParam: 메시지를 처리하는 데 필요한 정보가 담겨 있습니다.
(4) WParam: 메시지를 처리하는 데 필요한 부가 정보가 담겨 있습니다.
(5) Result: 메시지 처리에 대한 응답을, 윈도우 OS에 반환되는 값을 지정합니다.
 */


// IMessageFilter 인터페이스를 사용하여 윈도우 메시지를 필터링하는 방법
// 이 프로그램은 응용 프로그램이 윈도우로부터 전달받는 모든 메시지(0x0F, 0xA0, 0x200, 0x113 메시지만 제외)를 출력합니다.
// 그리고 0x201 메시지가 도착하면 Application.Exit()를 호출하여 종료합니다.
namespace MessageFilter
{
    // (1) IMessageFilter 인터페이스를 구현하는 파생클래스 정의
    class MessageFilter : IMessageFilter // IMessageFilter 인터페이스를 구현하는 MessageFilter 클래스 정의
                                         // IMessageFilter 인터페이스는 'PreFilterMessage() 메서드'를 구현할 것을 요구함
    {
        // (2) PreFilterMessage() 메서드(메시지 필터) 구현
        public bool PreFilterMessage(ref Message m) // PreFilterMessage() 메서드:
                                                    // 윈도우 메시지를 필터링하는 메서드.
                                                    // PreFilterMessage() 메서드를 구현할 때는.
                                                    // true를 반환(입력 받은 메시지를 처리했으니 응용 프로그램은 관심을 가질 필요가 없다는 의미로)하거나,
                                                    // false를 반환(메시지를 건드리지 않았으니 응용 프로그램이 처리해야 한다는 의미)하여야 합니다.
                                                    // PreFilterMessage() 메서드를 구현할 때 '매개변수'로 받아들이는 Message 구조체는
                                                    // 여러가지 프로퍼티를 갖고 있는데, 이 중 Msg 프로퍼티는 메시지의 ID를 담고 있습니다.
        {
            if (m.Msg == 0x0F || m.Msg == 0xA0 || // 특정 메시지(0x0F, 0xA0, 0x200, 0x113)는, 
                m.Msg == 0x200 || m.Msg == 0x113)
                return false; // 필터링하지 않고 통과시킴.
                              // (입력 받은 메시지를 건드리지 않았으니 응용 프로그램이 처리해야 한다)

            Console.WriteLine($"{m.ToString()} : {m.Msg}"); // 메시지 정보를 콘솔에 출력


            if (m.Msg == 0x201) // 0x201 메시지(WM_LBUTTONDOWN)를 받으면, 
                Application.Exit(); // 애플리케이션 종료

            return true; // 나머지 메시지는 필터링
                         // (입력 받은 메시지를 처리했으니 응용 프로그램은 관심을 가질 필요가 없다)
        }
    }


    class MainApp : Form // Form 클래스를 상속받는 MainApp 클래스 정의
    {
        static void Main(string[] args)
        {
            // (3) Application.AddMessageFilter() 메서드를 호출하여 등록
            Application.AddMessageFilter(new MessageFilter()); 
            // MessageFilter 객체를 메시지 필터로 추가
            // Application.AddMessageFilter() 메서드:
            // 응용 프로그램에 메시지 필터를 설치합니다.
            // 이 메서드는 IMessageFilter 인터페이스를 구현하는 파생클래스(여기서는 MessageFilter)의 인스턴스를 인수로 받습니다.

            Application.Run(new MainApp()); // MainApp의 새 인스턴스를 생성하고, 애플리케이션을 실행
        }
    }
}

